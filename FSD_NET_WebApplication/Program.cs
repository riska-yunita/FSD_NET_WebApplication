using FSD_NET_WebApplication.Context;
using FSD_NET_WebApplication.Repository.Data;

using FSD_NET_WebApplication.Repository.Contracts;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//Add services to the container
builder.Services.AddControllersWithViews();

//Add Connection String
var ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<MyContext>(options =>
options.UseSqlServer(ConnectionString));

//Configure Services for Dependency Injection
builder.Services.AddScoped<IUniversitiesRepository, UniversitiesRepository>();
builder.Services.AddScoped<IRolesRepository,RolesRepository>();
builder.Services.AddScoped<IProfilingsRepository,ProfilingsRepository>();
builder.Services.AddScoped<IEmployeesRepository,EmployeesRepository>();
builder.Services.AddScoped<IEducationsRepository, EducationsRepository>();
builder.Services.AddScoped<IAccountsRepository,AccountsRepository>();
builder.Services.AddScoped<IAccountRolesRepository, AccountsRolesRepository>();

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
