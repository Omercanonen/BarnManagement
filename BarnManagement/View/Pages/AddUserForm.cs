using AutoMapper;
using BarnManagement.Business.Constants;
using BarnManagement.Business.DTOs;
using BarnManagement.Data;
using BarnManagement.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace BarnManagement.View.Pages
{
    public partial class AddUserForm : UserControl
    {
        private readonly IServiceProvider _serviceProvider;
        public AddUserForm(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            LoadRoles();
            LoadUsers();
        }
        private void LoadRoles()
        {

            if (comboBoxRole != null)
            {
                comboBoxRole.Items.Clear();
                comboBoxRole.Items.Add("Admin");
                comboBoxRole.Items.Add("User");
                comboBoxRole.SelectedIndex = 1;
            }
        }

        private void LoadUsers()
        {
            try
            {
                using (var scope = _serviceProvider.CreateScope())
                {
                    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                    var mapper = scope.ServiceProvider.GetRequiredService<IMapper>();

                    var activeUsers = context.Users.Where(u => u.IsActive == true).ToList();

                    var userDtos = mapper.Map<List<UserListDto>>(activeUsers);

                    if (dataGridViewUser != null)
                    {
                        dataGridViewUser.DataSource = userDtos;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{Messages.Error.DataLoadError} {ex.Message}", Messages.Titles.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void buttonAddUser_ClickAsync(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxUsername.Text) ||
                string.IsNullOrWhiteSpace(textBoxPassword.Text) ||
                comboBoxRole.SelectedItem == null)
            {
                MessageBox.Show(Messages.Error.InvalidInput, Messages.Titles.Warning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var createDto = new UserCreateDto
            {
                UserName = textBoxUsername.Text.Trim(),
                Password = textBoxPassword.Text.Trim(),
                Role = comboBoxRole.SelectedItem.ToString()!
            };

            try
            {
                using (var scope = _serviceProvider.CreateScope())
                {
                    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                    var mapper = scope.ServiceProvider.GetRequiredService<IMapper>();

                    if (!await roleManager.RoleExistsAsync(createDto.Role))
                    {
                        await roleManager.CreateAsync(new IdentityRole(createDto.Role));
                    }

                    var newUser = mapper.Map<ApplicationUser>(createDto);

                    var result = await userManager.CreateAsync(newUser, createDto.Password);

                    if (result.Succeeded)
                    {
                       
                        await userManager.AddToRoleAsync(newUser, createDto.Role);

                        string successMsg = string.Format(Messages.Info.UserCreated, createDto.UserName);
                        MessageBox.Show(successMsg, Messages.Titles.Success, MessageBoxButtons.OK, MessageBoxIcon.Information);

                        textBoxUsername.Clear();
                        textBoxPassword.Clear();

                        LoadUsers();
                    }
                    else
                    {
                        string errors = string.Join("\n", result.Errors.Select(x => x.Description));
                        MessageBox.Show($"{Messages.Error.RegistrationFailed}\n{errors}", Messages.Titles.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
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
