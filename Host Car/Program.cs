using Host_Car.DataAccess;
using Host_Car.DataAccess.Repository;
using Host_Car.DataAccess.Repository.IRepository;
using Host_Car.Utility;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Stripe;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("HostCarConnection") ?? throw new InvalidOperationException("Connection string 'HostCarConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(
    o => o.UseLazyLoadingProxies()
    .UseSqlServer(connectionString));
builder.Services.AddScoped<IPreOrderSearchRepository, PreOrderSearchRepository>();
builder.Services.Configure<StripeConfig>(builder.Configuration.GetSection("Stripe"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();
builder.Services.AddDistributedMemoryCache();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
StripeConfiguration.ApiKey = builder.Configuration.GetSection("Stripe: SecretKey").Get<string>();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Rent}/{action=PreOrderSearch}/{id?}");
app.MapRazorPages();

app.Run();
