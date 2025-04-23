using OurNotificationAPP.Services;
using OurNotificationAPP.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Register notification services
builder.Services.AddSingleton<NotificationLogService>(); // Use singleton for demo to persist logs
builder.Services.AddScoped<EmailNotificationService>();
builder.Services.AddScoped<SmsNotificationService>();
builder.Services.AddScoped<INotificationService, EmailNotificationService>(); // Default service
builder.Services.AddScoped<NotificationFactory>();

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
app.MapStaticAssets();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();