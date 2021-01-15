
namespace Contacts.Infra.Data.DBOs
{
    public class LegalPersonDBO
    {
        public int? Id { get; set; }
        public string CompanyName { get; set; }
        public string TradeName { get; set; }
        public string CNPJ { get; set; }
        public int? AddressId { get; set; }
        public AddressDBO Address { get; set; }
    }
}

