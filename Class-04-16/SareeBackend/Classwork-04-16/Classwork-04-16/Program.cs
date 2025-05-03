// Add this using statement at the top if not already present
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews(); // Keep this for MVC controllers like Home

// *** Add Swagger Services START ***
builder.Services.AddEndpointsApiExplorer(); // Needed for API Explorer features used by Swagger
builder.Services.AddSwaggerGen(options =>
{
    // Optional: Configure Swagger document details
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Saree Marketplace API",
        Description = "API for managing sarees in the online marketplace",
        // You can add more details like Terms of Service, Contact, License
    });

    // Optional: If you have XML comments enabled for your API controllers,
    // you can uncomment the following lines to include them in Swagger.
    // Ensure XML documentation file generation is enabled in your .csproj:
    // <PropertyGroup>
    //   <GenerateDocumentationFile>true</GenerateDocumentationFile>
    //   <NoWarn>$(NoWarn);1591</NoWarn> <!-- Suppress warnings for missing comments -->
    // </PropertyGroup>
    // var xmlFilename = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
    // options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});
// *** Add Swagger Services END ***


var app = builder.Build();

// Configure the HTTP request pipeline.

// *** Configure Swagger Middleware START ***
// Configure Swagger & Swagger UI - Often placed within IsDevelopment for safety,
// but can be outside if you want it accessible in other environments (use caution).
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); // Generates the swagger.json definition file
    app.UseSwaggerUI(options =>
    {
        // The default endpoint is /swagger/v1/swagger.json
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Saree Marketplace API v1");
        // Optionally, make Swagger UI available at the app's root
        // options.RoutePrefix = string.Empty; // If you want Swagger UI at '/', but we'll redirect instead
    });
}
// *** Configure Swagger Middleware END ***


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

// Keep the default MVC route
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Also map API controllers (if not already implicitly handled by [ApiController])
// app.MapControllers(); // Often needed if you have separate API controllers without MapControllerRoute

app.Run();