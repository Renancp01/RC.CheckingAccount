using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RC.CheckingAccount.Application.ViewModels
{
    public class CreditViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "The ClientId is Required")]
        [DisplayName("ClientId")]
        public Guid ClientId { get; set; }

        [Required(ErrorMessage = "The Value is Required")]
        [DisplayName("Value")]
        public decimal Value { get; set; }
    }
}