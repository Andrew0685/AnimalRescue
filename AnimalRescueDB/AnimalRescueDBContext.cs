using AnimalRescueDBModels.Entities;
using Microsoft.EntityFrameworkCore;

namespace AnimalRescueDB
{
    public class AnimalRescueDBContext : DbContext
    {
        public AnimalRescueDBContext()
        {
        }
        public AnimalRescueDBContext(DbContextOptions<AnimalRescueDBContext> options)
                               : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Shelter> Shelters { get; set; }
        public DbSet<AnimalUser> AnimalsUsers { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-CAEQMU3\SQLEXPRESS;Database=AnimalRescue;Integrated Security=SSPI;Encrypt=True;TrustServerCertificate=True;");
        }
    }
}