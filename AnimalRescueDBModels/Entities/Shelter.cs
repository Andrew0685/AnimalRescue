namespace AnimalRescueDBModels.Entities
{
    public class Shelter
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }       
        public virtual ICollection<Animal> Animals { get; set; }
    }
}
