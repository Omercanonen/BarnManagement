using BarnManagement.Business.Abstract;
using BarnManagement.Business.Constants;
using BarnManagement.Data;
using BarnManagement.Model;
using BarnManagement.View.Pages;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace BarnManagement.View
{
    public partial class MainForm : Form
    {
        private readonly IServiceProvider _serviceProvider;
        private ApplicationUser? _currentUser;
        private readonly UserManager<ApplicationUser> _userManager;
        private ProductionPage? _productionPage;
        public Barn? CurrentBarn { get; private set; }
        //public ApplicationUser CurrentUser { get; private set; }
        public MainForm(IServiceProvider serviceProvider, UserManager<ApplicationUser> userManager)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
            _userManager = userManager;

            GameTimer.Tick -= GameTimer_Tick;
            GameTimer.Tick += GameTimer_Tick;
        }
        private async void GameTimer_Tick(object? sender, EventArgs e)
        {
            if (_currentUser == null || CurrentBarn == null)
                return;

            try
            {
                using (var scope = _serviceProvider.CreateScope())
                {
                    var agingService = scope.ServiceProvider.GetRequiredService<IAgingService>();
                    var productionService = scope.ServiceProvider.GetRequiredService<IProductionService>();

                    await agingService.ProcessAnimalGrowthAsync(CurrentBarn.BarnId);
                    await productionService.ProduceAsync(CurrentBarn.BarnId);
                }
            }
            catch (Exception ex)
            {
                string errorMsg = string.Format(Messages.Error.TimerError, ex.Message);
                System.Diagnostics.Debug.WriteLine(errorMsg);
            }
        }

        public async Task SetCurrentUserAsync(ApplicationUser user)
        {
            _currentUser = user;
            labelUserName.Text = $"User: {user.UserName}";

            using (var scope = _serviceProvider.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

                var barn = context.Barns.FirstOrDefault(b => b.OwnerUserId == user.Id);

                bool isAdmin = await _userManager.IsInRoleAsync(user, "Admin");


                if (buttonAddUser != null)
                {
                    buttonAddUser.Visible = isAdmin;
                }

                if (barn != null)
                {
                    CurrentBarn = barn;

                    labelBarnName.Text = barn.BarnName;
                    labelBalance.Text = barn.BarnBalance.ToString("C2");

                    GameTimer.Stop();
                    GameTimer.Interval = 10_000;
                    GameTimer.Start();

                    if (panelMenu != null) panelMenu.Visible = true;

                    LoadPage<HomePage>();
                }
                else
                {
                    CurrentBarn = null;
                    labelBarnName.Text = "No Barn";
                    labelBalance.Text = "0.00";
                    GameTimer.Stop();
                    if (panelMenu != null) panelMenu.Visible = false;

                    LoadCreateBarnScreen();
                }
            }

            this.Text = $"Barn Management System";
        }

        public void RefreshBalance()
        {
            if (_currentUser == null || CurrentBarn == null) return;

            using (var scope = _serviceProvider.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

                var currentBalance = context.Barns
                    .Where(b => b.BarnId == CurrentBarn.BarnId)
                    .Select(b => b.BarnBalance)
                    .FirstOrDefault();

                CurrentBarn.BarnBalance = currentBalance;
                labelBalance.Text = currentBalance.ToString("C2");
            }
        }

        private void LoadCreateBarnScreen()
        {
            try
            {
                if (panelContent.Controls.Count > 0)
                {
                    panelContent.Controls[0].Dispose();
                    panelContent.Controls.Clear();
                }

                var createPage = _serviceProvider.GetRequiredService<CreateBarnForm>();

                createPage.SetUser(_currentUser!);

                createPage.OnBarnCreated += (s, args) =>
                {
                    SetCurrentUserAsync(_currentUser!);
                };

                createPage.Dock = DockStyle.Fill;
                panelContent.Controls.Add(createPage);
                createPage.BringToFront();
            }
            catch (Exception ex)
            {
                string msg = string.Format(Messages.Error.PageLoadError, ex.Message);
                MessageBox.Show(msg, Messages.Titles.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadPage<T>() where T : UserControl
        {
            try
            {
                if (panelContent.Controls.Count > 0)
                {
                    panelContent.Controls[0].Dispose();
                    panelContent.Controls.Clear();
                }

                var page = _serviceProvider.GetRequiredService<T>();

                if (_currentUser != null)
                {
                    if (page is HomePage homePage)
                    {
                        homePage.SetUser(_currentUser);
                    }
                    else if (page is PurchasePage purchasePage)
                    {
                        purchasePage.SetUser(_currentUser);
                    }
                    else if (page is InventoryPage inventoryPage)
                    {
                    }
                    else if (page is ProductionPage productionPage)
                    {
                        if (CurrentBarn != null)
                            productionPage.SetBarn(CurrentBarn.BarnId);

                        productionPage.SetUser(_currentUser!);   
                        _productionPage = productionPage;
                    }
                    else
                    {
                        _productionPage = null;
                    }
                    

                }

                page.Dock = DockStyle.Fill;
                page.Visible = true;

                panelContent.Controls.Add(page);
                page.BringToFront();
            }
            catch (Exception ex)
            {
                string msg = string.Format(Messages.Error.PageLoadError, ex.Message);
                MessageBox.Show(msg, Messages.Titles.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonAddUser_Click(object sender, EventArgs e)
        {
            LoadPage<AddUserForm>();
        }

        private void buttonHome_Click_1(object sender, EventArgs e)
        {
            LoadPage<HomePage>();
        }

        private void buttonPurchase_Click_1(object sender, EventArgs e)
        {
            LoadPage<PurchasePage>();
        }

        private void buttonProduction_Click_1(object sender, EventArgs e)
        {
            LoadPage<ProductionPage>();
        }

        private void buttonInventory_Click_1(object sender, EventArgs e)
        {
            LoadPage<InventoryPage>();
        }
    }
}
