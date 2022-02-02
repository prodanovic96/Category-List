using Microsoft.EntityFrameworkCore;
using MVC_5._0.Models;

//          Kod poziva za bazu napisali smo add-migration addCategoryToDatabase
//          update-database

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
