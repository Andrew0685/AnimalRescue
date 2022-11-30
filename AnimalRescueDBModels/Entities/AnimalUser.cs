using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalRescueDBModels.Entities
{
    public class AnimalUser
    {
        public int Id { get; set; }
        public Guid AnimalId { get; set; }
        public virtual Animal Animal { get; set; }
        public Guid UserId { get; set; }
        public virtual User User { get; set; }
    }
}
