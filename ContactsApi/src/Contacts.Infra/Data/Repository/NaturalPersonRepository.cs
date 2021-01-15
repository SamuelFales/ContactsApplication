using Contacts.Infra.Data.Context;
using Contacts.Infra.Data.DBOs;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Contacts.Infra.Data.Repository.Interfaces;

namespace Contacts.Infra.Data.Repository
{
    public class NaturalPersonRepository : INaturalPersonRepository
    {
        private readonly ContactSqliteDbContext _context;

        public NaturalPersonRepository(ContactSqliteDbContext context)
        {
            _context = context;
        }

        public bool Delete(int id)
        {
            var entity = _context.NaturalPerson.Find(id);
            if (entity == null)
            {
                return false;
            }

            _context.NaturalPerson.Remove(entity);
            var result = _context.SaveChanges();

            return result >= 1;
        }

        public async Task<IEnumerable<NaturalPersonDBO>> GetAllAsync()
        {
            return await _context.NaturalPerson.Include(x => x.Address).ToListAsync();
        }

        public async Task<NaturalPersonDBO> GetByIdAsync(int id)
        {
            return await _context.NaturalPerson.Include(x => x.Address)
                                               .FirstOrDefaultAsync( x => x.Id == id);
        }

        public async Task<NaturalPersonDBO> SaveAsync(NaturalPersonDBO entity)
        {
           var result =  _context.NaturalPerson.Add(entity);
           await _context.SaveChangesAsync();

            return result.Entity;
        }


        public async Task<bool> UpdateAsync(NaturalPersonDBO entity)
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
