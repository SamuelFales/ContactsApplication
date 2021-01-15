using Contacts.Infra.Data.DBOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Contacts.Infra.Data.Mapping
{
    public class LegalPersonMap : IEntityTypeConfiguration<LegalPersonDBO>
    {
        public void Configure(EntityTypeBuilder<LegalPersonDBO> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Address);
        }
    }
}
