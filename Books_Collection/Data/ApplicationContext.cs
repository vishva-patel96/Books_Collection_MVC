using Books_Collection.Models;
using Microsoft.EntityFrameworkCore;

namespace Books_Collection.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
    }
}
