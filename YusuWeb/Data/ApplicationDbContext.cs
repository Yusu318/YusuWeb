using Microsoft.EntityFrameworkCore;
using YusuWeb.Models;

namespace YusuWeb.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
            {

            }
        public DbSet<Category> Categories { get; set; }
    }
}
