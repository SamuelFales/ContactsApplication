using System;

namespace Contacts.Infra.Data.DBOs
{
    public class NaturalPersonDBO
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string CPF { get; set; }
        public char Gender { get; set; }
        public DateTime Birthday { get; set; }
        public int? AddressId { get; set; }
        public AddressDBO Address { get; set; }
    }
}
