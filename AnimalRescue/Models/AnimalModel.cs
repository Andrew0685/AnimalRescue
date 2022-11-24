namespace AnimalRescue.Models
{
    public class AnimalModel
    {
        public Guid Id { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Age { get; set; }
        public string Description { get; set; }
    }
}
