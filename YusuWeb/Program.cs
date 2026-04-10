using Microsoft.EntityFrameworkCore;
using YusuWeb.Data;
using SD7501Yusu.DataAccess.Repository;
using SD7501Yusu.DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore.Metadata;


namespace SD7501YusuWeb
{     public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);//make a webapplication

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();


            var app = builder.Build();



            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                //默认的 HSTS 有效期为 30 天。在生产环境中，您可能需要更改这一设置，具体信息请参考 https://aka.ms/aspnetcore-hsts。
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{area=Customer}/{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}   
