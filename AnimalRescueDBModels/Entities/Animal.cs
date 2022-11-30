namespace AnimalRescueDBModels.Entities
{
    public class Animal
    {
        public Guid Id { get; set; }
        public string FileName { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string Description { get; set; }
        public Guid ShelterId { get; set; }
        public virtual Shelter Shelter { get; set; }
        public virtual ICollection<AnimalUser> AnimalUsers { get; set; }
    }
}
