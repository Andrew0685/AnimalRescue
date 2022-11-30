namespace AnimalRescue.Models
{
    public class FavoriteModel
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string Description { get; set; }
        public string PhotoFileName { get; set; }
        public string ShelterTitle { get; set; }
        public string Address { get; set; }
        public Guid AnimalId { get; set; }
        public Guid ShelterId { get; set; }
    }
}
