using Microsoft.EntityFrameworkCore;
using SplitPurchases.Application;
using SplitPurchases.Application.Common.Mappings;
using SplitPurchases.Application.Interfaces;
using SplitPurchases.Persistence;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplication();

builder.Services.AddPersistence(builder.Configuration);


builder.Services.AddControllers();

builder.Services.AddAutoMapper(config => {
    config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
    config.AddProfile(new AssemblyMappingProfile(typeof(IApplicationDbContext).Assembly));
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("MyCorsPolicy", policy =>
    {
               policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var dbContext = services.GetRequiredService<ApplicationDbContext>();
    try
    {
         DbInitializer.Initialize(dbContext);
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "Error occured while initializing the database");
    }
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.UseCors("MyCorsPolicy");

app.MapControllers();

app.Run();