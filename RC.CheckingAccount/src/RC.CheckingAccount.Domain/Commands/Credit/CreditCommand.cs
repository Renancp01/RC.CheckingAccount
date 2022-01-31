﻿using System;
using RC.CheckingAccount.Domain.Commom;

namespace RC.CheckingAccount.Domain.Commands.Credit
{
    public abstract class CreditCommand : Command
    {
        public Guid Id { get; protected set; }
        
        public Guid ClientId { get; protected set; }
        
        public decimal Value { get; protected set; }
    }
}