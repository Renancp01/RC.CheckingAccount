using RC.CheckingAccount.Domain.Entities.Base;

namespace RC.CheckingAccount.Domain.Entities
{
    public class Debit : Entity
    {
        public decimal Value { get; set; }
    }
}
