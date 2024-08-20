using Ocelot.DependencyInjection;
using Ocelot.Middleware;
var builder = WebApplication.CreateBuilder(args);
//moved build method from here

#region Codes added
builder.Services.AddAuthentication().AddJwtBearer("OcelotAuthenticationScheme", options =>
{
    options.Authority = builder.Configuration["IdentityServerUrl"]; //goes to appssettings.json
    options.Audience = "ResourceOcelot"; //comes from IdentityServer Config.cs
    options.RequireHttpsMetadata = false;
});
IConfiguration configuration = new ConfigurationBuilder().AddJsonFile("ocelot.json").Build();
builder.Services.AddOcelot(configuration);
var app = builder.Build();

await app.UseOcelot();

#endregion

app.MapGet("/", () => "Hello World!");

app.Run();
