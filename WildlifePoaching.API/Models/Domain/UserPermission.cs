using WildlifePoaching.API.Models.Domain.Common;

namespace WildlifePoaching.API.Models.Domain
{
    public class UserPermission : BaseEntity
    {
        public int RoleId { get; set; }
        public string Permission { get; set; }
        public Role Role { get; set; }
    }
}
