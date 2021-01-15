using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Services.Interfaces;

namespace WebApp.Services.IoC
{
    public static class ServicesExtensions
    {
        public static void AddServicesExtensions(this IServiceCollection services)
        {
            services.AddScoped<INaturalPersonService, NaturalPersonService>();
            services.AddScoped<ILegalPersonService, LegalPersonService>();
        }
    }
}
