using BarnManagement.Business.Constants;
using BarnManagement.Core.Logging;
using BarnManagement.Model;
using BarnManagement.View;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace BarnManagement
{
    public partial class Login : Form
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILoggerService _logger;
        private readonly IServiceProvider _serviceProvider;
        public Login(UserManager<ApplicationUser> userManager, ILoggerService logger, IServiceProvider serviceProvider)
        {
            _userManager = userManager;
            _logger = logger;
            _serviceProvider = serviceProvider;

            InitializeComponent();
            this.AcceptButton = buttonLogin;
        }

        public async void buttonLogin_Click(object sender, EventArgs e)
        {
            string username = textBoxUsername.Text.Trim();
            string password = textBoxPassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show(Messages.Error.InvalidInput, Messages.Titles.Warning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {

                var user = await _userManager.FindByNameAsync(username);

                if (user != null && await _userManager.CheckPasswordAsync(user, password))
                {
                    _logger.LogInfo($"User '{username}' logged in successfully.");

                    var mainForm = _serviceProvider.GetRequiredService<MainForm>();

                    mainForm.SetCurrentUserAsync(user);

                    this.Hide();
                    mainForm.ShowDialog();
                    this.Close();
                }
                else
                {
                    _logger.LogWarning($"Failed login attempt for username: '{username}'");
                    MessageBox.Show(Messages.Error.LoginFailed, Messages.Titles.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occurred during login.", ex);
                MessageBox.Show(Messages.Error.GeneralError, Messages.Titles.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                buttonLogin.Enabled = true;
                buttonLogin.Text = "Login";
            }
        
        }
           
    }
}
