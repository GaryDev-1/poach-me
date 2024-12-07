namespace WildlifePoaching.API.Models.Domain.Animals
{
    public class Fish : Animal
    {
        public string Species { get; set; }
        public string WaterType { get; set; }
        public float OptimalTemperature { get; set; }
    }
}
