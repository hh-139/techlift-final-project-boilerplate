using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.Data;
using TechLift.FinalProject;

var builder = WebApplication.CreateBuilder(args);

var startup = new Startup(builder.Configuration);
startup.ConfigureServices(builder.Services);

var app = builder.Build();

startup.Configure(app, builder.Environment);

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var applicationDbContext = services.GetRequiredService<ApplicationDbContext>();
        if (applicationDbContext.Database.IsSqlServer())
        {
            await applicationDbContext.Database.MigrateAsync();
        }
    }
    catch (Exception)
    {
        throw;
    }
    await app.RunAsync();
}



