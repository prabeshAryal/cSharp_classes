using MVCfromEmpty.Controllers;

namespace MVCfromEmpty
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();

            var app = builder.Build();
            //app.MapGet("/", () => "Hello World!");
            //app.MapGet("/home", () => "<h1>Home</h1>");
            app.MapControllerRoute(
                name:"Default",
                pattern:"{Controller=Home}/{Action=Index}"
                );
            app.MapControllerRoute(
               name: "/wow",
               pattern: "{Controller=Modal}/{Action=Wow}"
               );
            app.Run();
        }
    }
}
