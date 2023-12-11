using Inexis.Clean.Architecture.Template.Api;
using Inexis.Clean.Architecture.Template.Api.ServiceRegistrations;
using Inexis.Clean.Architecture.Template.Api.Services;
using Inexis.Clean.Architecture.Template.Core;
using Inexis.Clean.Architecture.Template.Core.Security;
using Inexis.Clean.Architecture.Template.Infrastructure;
using Inexis.Clean.Architecture.Template.Persistence;
using Inexis.Clean.Architecture.Template.SharedKernal.Interfaces;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
{
    builder.AddSerilogConfig();

    builder.Host.UseSerilog();

    var services = builder.Services;

    services.AddControllerConfig();

    services.AddSwaggerConfig();

    services.AddCorsConfig();

    services.AddCoreServices();
    services.AddInfrastructureServices(builder.Configuration);
    services.AddPersistenceServices(builder.Configuration);

    services.AddHttpContextAccessor();
    services.AddScoped<ILoggedInUserService, LoggedInUserService>();
    services.AddScoped<IApplicationContext, ApplicationContext>();

    services.Configure<JwtConfig>(builder.Configuration.GetSection(nameof(JwtConfig)));

    services.AddIdentityConfig(builder);

    services.AddMemoryCache();

    services.AddExceptionHandler<GlobalExceptionHandler>();

}

var app = builder.Build();

{
    app.UseExceptionHandler(_ => { });

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment()) { }

    else
    {
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
    }

    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");

        c.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.None);

        if (app.Environment.IsDevelopment())
        {
            c.EnablePersistAuthorization();
        }
    });

    app.UseHttpsRedirection();

    app.UseStaticFiles();

    app.UseCors();

    app.MapControllers().RequireAuthorization();

    app.UseOutputCache();

    app.MapFallbackToFile("index.html");


    // Enable to run automatic migrations at debug mode
    //if (builder.Environment.IsDevelopment())
    //{
    //    using (var scope = app.Services.CreateScope())
    //    {
    //        try
    //        {
    //            var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    //            db.Database.Migrate();
    //        }
    //        catch (Exception ex)
    //        {
    //            Log.Error(ex, "An error occurred migrating the DB. {exceptionMessage}", ex.Message);
    //        }
    //    }
    //}
}

app.Run();

