using WildlifePoaching.API.Models.Domain.Common;

namespace WildlifePoaching.API.Models.Domain
{
    public class Role : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<User> Users { get; set; }
        public ICollection<UserPermission> Permissions { get; set; }
    }
}
