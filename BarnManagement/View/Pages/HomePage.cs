using BarnManagement.Data;
using BarnManagement.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BarnManagement.View.Pages
{
    public partial class HomePage : UserControl
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly UserManager<ApplicationUser> _userManager;
        private ApplicationUser? _currentUser;

        public HomePage(IServiceProvider serviceProvider, UserManager<ApplicationUser> userManager)
        {
            _serviceProvider = serviceProvider;
            _userManager = userManager;
            InitializeComponent();
        }

        public async void SetUser(ApplicationUser user)
        {
            _currentUser = user;
            var roles = await _userManager.GetRolesAsync(user);

            if (roles.Contains("Admin"))
            {
                LoadAdminDashboard();
            }
            else
            {
                LoadUserDashboard();
            }
        }

        private void LoadAdminDashboard()
        {
            dataGridViewHome.Visible = true;

            try
            {
                using (var scope = _serviceProvider.CreateScope())
                {
                    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

                    var activeBarns = context.Barns
                        .Include(b => b.OwnerUser)
                        .Where(b => b.IsActive == true)
                        .Select(b => new
                        {
                            Id = b.BarnId,
                            BarnName = b.BarnName,
                            Owner = b.OwnerUser.UserName,
                            Location = b.BarnLocation,
                            Balance = b.BarnBalance,
                            Capacity = b.BarnCapacity + "/" + b.BarnMaxCapacity,
                        })
                        .ToList();

                    dataGridViewHome.DataSource = activeBarns;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Veriler yüklenirken hata: {ex.Message}");
            }
        }

        private void LoadUserDashboard()
        {
            dataGridViewHome.Visible = true;

            try
            {
                using (var scope = _serviceProvider.CreateScope())
                {
                    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                    string currentUserId = _currentUser!.Id;

                    var myAnimals = context.Animals
                        .Include(a => a.AnimalSpecies)
                        .Include(a => a.Barn)
                        .Where(a => a.Barn.OwnerUserId == currentUserId && a.IsActive)
                        .AsEnumerable()
                        .Select(a =>
                        {
                            int totalMonths = a.AgeMonth;

                            if (totalMonths < 0)
                                totalMonths = 0;

                            int years = totalMonths / 12;
                            int months = totalMonths % 12;

                            string ageText;

                            if (years > 0 && months > 0)
                                ageText = $"{years} Year {months} Month";
                            else if (years > 0)
                                ageText = $"{years} Year";
                            else
                                ageText = $"{months} Month";

                            return new
                            {
                                ID = a.AnimalId,
                                Name = a.AnimalName,
                                Species = a.AnimalSpecies.AnimalSpeciesName,
                                Gender = a.AnimalGender,
                                Age = ageText
                            };
                        })
                        .ToList();

                    dataGridViewHome.DataSource = myAnimals;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hayvanlar yüklenirken hata: " + ex.Message);
            }
        }

    }
}
