using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RC.CheckingAccount.Domain.Entities;

namespace RC.CheckingAccount.Repository.EntityConfig
{
    public class ClientConfig : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Ignore(c => c.IsValid);

            builder.ToTable("Clients");
        }
    }
}
