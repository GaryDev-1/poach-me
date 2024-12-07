namespace WildlifePoaching.API.Models.DTOs.Animal
{
    public class CreateAnimalDto
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int LocationId { get; set; }
        public int AnimalTypeId { get; set; }
        public string Description { get; set; }
        public IFormFile PrimaryImage { get; set; }
        public List<IFormFile> AdditionalImages { get; set; }
    }
}
