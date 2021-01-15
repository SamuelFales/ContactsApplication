using Contacts.Domain.Enums;

namespace Contacts.Domain.Entities
{
    public class LegalPerson : Person
    {
        public LegalPerson(int? id, string companyName,string tradeName, string cnpj)
        {
            Id = id;
            Type = PersonType.Legal;
            CompanyName = companyName;
            TradeName = tradeName;
            CNPJ = cnpj;
        }

        public string CompanyName { get; private set; }
        public string TradeName { get; private set; }
        public string CNPJ { get; private set; }
    }
}
