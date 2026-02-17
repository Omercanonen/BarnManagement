namespace BarnManagement.Business.DTOs
{
    public class UserCreateDto
    {
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Role { get; set; } = null!;
    }

    public class UserListDto
    {
        public string Id { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public bool IsActive { get; set; }
    }
}
