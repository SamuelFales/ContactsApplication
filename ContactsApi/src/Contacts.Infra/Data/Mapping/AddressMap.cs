using Contacts.Infra.Data.DBOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Contacts.Infra.Data.Mapping
{
    public class AddressMap : IEntityTypeConfiguration<AddressDBO>
    {
        public void Configure(EntityTypeBuilder<AddressDBO> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}
