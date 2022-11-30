using Microsoft.AspNetCore.SignalR;

namespace AnimalRescue.Models
{
    public class AnimalUserModel
    {
        public Guid UserId { get; set; }
        public Guid AnimalId { get; set; }
    }
}
