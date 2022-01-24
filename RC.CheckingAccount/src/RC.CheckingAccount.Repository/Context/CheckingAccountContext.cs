using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;

namespace RC.CheckingAccount.Repository.Context
{
    public class CheckingAccountContext : DbContext
    {
        public CheckingAccountContext(DbContextOptions options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore(typeof(ValidationResult));

            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}