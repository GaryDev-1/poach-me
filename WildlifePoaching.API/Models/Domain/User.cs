using WildlifePoaching.API.Models.Domain.Common;
using WildlifePoaching.API.Models.Enums;

namespace WildlifePoaching.API.Models.Domain
{
    public class User : BaseEntity
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Salt { get; set; }
        public int RoleId { get; set; }
        public UserStatus Status { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public int LoginAttempts { get; set; }
        public DateTime? LockoutEnd { get; set; }
        public string RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiryDate { get; set; }

        // Navigation properties
        public Role Role { get; set; }
        public ICollection<Transaction> Transactions { get; set; }
    }
}
