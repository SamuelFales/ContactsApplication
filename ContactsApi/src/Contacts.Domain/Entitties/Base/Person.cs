using Contacts.Domain.Enums;

namespace Contacts.Domain.Entities
{
    public class Person
    {
        public int? Id { get; set; }
        public PersonType Type { get; set; }
        public Address Address { get; set; }
    }   
}
