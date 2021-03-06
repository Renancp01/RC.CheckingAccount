using System;
using System.Collections.Generic;
using RC.CheckingAccount.Domain.Entities.Base;

namespace RC.CheckingAccount.Domain.Entities
{
    public class Client : Entity
    {
        public Client(Guid id,string name, string lastName)
        {
            Id = id;
            Name = name;
            LastName = lastName;
        }

        public Client(string name, string lastName)
        {
            Name = name;
            LastName = lastName;
        }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string FullName => $"{Name} {LastName}";

        public ICollection<Credit> Credits { get; set; }

        public ICollection<Debit> Debits { get; set; }
    }
}