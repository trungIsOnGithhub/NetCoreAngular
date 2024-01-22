namespace webapi.Dtos;
{
    public class UserTokenDto
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Id { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string DisplayName { get; set; } = string.Empty;
        public string BankAccountNumber { get; set; } = string.Empty;
        public string? ImageUrl { get; set; }
        public int OrganizationId { get; set; }
    }
}