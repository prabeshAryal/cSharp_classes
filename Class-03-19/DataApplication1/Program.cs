using DataApplication1;
using DataApplication1.DatabaseConfigs;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
// Add logging
builder.Logging.AddConsole();

// Configure database connection
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
    // Enable detailed errors and sensitive data logging in development
    if (builder.Environment.IsDevelopment())
    {
        options.EnableSensitiveDataLogging();
        options.EnableDetailedErrors();
    }
});

// Add controllers with views and other required services
builder.Services.AddControllersWithViews();

// Add diagnostic services for troubleshooting
builder.Services.AddDiagnosticServices();

// Build the app
var app = builder.Build();

// Middleware to log all requests - MOVED UP to run for all requests
app.Use(async (context, next) =>
{
    var logger = context.RequestServices.GetRequiredService<ILogger<Program>>();
    logger.LogInformation($"Request: {context.Request.Method} {context.Request.Path}");
    await next();
    logger.LogInformation($"Response: {context.Response.StatusCode}");
});

// Ensure database is created
try
{
    await app.MigrateDatabaseAsync();
}
catch (Exception ex)
{
    var logger = app.Services.GetRequiredService<ILogger<Program>>();
    logger.LogError($"Database migration failed: {ex.Message}");
    // Continue execution even if migration fails
}

// Configure middleware pipeline
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

// Enable endpoint routing (required for both types of routing)
app.UseEndpoints(endpoints =>
{
    // Enable attribute routing
    endpoints.MapControllers();

    // Add conventional routing
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Prabesh}/{action=Index}/{id?}");
});


// Add diagnostic endpoint
app.Map("/debug", async context =>
{
    context.Response.ContentType = "text/html";
    await context.Response.WriteAsync("<h1>Debug Info</h1>");
    await context.Response.WriteAsync("<p>Application is running.</p>");
    await context.Response.WriteAsync("<p>Try accessing:</p>");
    await context.Response.WriteAsync("<ul>");
    await context.Response.WriteAsync("<li><a href='/'>/</a> (root - should go to default controller)</li>");
    await context.Response.WriteAsync("<li><a href='/prabesh'>/prabesh</a> (via attribute routing)</li>");
    await context.Response.WriteAsync("<li><a href='/Prabesh'>/Prabesh</a> (via conventional routing)</li>");
    await context.Response.WriteAsync("<li><a href='/Prabesh/Index'>/Prabesh/Index</a> (explicit action)</li>");
    await context.Response.WriteAsync("</ul>");
});

// Add fallback for unmatched routes
app.UseStatusCodePages(async context =>
{
    context.HttpContext.Response.ContentType = "text/html";

    if (context.HttpContext.Response.StatusCode == 404)
    {
        await context.HttpContext.Response.WriteAsync("<h1>Page Not Found (404)</h1>");
        await context.HttpContext.Response.WriteAsync("<p>The requested page was not found.</p>");
        await context.HttpContext.Response.WriteAsync("<p>Please check:</p>");
        await context.HttpContext.Response.WriteAsync("<ul>");
        await context.HttpContext.Response.WriteAsync("<li>URL is correct</li>");
        await context.HttpContext.Response.WriteAsync("<li>Go to <a href='/debug'>/debug</a> for troubleshooting</li>");
        await context.HttpContext.Response.WriteAsync("<li>Check if your views are in the correct location</li>");
        await context.HttpContext.Response.WriteAsync("</ul>");
    }
});

app.Run();

// Extension method for diagnostic services
public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDiagnosticServices(this IServiceCollection services)
    {
        // Add any diagnostic services here if needed
        return services;
    }
}