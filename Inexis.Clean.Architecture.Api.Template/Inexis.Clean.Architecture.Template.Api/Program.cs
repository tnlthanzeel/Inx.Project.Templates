using Inexis.Clean.Architecture.Template.Api;
using Inexis.Clean.Architecture.Template.Api.ServiceRegistrations;
using Inexis.Clean.Architecture.Template.Api.Services;
using Inexis.Clean.Architecture.Template.Core;
using Inexis.Clean.Architecture.Template.Infrastructure;
using Inexis.Clean.Architecture.Template.Persistence;
using Inexis.Clean.Architecture.Template.SharedKernal.Interfaces;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Swashbuckle.AspNetCore.SwaggerUI;

var builder = WebApplication.CreateBuilder(args);
{
    builder.AddSerilogConfig();

    var services = builder.Services;

    ConfigurationValidator.ValidateConfigurations(services);

    services.AddControllerConfig();

    services.AddSwaggerConfig();

    services.AddCorsConfig();

    services.AddCoreServices();
    services.AddInfrastructureServices(builder.Configuration);
    services.AddPersistenceServices(builder.Configuration);

    services.AddHttpContextAccessor();
    services.TryAddScoped<ILoggedInUserService, LoggedInUserService>();
    services.TryAddScoped<IApplicationContext, ApplicationContext>();


    services.AddIdentityConfig(builder);

    services.AddMemoryCache();
    services.AddOutputCache();

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

    app.UseDefaultFiles();
    app.UseStaticFiles();

    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        if (app.Environment.IsDevelopment())
        {
            c.EnablePersistAuthorization();
        }
        else
        {
            c.SupportedSubmitMethods(new SubmitMethod[] { });
        }

        c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        c.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.None);

    });

    app.UseHttpsRedirection();

    app.UseRouting();

    app.UseCors();

    app.UseOutputCache();

    app.UseAuthorization();

    app.MapControllers().RequireAuthorization();

    app.MapFallbackToFile("/index.html");

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

