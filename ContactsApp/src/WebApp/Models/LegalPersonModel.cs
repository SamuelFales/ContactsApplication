using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Utils.CustomValidators;

namespace WebApp.Models
{
    public class LegalPersonModel
    {
        [Key]
        public int? Id { get; set; }

        [Required(ErrorMessage = "Company Name is required ")]
        public string CompanyName { get;  set; }
        public string TradeName { get;  set; }

        [CustomValidatorCNPJ]
        [Required(ErrorMessage = "CNPJ is required ")]
        public string CNPJ { get;  set; }
        public AddressModel Address { get; set; }
    }
}
