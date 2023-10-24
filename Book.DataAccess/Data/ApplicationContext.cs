using Books.Models;
using Microsoft.EntityFrameworkCore;

namespace Books.DataAccess.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }

        protected  override void OnModelCreating (ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id =1 , DisplayOrder=1, Name ="Horror"},
                new Category { Id = 2, DisplayOrder = 2, Name = "History" },
                new Category { Id = 3, DisplayOrder = 3, Name = "Action" },
                new Category { Id = 4, DisplayOrder = 4, Name = "Animation" },
                new Category { Id = 5, DisplayOrder = 5, Name = "Love Story" }

                );
        }
    }
}
