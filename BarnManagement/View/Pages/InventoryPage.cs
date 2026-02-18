using BarnManagement.Business.Abstract;
using BarnManagement.Business.Constants;
using BarnManagement.Business.DTOs;
using BarnManagement.Model;
using Microsoft.Extensions.DependencyInjection;
using System.Text;

namespace BarnManagement.View.Pages
{
    public partial class InventoryPage : UserControl
    {
        private readonly IServiceProvider _serviceProvider;

        private int _barnId;
        private ApplicationUser? _currentUser;

        private int _selectedProductId = 0;
        private decimal _selectedUnitPrice = 0m;
        private int _selectedStock = 0;
        public InventoryPage(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            InitializeComponent();

            listBoxInventory.SelectedIndexChanged += listBoxInventory_SelectedIndexChanged;
            numericUpDownSellQuantity.ValueChanged += numericUpDownSellQuantity_ValueChanged;
            buttonSell.Click += buttonSell_Click;

            ResetSellPanel();
        }

        public void SetBarn(int barnId)
        {
            _barnId = barnId;
        }

        public void SetUser(ApplicationUser user)
        {
            _currentUser = user;

            if (_barnId <= 0)
            {
                using var scope = _serviceProvider.CreateScope();
                var db = scope.ServiceProvider.GetRequiredService<Data.AppDbContext>();
                var barn = db.Barns.FirstOrDefault(b => b.OwnerUserId == user.Id);
                if (barn != null) _barnId = barn.BarnId;
            }

            _ = LoadInventoryAsync();
        }

        public async Task RefreshUIAsync()
        {
            await LoadInventoryAsync();
        }

        private async Task LoadInventoryAsync()
        {
            if (_barnId <= 0) return;

            try
            {
                using var scope = _serviceProvider.CreateScope();
                var invService = scope.ServiceProvider.GetRequiredService<IInventoryService>();

                var items = await invService.GetInventoryAsync(_barnId);

                listBoxInventory.BeginUpdate();
                try
                {
                    listBoxInventory.Items.Clear();

                    foreach (var i in items)
                    {
                        listBoxInventory.Items.Add(new InventoryListItem(i));
                    }
                }
                finally
                {
                    listBoxInventory.EndUpdate();
                }

                if (listBoxInventory.Items.Count == 0)
                {
                    ResetSellPanel();
                }
                else
                {
                    listBoxInventory.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Messages.Error.DataLoadError + " " + ex.Message, Messages.Titles.Error);
            }
        }

        private void listBoxInventory_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (listBoxInventory.SelectedItem is not InventoryListItem selected)
            {
                ResetSellPanel();
                return;
            }

            _selectedProductId = selected.Dto.ProductId;
            _selectedUnitPrice = selected.Dto.UnitPrice;
            _selectedStock = selected.Dto.StockQuantity;

            labelUnitPrice.Text = _selectedUnitPrice.ToString("C2");
            labelStock.Text = _selectedStock.ToString();

            numericUpDownSellQuantity.Minimum = 1;
            numericUpDownSellQuantity.Maximum = _selectedStock > 0 ? _selectedStock : 1;
            numericUpDownSellQuantity.Value = 1;

            UpdateTotalPriceLabel();
            buttonSell.Enabled = _selectedStock > 0;
        }

        private void numericUpDownSellQuantity_ValueChanged(object? sender, EventArgs e)
        {
            UpdateTotalPriceLabel();
        }

        private void UpdateTotalPriceLabel()
        {
            if (_selectedProductId <= 0 || _selectedStock <= 0)
            {
                labelTotalPrice.Text = 0m.ToString("C2");
                return;
            }

            int qty = (int)numericUpDownSellQuantity.Value;
            decimal total = _selectedUnitPrice * qty;
            labelTotalPrice.Text = total.ToString("C2");
        }

