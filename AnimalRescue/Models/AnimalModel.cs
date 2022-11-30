using System.ComponentModel.DataAnnotations;

namespace AnimalRescue.Models
{
    public class AnimalModel
    {
        public Guid Id { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public string? Description { get; set; }
        public IFormFile File { get; set; }
        public string PhotoFileName { get; set; }
        public Guid ShelterId { get; set; }
    }
}
