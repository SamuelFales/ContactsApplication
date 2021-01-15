using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Services.Interfaces.Base
{
    public interface IPersonService
    {
        public interface IPersonService<T> where T : class
        {
            Task<bool> Save(T person);
            Task<IEnumerable<T>> GetAll();
            Task<T> GetById(int personId);
            Task<bool> Update(T person);
            bool Delete(int personId);
        }
    }
}
