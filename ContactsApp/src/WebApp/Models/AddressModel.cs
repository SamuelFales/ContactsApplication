using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class AddressModel
    {
        [Key]
        public int? Id { get; set; }
        [Required(ErrorMessage = "ZipCode is required ")]
        public string ZipCode { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public AddressLineModel AddressLine { get; set; }

    }
    public class AddressLineModel
    {
        public string Line1 { get; set; }
        public string Line2 { get; set; }
    }
}
