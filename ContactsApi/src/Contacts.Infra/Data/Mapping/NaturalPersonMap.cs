using Contacts.Infra.Data.DBOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Contacts.Infra.Data.Mapping
{
    public class NaturalPersonMap : IEntityTypeConfiguration<NaturalPersonDBO>
    {
        public void Configure(EntityTypeBuilder<NaturalPersonDBO> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Address);
        }
    }
}
