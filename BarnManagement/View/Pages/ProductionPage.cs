using BarnManagement.Business.Abstract;
using BarnManagement.Business.Constants;
using BarnManagement.Data;
using BarnManagement.Model;
using Microsoft.Extensions.DependencyInjection;

namespace BarnManagement.View.Pages
{
    public partial class ProductionPage : UserControl
    {
        private readonly IServiceProvider _serviceProvider;

        private ApplicationUser? _currentUser;
        private int _barnId;

        private readonly System.Windows.Forms.Timer _uiTimer;
        private int _secondsElapsed = 0;

        public ProductionPage(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            InitializeComponent();

            progressBarProduction.Minimum = 0;
            progressBarProduction.Maximum = 10;
            progressBarProduction.Value = 0;

            _uiTimer = new System.Windows.Forms.Timer();
            _uiTimer.Interval = 1000;
            _uiTimer.Tick += UiTimer_Tick;

            buttonCollect.Click += buttonCollect_Click;
        }

        public void SetBarn(int barnId)
        {
            _barnId = barnId;
        }

        public void RefreshUI()
        {
            _ = RefreshAnimalsAsync();
            RefreshReadyToCollect();
        }

        public void SetUser(ApplicationUser user)
        {
            _currentUser = user;

            if (_barnId <= 0)
            {
                using var scope = _serviceProvider.CreateScope();
                var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                var barn = context.Barns.FirstOrDefault(b => b.OwnerUserId == user.Id);
                if (barn != null) _barnId = barn.BarnId;
            }

            RefreshUI();

            if (this.Visible)
                _uiTimer.Start();
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);

            if (this.Visible && _barnId > 0)
                _uiTimer.Start();
            else
                _uiTimer.Stop();
        }

        private void UiTimer_Tick(object? sender, EventArgs e)
        {
            _secondsElapsed++;

            if (_secondsElapsed <= 10)
                progressBarProduction.Value = _secondsElapsed;

            if (_secondsElapsed >= 10)
            {
                _secondsElapsed = 0;
                progressBarProduction.Value = 0;

                RefreshReadyToCollect();
            }
        }

        private async Task RefreshAnimalsAsync()
        {
            if (_barnId <= 0) return;

            try
            {
                using var scope = _serviceProvider.CreateScope();
                var prodService = scope.ServiceProvider.GetRequiredService<IProductionService>();

                var list = await prodService.GetProductionPotentialAsync(_barnId);

                listBoxAnimals.BeginUpdate();
                try
                {
                    listBoxAnimals.Items.Clear();
                    foreach (var item in list)
                    {
                        listBoxAnimals.Items.Add($"{item.SpeciesName}: {item.Count}");
                    }
                }
                finally
                {
                    listBoxAnimals.EndUpdate();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Messages.Error.DataLoadError + " " + ex.Message);
            }
        }

        private void RefreshReadyToCollect()
        {
            if (_barnId <= 0) return;

            try
            {
                using var scope = _serviceProvider.CreateScope();
                var prodService = scope.ServiceProvider.GetRequiredService<IProductionService>();

                var pending = prodService.GetAccumulatedProducts(_barnId);

                listBoxReadyToCollect.BeginUpdate();
                try
                {
                    listBoxReadyToCollect.Items.Clear();
                    foreach (var p in pending)
                    {
                        listBoxReadyToCollect.Items.Add($"{p.ProductName}: {p.TotalQuantity}");
                    }
                }
                finally
                {
                    listBoxReadyToCollect.EndUpdate();
                }

                buttonCollect.Enabled = pending.Count > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(Messages.Error.DataLoadError + " " + ex.Message);
            }
        }

        private async void buttonCollect_Click(object? sender, EventArgs e)
        {
            if (_barnId <= 0) return;

            buttonCollect.Enabled = false;

            try
            {
                using var scope = _serviceProvider.CreateScope();
                var prodService = scope.ServiceProvider.GetRequiredService<IProductionService>();

                var pending = prodService.GetAccumulatedProducts(_barnId);
                if (pending.Count == 0)
                {
                    RefreshReadyToCollect();
                    return;
                }

                await prodService.CollectManualProductsAsync(_barnId, pending);

                RefreshReadyToCollect();
            }
            catch (Exception ex)
            {
                MessageBox.Show(Messages.Error.DataLoadError + " " + ex.Message);
            }
        }

    }
}
