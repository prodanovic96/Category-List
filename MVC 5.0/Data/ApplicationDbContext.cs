using Microsoft.EntityFrameworkCore;
using MVC_5._0.Models;

namespace MVC_5._0.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Category> Category{ get; set; }
    }
}
