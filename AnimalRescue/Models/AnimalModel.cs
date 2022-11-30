namespace AnimalRescue.Models
{
    public class AnimalModel
    {
        public Guid Id { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string Description { get; set; }
        public IFormFile File { get; set; }
        public string PhotoFileName { get; set; }
        public Guid ShelterId { get; set; }
    }
}
