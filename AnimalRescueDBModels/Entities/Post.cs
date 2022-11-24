namespace AnimalRescueDBModels.Entities
{
    public class Post
    {
        public Guid Id { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public Guid LocationId { get; set; }
        public virtual Location Location { get; set; }
        public Guid UserId { get; set; }
        public virtual User User { get; set; }
    }
}
