using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Utils.CustomValidators;

namespace WebApp.Models
{
    public class NaturalPersonModel
    {
        [Key]
        public int? Id { get; set; }
        [Required(ErrorMessage = "Name is required ")]
        public string Name { get;  set; }

        [CustomValidationCPF]
        [Required(ErrorMessage = "CPF is required ")]
        public string CPF { get;  set; }
        public char Gender { get;  set; }
        public DateTime? Birthday { get;  set; }
        public AddressModel Address { get; set; }

    }
}
