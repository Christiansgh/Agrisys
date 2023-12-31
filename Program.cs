using Agrisys.Utils;
using Agrisys.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<DatabaseContext>(options => {
    options.UseSqlite(builder.Configuration.GetConnectionString("ConnectionString"));
    options.EnableSensitiveDataLogging();
});

// Configure the DbContext for Identity
builder.Services.AddDbContext<IdentityContext>(opts => {
    opts.UseSqlite(builder.Configuration.GetConnectionString("ConnectionString"));
});

// Add DI for Home
builder.Services.AddDbContext<HomeDbContext>(opts => {
    _ = opts.UseSqlite(builder.Configuration.GetConnectionString("ConnectionString"));
}); 
builder.Services.AddScoped<IHomeRepository, EFHomeRepository>();

// Configure ASP.NET Core Identity
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<IdentityContext>();

// Register repository
builder.Services.AddScoped<IRepository, EFRepository>();

var app = builder.Build();

using (var scope = app.Services.CreateScope()) {
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    SeedData.SeedRoles(roleManager);
}

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

Logger.Init("Log");
SeedData.EnsurePopulated(app);

app.Run();
