namespace AnimalRescue.Models
{
    public class PostModel
    {
        public Guid Id { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public IFormFile File { get; set; }
        public Guid UserId { get; set; }
    }
}
