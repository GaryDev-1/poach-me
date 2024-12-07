namespace WildlifePoaching.API.Models.DTOs.Animal
{
    public class AnimalDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public DateTime AcquisitionDate { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public string Location { get; set; }
        public string AnimalType { get; set; }
        public List<string> ImageUrls { get; set; }
    }
}
