namespace WildlifePoaching.API.Models.DTOs.Animal
{
    public class UpdateAnimalDto
    {
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public int? LocationId { get; set; }
        public List<IFormFile> NewImages { get; set; }
        public List<int> ImagesToDelete { get; set; }
    }
}
