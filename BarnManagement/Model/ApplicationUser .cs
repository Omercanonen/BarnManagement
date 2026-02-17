using Microsoft.AspNetCore.Identity;

namespace BarnManagement.Model
{
    public class ApplicationUser : IdentityUser
    {
        public bool IsActive { get; set; } = true;
        public Barn? Barn { get; set; }

    }
}