        private async void buttonSell_Click(object sender, EventArgs e)
        {
            if (_barnId <= 0 || _selectedProductId <= 0 || _currentUser == null)
                return;

            int qty = (int)numericUpDownSellQuantity.Value;

            if (qty <= 0 || qty > _selectedStock)
            {
                MessageBox.Show(Messages.Warning.InvalidQuantity, Messages.Titles.Warning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //buttonSell.Enabled = false;

            try
            {
                using var scope = _serviceProvider.CreateScope();
                var invService = scope.ServiceProvider.GetRequiredService<IInventoryService>();

                bool ok = await invService.SellAsync(new SellRequestDto
                {
                    BarnId = _barnId,
                    ProductId = _selectedProductId,
                    QuantityToSell = qty,
                    SoldByUserId = _currentUser.Id
                });

                if (!ok)
                {
                    MessageBox.Show(Messages.Error.NotEnoughStock, Messages.Titles.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (this.ParentForm is MainForm mainForm)
                    mainForm.RefreshBalance();
                await LoadInventoryAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{Messages.Error.GeneralError}\n{ex.Message}", Messages.Titles.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally
            {
            }
        }

        private void ResetSellPanel()
        {
            _selectedProductId = 0;
            _selectedUnitPrice = 0m;
            _selectedStock = 0;

            labelUnitPrice.Text = 0m.ToString("C2");
            labelStock.Text = "0";
            labelTotalPrice.Text = 0m.ToString("C2");

            numericUpDownSellQuantity.Minimum = 0;
            numericUpDownSellQuantity.Maximum = 0;
            numericUpDownSellQuantity.Value = 0;

            buttonSell.Enabled = false;
        }

        private sealed class InventoryListItem
        {
            public InventoryItemDto Dto { get; }

            public InventoryListItem(InventoryItemDto dto)
            {
                Dto = dto;
            }

            public override string ToString()
            {
                return $"{Dto.ProductName} (Stock: {Dto.StockQuantity})";
            }
        }

        private async void buttonSellAll_Click(object sender, EventArgs e)
        {
            if (_barnId <= 0 || _selectedProductId <= 0 || _currentUser == null)
                return;

            //buttonSell.Enabled = false;
            //buttonSellAll.Enabled = false;

            try
            {
                using var scope = _serviceProvider.CreateScope();
                var invService = scope.ServiceProvider.GetRequiredService<IInventoryService>();

                bool ok = await invService.SellAllAsync(_barnId, _selectedProductId, _currentUser.Id);

                if (!ok)
                {
                    MessageBox.Show(Messages.Warning.NoStockToSell, Messages.Titles.Warning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (this.ParentForm is MainForm mainForm)
                    mainForm.RefreshBalance();

                await LoadInventoryAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(Messages.Error.GeneralError + "\n" + ex.Message, Messages.Titles.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
            }
        }

        private async void buttonExport_ClickAsync(object sender, EventArgs e)
        {
            if (_barnId <= 0 || _currentUser == null)
                return;

            buttonExport.Enabled = false;

            try
            {
                using var scope = _serviceProvider.CreateScope();
                var invService = scope.ServiceProvider.GetRequiredService<IInventoryService>();

                string json = await invService.ExportSalesJsonAsync(_barnId);

                using var sfd = new SaveFileDialog
                {
                    Title = "Export Sales History (JSON)",
                    Filter = "JSON files (*.json)|*.json",
                    DefaultExt = "json",
                    AddExtension = true,
                    FileName = $"sales_{_barnId}_{DateTime.UtcNow:yyyyMMdd_HHmmss}.json"
                };

                if (sfd.ShowDialog() != DialogResult.OK)
                    return;

                await File.WriteAllTextAsync(sfd.FileName, json, Encoding.UTF8);

                MessageBox.Show(Messages.Info.SalesExportSuccess, Messages.Titles.Success, MessageBoxButtons.OK, MessageBoxIcon.Information );

            }
            catch (Exception ex)
            {
                MessageBox.Show($"{Messages.Error.GeneralError}\n{ex.Message}", Messages.Titles.Error, MessageBoxButtons.OK, MessageBoxIcon.Error );

            }
            finally
            {
                buttonExport.Enabled = true;
            }

        }
    }
}
