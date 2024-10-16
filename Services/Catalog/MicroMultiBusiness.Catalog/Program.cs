using MicroMultiBusiness.Catalog.Services.AboutServices;
using MicroMultiBusiness.Catalog.Services.BrandServices;
using MicroMultiBusiness.Catalog.Services.CategoryServices;
using MicroMultiBusiness.Catalog.Services.ContactServices;
using MicroMultiBusiness.Catalog.Services.FeatureServices;
using MicroMultiBusiness.Catalog.Services.FeatureSliderServices;
using MicroMultiBusiness.Catalog.Services.OfferDiscountServices;
using MicroMultiBusiness.Catalog.Services.ProductDetailServices;
using MicroMultiBusiness.Catalog.Services.ProductImageServices;
using MicroMultiBusiness.Catalog.Services.ProductServices;
using MicroMultiBusiness.Catalog.Services.SpecialOfferServices;
using MicroMultiBusiness.Catalog.Services.StatisticServices;
using MicroMultiBusiness.Catalog.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
    {
        options.Authority = builder.Configuration["IdentityServerUrl"]; //goes to appssettings.json
        options.Audience = "ResourceCatalog"; //comes from IdentityServer Config.cs
        options.RequireHttpsMetadata = false;
    });

builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductDetailService, ProductDetailService>();
builder.Services.AddScoped<IProductImageService, ProductImageService>();
builder.Services.AddScoped<IFeatureSliderService, FeatureSliderService>();
builder.Services.AddScoped<IFeatureService, FeatureService>();
builder.Services.AddScoped<IOfferDiscountService, OfferDiscountService>();
builder.Services.AddScoped<IBrandService, BrandService>();
builder.Services.AddScoped<IAboutService, AboutService>();
builder.Services.AddScoped<IContactService, ContactService>();
builder.Services.AddScoped<ISpecialOfferService, SpecialOfferService>();
builder.Services.AddScoped<IStatisticService, StatisticService>();

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("DatabaseSettings"));

builder.Services.AddScoped<IDatabaseSettings>(sp =>
{
    return sp.GetRequiredService<IOptions<DatabaseSettings>>().Value;
});

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
