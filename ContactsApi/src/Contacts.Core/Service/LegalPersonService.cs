using Contacts.Core.Service.Interfaces;
using Contacts.Domain.Entities;
using Contacts.Infra.Data.DBOs;
using Contacts.Infra.Data.Repository.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contacts.Core.Service
{
    public class LegalPersonService : ILegalPersonService
    {
        private readonly ILegalPersonRepository _legalPersonRepository;
        private readonly IAddressRepository _addressRepository;

        public LegalPersonService(ILegalPersonRepository legalPersonRepository,
                                    IAddressRepository addressRepository)
        {
            _legalPersonRepository = legalPersonRepository;
            _addressRepository = addressRepository;
        }

        public bool Delete(int personId)
        {
            return _legalPersonRepository.Delete(personId);
        }

        public async Task<IEnumerable<LegalPerson>> GetAll()
        {
            var personDBO = await _legalPersonRepository.GetAllAsync();
            return personDBO != null ? MappingToEntities(personDBO) : null;
        }

        public async Task<LegalPerson> GetById(int personId)
        {
            var personDBO = await _legalPersonRepository.GetByIdAsync(personId);
            return personDBO != null ? MappingToEntitie(personDBO) : null;
        }

        public async Task<bool> Save(LegalPerson person)
        {
            var personDbo = MappingToDBO(person);

            await _addressRepository.SaveAsync(personDbo.Address).ConfigureAwait(false);
            var personResult = await _legalPersonRepository.SaveAsync(personDbo).ConfigureAwait(false);

            return personResult != null;
        }

        public async Task<bool> Update(LegalPerson person)
        {
            var personDbo = MappingToDBO(person);

            await _addressRepository.UpdateAsync(personDbo.Address).ConfigureAwait(false);
            return await _legalPersonRepository.UpdateAsync(personDbo).ConfigureAwait(false);

        }

        private LegalPersonDBO MappingToDBO(LegalPerson person)
        {
            AddressDBO address = new AddressDBO()
            {
                Id = person.Address.Id,
                City = person.Address.City,
                Country = person.Address.Country,
                ZipCode = person.Address.ZipCode,
                State = person.Address.State,
                Line1 = person.Address.AddressLine.Line1,
                Line2 = person.Address.AddressLine.Line2
            };

            LegalPersonDBO dbo = new LegalPersonDBO()
            {
                Id = person.Id,
                CompanyName = person.CompanyName,
                TradeName = person.TradeName,
                CNPJ = person.CNPJ,
                Address = address,
                AddressId = address.Id
            };
            return dbo;
        }

        private static List<LegalPerson> MappingToEntities(IEnumerable<LegalPersonDBO> naturalPersonsDBO)
        {
            List<LegalPerson> naturalPersons = new List<LegalPerson>();

            foreach (var item in naturalPersonsDBO)
            {
                LegalPerson np = MappingToEntitie(item);

                naturalPersons.Add(np);
            }
            return naturalPersons;
        }

        private static LegalPerson MappingToEntitie(LegalPersonDBO item)
        {
            return new LegalPerson(item.Id, item.CompanyName, item.TradeName, item.CNPJ)
            {
                Address = new Address
                {
                    Id = item.Address.Id,
                    City = item.Address.City,
                    Country = item.Address.Country,
                    State = item.Address.State,
                    ZipCode = item.Address.ZipCode,
                    AddressLine = new AddressLine
                    {
                        Line1 = item.Address.Line1,
                        Line2 = item.Address.Line2,
                    }
                }
            };
        }
    }
}
