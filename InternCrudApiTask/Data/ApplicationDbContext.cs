using InternCrudApiTask.Models;
using Microsoft.EntityFrameworkCore;

namespace InternCrudApiTask.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options): base(options)
        {

        }

        public DbSet<ColdDrink> tblColdDrinks { get; set; }
    }
}
