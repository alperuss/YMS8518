using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Login.Interfaces
{
    public interface IRepository<T> where T : class
    {
        T Insert(T model);
        T Update(T model);
        void Delete(int id);
        List<T> GetAll();
        T GetById(int id);
    }
}
