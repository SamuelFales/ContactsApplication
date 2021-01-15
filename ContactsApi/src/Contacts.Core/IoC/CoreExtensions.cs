using Contacts.Core.Service;
using Contacts.Core.Service.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Contacts.Core.IoC
{
    public static class CoreExtensions
    {
        public static void AddCoreExtensions(this IServiceCollection services)
        {
            services.AddScoped<INaturalPersonService, NaturalPersonService>();
            services.AddScoped<ILegalPersonService, LegalPersonService>();
        }
    }
}
