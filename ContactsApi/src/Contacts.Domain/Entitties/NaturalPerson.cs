using Contacts.Domain.Enums;
using System;

namespace Contacts.Domain.Entities
{
    public class NaturalPerson : Person
    {

        public NaturalPerson(int? id, string name, string cpf, char gender, DateTime birthday)
        {
            Id = id;
            Type = PersonType.Natural;
            Name = name;
            CPF = cpf;
            Gender= gender;
            Birthday = birthday;
        }
        public string Name { get; private set; }
        public string CPF { get; private set; }
        public char Gender { get; private set; }
        public DateTime Birthday { get; private set; }
    }
}
