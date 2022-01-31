using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using RC.CheckingAccount.Domain.Entities;

namespace RC.CheckingAccount.Application.ViewModels
{
    public class ClientViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "The Name is Required")]
        [MinLength(2)]
        [MaxLength(100)]
        [DisplayName("Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The Lastname is Required")]
        [MinLength(2)]
        [MaxLength(100)]
        [DisplayName("Lastname")]
        public string LastName { get; set; }

        public string FullName => $"{Name} {LastName}";
    }
}