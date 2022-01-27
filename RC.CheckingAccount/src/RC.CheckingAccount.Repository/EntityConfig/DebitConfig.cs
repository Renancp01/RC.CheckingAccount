using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RC.CheckingAccount.Domain.Entities;

namespace RC.CheckingAccount.Repository.EntityConfig
{
    public class DebitConfig : IEntityTypeConfiguration<Debit>
    {
        public void Configure(EntityTypeBuilder<Debit> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Value).HasPrecision(18, 2);
            
            builder.ToTable("Debits");
        }
    }
}