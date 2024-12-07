namespace WildlifePoaching.API.Models.Domain.Animals
{
    public class Dog : Animal
    {
        public string Breed { get; set; }
        public bool IsTrainable { get; set; }
    }
}
