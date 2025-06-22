using GL.CompanyCatalog.Application.Contracts.Infrastructure;
using GL.CompanyCatalog.Application.Models.Mail;
using GL.CompanyCatalog.Infrastructure.FileExport;
using GL.CompanyCatalog.Infrastructure.Mail;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GL.CompanyCatalog.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));

            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<ICsvExporter, CsvExporter>();

            return services;
        }
    }
}
