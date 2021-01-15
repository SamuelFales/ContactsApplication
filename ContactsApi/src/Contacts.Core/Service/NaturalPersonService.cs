using Contacts.Core.Service.Interfaces;
using Contacts.Domain.Entities;
using Contacts.Infra.Data.DBOs;
using Contacts.Infra.Data.Repository.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contacts.Core.Service
{
    public class NaturalPersonService : INaturalPersonService
    {
        private readonly INaturalPersonRepository _naturalPersonRepository;
        private readonly IAddressRepository _addressRepository;

        public NaturalPersonService(INaturalPersonRepository naturalPersonRepository,
                                    IAddressRepository addressRepository)
        {
            _naturalPersonRepository = naturalPersonRepository;
            _addressRepository = addressRepository;
        }

        public bool Delete(int personId)
        {
            return _naturalPersonRepository.Delete(personId);
        }

        public async Task<IEnumerable<NaturalPerson>> GetAll()
        {
            var naturalPersonsDBO = await _naturalPersonRepository.GetAllAsync();
            return naturalPersonsDBO != null ? MappingToEntities(naturalPersonsDBO) : null;
        }

        public async Task<NaturalPerson> GetById(int personId)
        {
            var naturalPersonDBO = await _naturalPersonRepository.GetByIdAsync(personId);
            return naturalPersonDBO != null ? MappingToEntitie(naturalPersonDBO) : null;
        }

        public async Task<bool> Save(NaturalPerson person)
        {
            var personDbo = MappingToDBO(person);

            await _addressRepository.SaveAsync(personDbo.Address).ConfigureAwait(false);
            var personResult = await _naturalPersonRepository.SaveAsync(personDbo).ConfigureAwait(false);

            return personResult != null;
        }

        public async Task<bool> Update(NaturalPerson person)
        {
            var personDbo =  MappingToDBO(person);

            await _addressRepository.UpdateAsync(personDbo.Address).ConfigureAwait(false);
            return  await _naturalPersonRepository.UpdateAsync(personDbo).ConfigureAwait(false);

        }

        private  NaturalPersonDBO MappingToDBO(NaturalPerson person)
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

            NaturalPersonDBO dbo = new NaturalPersonDBO()
            {
                Id = person.Id,
                Name = person.Name,
                Birthday = person.Birthday,
                CPF = person.CPF,
                Gender = person.Gender,
                Address = address,
                AddressId = address.Id
            };
            return dbo;
        }

        private static List<NaturalPerson> MappingToEntities(IEnumerable<NaturalPersonDBO> naturalPersonsDBO)
        {
            List<NaturalPerson> naturalPersons = new List<NaturalPerson>();

            foreach (var item in naturalPersonsDBO)
            {
                NaturalPerson np = MappingToEntitie(item);

                naturalPersons.Add(np);
            }
            return naturalPersons;
        }

        private static NaturalPerson MappingToEntitie(NaturalPersonDBO item)
        {
            return new NaturalPerson(item.Id, item.Name, item.CPF, item.Gender, item.Birthday)
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
