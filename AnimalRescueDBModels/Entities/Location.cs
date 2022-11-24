namespace AnimalRescueDBModels.Entities
{
    public class Location
    {
        public Guid Id { get; set; }
        public string Area { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public virtual ICollection<Shelter> Shelters { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
    }
}
