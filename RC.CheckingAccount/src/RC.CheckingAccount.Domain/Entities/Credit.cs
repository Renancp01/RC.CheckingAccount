using RC.CheckingAccount.Domain.Entities.Base;

namespace RC.CheckingAccount.Domain.Entities
{
    public class Credit : Entity
    {
        public decimal Value { get; set; }
    }
}