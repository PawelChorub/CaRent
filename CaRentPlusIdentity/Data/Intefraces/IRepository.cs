using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaRentPlusIdentity.Data.Intefraces
{
    //Wzorzec repozytorium
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        // Filtruje i szuka obiekt na podstawie właściwości obiektu
        IEnumerable<T> Find(Func<T, bool> predicate);
        T GetById(int id);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        int Count(Func<T, bool> predicate);
    }
}
