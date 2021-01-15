using Contacts.Infra.Data.Context;
using Contacts.Infra.Data.DBOs;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Contacts.Infra.Data.Repository.Interfaces;

namespace Contacts.Infra.Data.Repository
{
    public class LegalPersonRepository : ILegalPersonRepository
    {
        private readonly ContactSqliteDbContext _context;

        public LegalPersonRepository(ContactSqliteDbContext context)
        {
            _context = context;
        }

        public bool Delete(int id)
        {
            var entity = _context.LegalPerson.Find(id);
            if (entity == null)
            {
                return false;
            }

            _context.LegalPerson.Remove(entity);
            var result = _context.SaveChanges();

            return result >= 1;
        }

        public async Task<IEnumerable<LegalPersonDBO>> GetAllAsync()
        {
            return await _context.LegalPerson.Include(x => x.Address).ToListAsync();
        }

        public async Task<LegalPersonDBO> GetByIdAsync(int id)
        {
            return await _context.LegalPerson.Include(x => x.Address)
                                             .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<LegalPersonDBO> SaveAsync(LegalPersonDBO entity)
        {
           var result =  _context.LegalPerson.Add(entity);
           await _context.SaveChangesAsync();

            return result.Entity;
        }


        public async Task<bool> UpdateAsync(LegalPersonDBO entity)
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
