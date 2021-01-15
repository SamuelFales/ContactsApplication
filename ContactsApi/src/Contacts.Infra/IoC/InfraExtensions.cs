using Contacts.Infra.Data.Context;
using Contacts.Infra.Data.Repository;
using Contacts.Infra.Data.Repository.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Contacts.Infra.IoC
{
    public static class InfraExtensions
    {
        public static void AddInfraExtesions(this IServiceCollection services)
        {
            services.AddScoped<ContactSqliteDbContext>();
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<INaturalPersonRepository, NaturalPersonRepository>();
            services.AddScoped<ILegalPersonRepository, LegalPersonRepository>();
        }
    }
}
