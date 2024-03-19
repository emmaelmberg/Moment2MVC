var builder = WebApplication.CreateBuilder(args);

// Aktivera MVC
builder.Services.AddControllersWithViews();

// Aktivera sessions
builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(5);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

// För att kunna använda statiska filer
app.UseStaticFiles();

// Routing
app.UseRouting();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

// För att kunna använda sessions
app.UseSession();

app.Run();