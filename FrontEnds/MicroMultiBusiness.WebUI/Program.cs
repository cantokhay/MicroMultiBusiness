using MicroMultiBusiness.WebUI.Handlers;
using MicroMultiBusiness.WebUI.Services.Abstract;
using MicroMultiBusiness.WebUI.Services.CatalogServices.CategoryServices;
using MicroMultiBusiness.WebUI.Services.Concrete;
using MicroMultiBusiness.WebUI.Settings;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddCookie(JwtBearerDefaults.AuthenticationScheme, options =>
//{
//    options.LoginPath = "/Login/Index";
//    options.LogoutPath = "/Login/Logout";
//    options.AccessDeniedPath = "/Pages/AccessDenied/";
//    options.Cookie.HttpOnly = true;
//    options.Cookie.SameSite = SameSiteMode.Strict;
//    options.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
//    options.Cookie.Name = "MicroMultiBusinessJwt";
//});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, opt =>
                {
                    opt.LoginPath = "/Login/Index";
                    opt.ExpireTimeSpan = TimeSpan.FromMinutes(60);
                    opt.Cookie.Name = "MicroMultiBusinessCookie";
                    opt.SlidingExpiration = true;
                });

builder.Services.AddAccessTokenManagement();

builder.Services.AddHttpContextAccessor();

builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddHttpClient<IIdentityService, IdentityService>();

builder.Services.AddHttpClient();
builder.Services.AddControllersWithViews();

builder.Services.Configure<ClientSettings>(builder.Configuration.GetSection("ClientSettings"));
builder.Services.Configure<ServiceAPISettings>(builder.Configuration.GetSection("ServiceAPISettings"));

builder.Services.AddScoped<ResourceOwnerPasswordTokenHandler>();

builder.Services.AddScoped<ClientCredentialTokenHandler>();
builder.Services.AddHttpClient<IClientCredentialTokenService, ClientCredentialTokenService>();

var values = builder.Configuration.GetSection("ServiceAPISettings").Get<ServiceAPISettings>();

builder.Services.AddHttpClient<IUserService, UserService>(opt =>
{
    opt.BaseAddress = new Uri(values.IdentityServerURL);
}).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

builder.Services.AddHttpClient<ICategoryService, CategoryService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotURL}/{values.Catalog.Path}");
}).AddHttpMessageHandler<ClientCredentialTokenHandler>();

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
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});

app.Run();
