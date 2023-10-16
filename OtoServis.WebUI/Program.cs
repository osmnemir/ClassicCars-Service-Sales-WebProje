using OtoServis.Data;
using OtoServis.Service.Abstract;
using OtoServis.Service.Concrete;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<DatabaseContext>();
builder.Services.AddTransient(typeof(IService<>),typeof(Service<>)); // web u�de Iserviceyi kullanmak i�in serviste addtranslate metodu ile ekledik. ara katman� kullanmas� i�in gerekli yap�.
builder.Services.AddTransient<ICarService,Car>(); // web u�de Iserviceyi kullanmak i�in serviste addtranslate metodu ile ekledik. ara katman� kullanmas� i�in gerekli yap�.
builder.Services.AddTransient<IUserService,User>(); // web u�de Iserviceyi kullanmak i�in serviste addtranslate metodu ile ekledik. ara katman� kullanmas� i�in gerekli yap�.
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(x=>
{ // admin giri� i�in gerekli identity
    x.LoginPath = "/Account/Login";
    x.AccessDeniedPath = "/AccessDenied";
    x.LogoutPath = "/Account/Logout";
    x.Cookie.Name = "Admin";
    x.Cookie.MaxAge = TimeSpan.FromDays(1);
    x.Cookie.IsEssential = true;

});

builder.Services.AddAuthorization(x =>  // admin ve user giri� yapabilir
{
    //x.AddPolicy("AdminPolicy", policy => policy.RequireClaim("Role", "Admin"));
    //x.AddPolicy("UserPolicy", policy => policy.RequireClaim("Role", "Admin", "User"));
    //x.AddPolicy("CustomerPolicy", policy => policy.RequireClaim("Role", "Admin", "User", "Customer"));

    x.AddPolicy("AdminPolicy", policy => policy.RequireClaim(ClaimTypes.Role, "Admin"));
    x.AddPolicy("UserPolicy", policy => policy.RequireClaim(ClaimTypes.Role, "Admin", "User"));
    x.AddPolicy("CustomerPolicy", policy => policy.RequireClaim(ClaimTypes.Role, "Admin", "User", "Customer"));


});
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
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
            name: "admin",
            pattern: "{area:exists}/{controller=Main}/{action=Index}/{id?}"
          );

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
