using System.Net.Http;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// *** Configure HttpClientFactory for API interaction ***
builder.Services.AddHttpClient("SareeApiClient", client =>
{
    // Get base address from configuration
    string? baseAddress = builder.Configuration["SareeApiBaseUrl"];
    if (string.IsNullOrEmpty(baseAddress))
    {
        // Handle missing configuration (throw exception or log)
        throw new InvalidOperationException("SareeApiBaseUrl is not configured in appsettings.json");
    }
    client.BaseAddress = new Uri(baseAddress);
    client.DefaultRequestHeaders.Accept.Clear();
    client.DefaultRequestHeaders.Accept.Add(
        new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
})
// *** WARNING: Only for LOCAL DEVELOPMENT with self-signed certs ***
// This bypasses SSL certificate validation. DO NOT USE IN PRODUCTION.
.ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
{
    ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
});
// *** End Development Only Warning ***

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
else
{
    // Add developer exception page for easier debugging
    app.UseDeveloperExceptionPage();
}


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"); // Default to Home/Index

app.Run();