using AnonymousForum.Data;
using Microsoft.EntityFrameworkCore;

namespace AnonymousForum
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<ForumContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("ForumContext")));

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "threads",
                    pattern: "{controller=Threads}/{action=Index}/{id}");

                endpoints.MapControllerRoute(
                    name: "thread",
                    pattern: "{controller=Threads}/{action=Thread}/{id}");

                endpoints.MapControllerRoute(
                    name: "createThread",
                    pattern: "{controller=Threads}/{action=CreateThread}/{categoryId}");

                endpoints.MapControllerRoute(
                    name: "postThread",
                    pattern: "{controller=Threads}/{action=PostThread}/{categoryId}");

                endpoints.MapControllerRoute(
                    name: "createComment",
                    pattern: "{controller=Threads}/{action=CreateComment}/{threadId}");

                endpoints.MapControllerRoute(
                    name: "postThread",
                    pattern: "{controller=Threads}/{action=PostComment}/{threadId}");
            });

            app.Run();
        }
    }
}