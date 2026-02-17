using AutoMapper;
using BarnManagement.Business.Constants;
using BarnManagement.Business.DTOs;
using BarnManagement.Core.Logging;
using BarnManagement.Data;
using BarnManagement.Model;
using Microsoft.Extensions.DependencyInjection;

namespace BarnManagement.View.Pages
{
    public partial class CreateBarnForm : UserControl
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILoggerService _logger;
        private ApplicationUser _currentUser = null!;

        public event EventHandler? OnBarnCreated;

        public CreateBarnForm(IServiceProvider serviceProvider, ILoggerService logger)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
            InitializeComponent();
        }

        public void SetUser(ApplicationUser user)
        {
            _currentUser = user;
        }

        private void buttonSaveBarn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxBarnName.Text) ||
                 string.IsNullOrWhiteSpace(textBoxBarnLocation.Text) ||
                 string.IsNullOrWhiteSpace(textBoxPerson.Text))
            {
                MessageBox.Show(Messages.Error.InvalidInput, Messages.Titles.Warning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var scope = _serviceProvider.CreateScope())
                {
                    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                    var mapper = scope.ServiceProvider.GetRequiredService<IMapper>();

                    var barnDto = new BarnCreateDto
                    {
                        BarnName = textBoxBarnName.Text.Trim(),
                        BarnLocation = textBoxBarnLocation.Text.Trim(),
                        BarnPersonInCharge = textBoxPerson.Text.Trim(),
                        BarnMaxCapacity = (int)numericUpDownMaxCapacity.Value,
                        OwnerUserId = _currentUser.Id
                    };

                    var newBarn = mapper.Map<Barn>(barnDto);

                    context.Barns.Add(newBarn);
                    context.SaveChanges();

                    string logMsg = string.Format(Messages.Info.BarnCreatedLog, newBarn.BarnName, _currentUser.UserName);
                    _logger.LogInfo(logMsg);

                    MessageBox.Show(Messages.Info.BarnCreated, Messages.Titles.Success, MessageBoxButtons.OK, MessageBoxIcon.Information);

                    OnBarnCreated?.Invoke(this, EventArgs.Empty);

                    textBoxBarnName.Clear();
                    textBoxBarnLocation.Clear();
                    textBoxPerson.Clear();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(Messages.Error.BarnCreationError, ex);

                MessageBox.Show(Messages.Error.GeneralError, Messages.Titles.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}


