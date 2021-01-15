using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contacts.Infra.Data.Repository.Interfaces.Base
{
    public interface IRepositoryBase<T> where T : class
    {
        Task<T> SaveAsync(T entity);
        Task<bool> UpdateAsync(T entity);
        bool Delete(int id);
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
    }
}
