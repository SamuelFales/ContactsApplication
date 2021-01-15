using Contacts.Infra.Data.Context;
using Contacts.Infra.Data.DBOs;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Contacts.Infra.Data.Repository.Interfaces;

namespace Contacts.Infra.Data.Repository
{
    public class AddressRepository : IAddressRepository
    {
        private readonly ContactSqliteDbContext _context;

        public AddressRepository(ContactSqliteDbContext context)
        {
            _context = context;
        }

        public bool Delete(int id)
        {
            var entity = _context.Address.Find(id);
            if (entity == null)
            {
                return false;
            }

            _context.Address.Remove(entity);
            var result = _context.SaveChanges();

            return result >= 1;
        }

        public async Task<IEnumerable<AddressDBO>> GetAllAsync()
        {
            return await _context.Address.ToListAsync();
        }

        public async Task<AddressDBO> GetByIdAsync(int id)
        {
            return await _context.Address.FindAsync(id);
        }

        public async Task<AddressDBO> SaveAsync(AddressDBO entity)
        {
            var result = _context.Address.Add(entity);
            await _context.SaveChangesAsync();

            return result.Entity;
        }


        public async Task<bool> UpdateAsync(AddressDBO entity)
        {
            _context.Entry(entity).State = EntityState.Modified;

            try
            {
                var result = await _context.SaveChangesAsync();
                return result >= 1;
            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }
        }
    }
}
