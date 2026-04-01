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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);//这一句可以省略
            modelBuilder.Entity<Category>().HasData(//HasData:预先插入数据（Seed Data）
               new Category { Id = 1, Name = "Action", DisplayOrder = 1 },//DisplayOrder = 排序权重（Priority）,数值越小，越靠前（通常）,在PPT16页的时候，定义主键，定义必填字段，给分类加排序字段
                new Category { Id = 2, Name = "SciFi", DisplayOrder = 2 },
                new Category { Id = 3, Name = "History", DisplayOrder = 3 }
                );
        }
    }
}
