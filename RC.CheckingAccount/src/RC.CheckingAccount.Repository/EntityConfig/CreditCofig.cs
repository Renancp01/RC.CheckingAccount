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
           
            builder.Property(c => c.Value).HasPrecision(18, 2);

            builder.Ignore(c => c.IsValid);

            builder.ToTable("Credits");
        }
    }
}