using AutoMapper;
using BarnManagement.Business.Constants;
using BarnManagement.Business.DTOs;
using BarnManagement.Data;
using BarnManagement.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BarnManagement.View.Pages
{
    public partial class PurchasePage : UserControl
    {
        public event EventHandler? OnPurchaseCompleted;
        private readonly IServiceProvider _serviceProvider;
        private ApplicationUser? _currentUser;
        private Barn? _currentBarn;


        public PurchasePage(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            InitializeComponent();
            comboBoxAnimalSpecies.SelectedIndexChanged += comboBoxAnimalSpecies_SelectedIndexChanged;
        }

        public void SetUser(ApplicationUser user)
        {
            _currentUser = user;
            LoadInitialData();
        }

        private void LoadInitialData()
        {
            try
            {
                using (var scope = _serviceProvider.CreateScope())
                {
                    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                    _currentBarn = context.Barns.FirstOrDefault(b => b.OwnerUserId == _currentUser!.Id);

                    
                    var speciesList = context.AnimalSpecies
                                             .Where(s => s.IsActive)
                                             .AsNoTracking()
                                             .ToList();

                    comboBoxAnimalSpecies.DataSource = null; 

                    comboBoxAnimalSpecies.DisplayMember = "AnimalSpeciesName";
                    comboBoxAnimalSpecies.ValueMember = "AnimalSpeciesId";     
                    comboBoxAnimalSpecies.DataSource = speciesList;

                    comboBoxAnimalSpecies.SelectedIndex = -1;
                    if (labelPrice != null) labelPrice.Text = "0.00";

                    comboBoxAnimalGender.Items.Clear();
                    comboBoxAnimalGender.Items.Add("Male");
                    comboBoxAnimalGender.Items.Add("Female");
                    comboBoxAnimalGender.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{Messages.Error.DataLoadError} {ex.Message}", Messages.Titles.Error);
            }
        }

        private void comboBoxAnimalSpecies_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxAnimalSpecies.SelectedItem is AnimalSpecies selected)
            {
                labelPrice.Text = selected.AnimalSpeciesPurchasePrice.ToString("C2");
            }
            else
            {
                labelPrice.Text = "0.00";
            }
        }
       

        private async void buttonAnimalPurchase_Click(object sender, EventArgs e)
        {
            if (_currentBarn == null)
            {
                MessageBox.Show(Messages.Error.BarnNotFound, Messages.Titles.Error);
                return;
            }
            if (comboBoxAnimalSpecies.SelectedItem == null)
            {
                MessageBox.Show(Messages.Warning.SelectSpecies, Messages.Titles.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(textBoxName.Text))
            {
                MessageBox.Show(Messages.Warning.EnterAnimalName, Messages.Titles.Warning);
                return;
            }
            if (comboBoxAnimalGender.SelectedItem == null)
            {
                MessageBox.Show(Messages.Warning.SelectGender, Messages.Titles.Warning);
                return;
            }

            try
            {
                this.Cursor = Cursors.WaitCursor;

                var selectedSpecies = (AnimalSpecies)comboBoxAnimalSpecies.SelectedItem;

                string selectedGender = comboBoxAnimalGender.SelectedItem.ToString()!;

                using (var scope = _serviceProvider.CreateScope())
                {
                    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                    var mapper = scope.ServiceProvider.GetRequiredService<IMapper>();

                    var dbBarn = await context.Barns.FindAsync(_currentBarn.BarnId);

                    if (dbBarn == null)
                    {
                        MessageBox.Show(Messages.Error.BarnNotFound, Messages.Titles.Error);
                        return;
                    }

                    if (dbBarn.BarnBalance < selectedSpecies.AnimalSpeciesPurchasePrice)
                    {
                        MessageBox.Show(Messages.Error.InsufficientBalance, Messages.Titles.Error);
                        return;
                    }

                    var purchaseDto = new PurchaseAnimalDto
                    {
                        BarnId = dbBarn.BarnId,
                        AnimalSpeciesId = selectedSpecies.AnimalSpeciesId,
                        AnimalName = textBoxName.Text.Trim(),
                        AnimalGender = selectedGender
                    };

                    var animal = mapper.Map<Animal>(purchaseDto);

                    var purchaseLog = new Purchase
                    {
                        BarnId = dbBarn.BarnId,
                        AnimalSpeciesId = selectedSpecies.AnimalSpeciesId,
                        Quantity = 1,
                        UnitPrice = selectedSpecies.AnimalSpeciesPurchasePrice,
                        TotalCost = selectedSpecies.AnimalSpeciesPurchasePrice,
                        PurchasedByUserId = _currentUser?.Id,
                        PurchaseDate = DateTime.UtcNow
                    };

                    dbBarn.BarnBalance -= selectedSpecies.AnimalSpeciesPurchasePrice;

                    context.Animals.Add(animal);
                    context.Purchases.Add(purchaseLog);
                    context.Barns.Update(dbBarn);

                    await context.SaveChangesAsync();

                    MessageBox.Show(Messages.Info.AnimalsPurchased, Messages.Titles.Success, MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (this.ParentForm is MainForm mainForm)
                    {
                        mainForm.RefreshBalance();
                    }

                    OnPurchaseCompleted?.Invoke(this, EventArgs.Empty);
                    textBoxName.Clear();

                   
                    comboBoxAnimalSpecies.SelectedIndex = -1;
                    comboBoxAnimalGender.SelectedIndex = -1;
                    _currentBarn.BarnBalance = dbBarn.BarnBalance;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{Messages.Error.GeneralError}\n{ex.Message}", Messages.Titles.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
    }

}


