using GL.CompanyCatalog.Api.Middleware;
using GL.CompanyCatalog.Api.Services;
using GL.CompanyCatalog.Application;
using GL.CompanyCatalog.Application.Contracts;
using GL.CompanyCatalog.Identity;
using GL.CompanyCatalog.Identity.Models;
using GL.CompanyCatalog.Infrastructure;
using GL.CompanyCatalog.Persistence;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace GL.CompanyCatalog.Api
{
    public static class StartupExtensions
    {
        public static WebApplication ConfigureServices(
            this WebApplicationBuilder builder)
        {
            builder.Services.AddApplicationServices();
            builder.Services.AddInfrastructureServices(builder.Configuration);
            builder.Services.AddPersistenceServices(builder.Configuration);
            builder.Services.AddIdentityServices(builder.Configuration);

            builder.Services.AddScoped<ILoggedInUserService, LoggedInUserService>();

            builder.Services.AddHttpContextAccessor();

            builder.Services.AddControllers();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("OPEN", policy =>
                {
                    policy.WithOrigins(
                            "http://localhost:7080"
                        )
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials()
                        .WithExposedHeaders("Content-Disposition");
                });
            });

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            return builder.Build();
        }

        public static WebApplication ConfigurePipeline(this WebApplication app)
        {
            app.MapIdentityApi<ApplicationUser>();

            app.MapPost("/Logout", async (ClaimsPrincipal user, SignInManager<ApplicationUser> signInManager) =>
            {
                await signInManager.SignOutAsync();
                return TypedResults.Ok();
            });

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCustomExceptionHandler();

            if (app.Environment.IsProduction())
            {
                app.UseHttpsRedirection();
            }
            

            app.UseCors("OPEN"); // MORA posle UseHttpsRedirection, a pre autorizacije

            app.UseAuthentication(); // ako koristiš autorizaciju
            app.UseAuthorization();

            app.MapControllers();

            return app;
        }


        public static async Task ResetDatabaseAsync(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
            try
            {
                var context = scope.ServiceProvider.GetService<GLDbContext>();
                if (context != null)
                {
                    await context.Database.EnsureDeletedAsync();
                    await context.Database.MigrateAsync();
                }

                var identityContext = scope.ServiceProvider.GetRequiredService<GLIdentityDbContext>();
                if (identityContext != null)
                {
                    await identityContext.Database.EnsureDeletedAsync();
                    await identityContext.Database.MigrateAsync();
                }
            }
            catch (Exception ex)
            {
                logger.LogError("ResetDatabaseAsync error: " + ex.Message);
            }
        }
    }
}
