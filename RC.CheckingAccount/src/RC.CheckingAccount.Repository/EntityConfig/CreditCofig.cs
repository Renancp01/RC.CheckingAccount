using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RC.CheckingAccount.Domain.Entities;

namespace RC.CheckingAccount.Repository.EntityConfig
{
    public class CreditCofig : IEntityTypeConfiguration<Credit>
    {
        public void Configure(EntityTypeBuilder<Credit> builder)
        {
            builder.HasKey(c => c.Id);

            builder.ToTable("Credits");
        }
    }
}