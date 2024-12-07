using WildlifePoaching.API.Models.Domain.Common;

namespace WildlifePoaching.API.Models.Domain
{
    public class AnimalImage : BaseEntity
    {
        public int AnimalId { get; set; }
        public string FilePath { get; set; }
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public long FileSize { get; set; }
        public bool IsPrimary { get; set; }
        public DateTime UploadedAt { get; set; }

        // Navigation property
        public Animal Animal { get; set; }
    }
}
