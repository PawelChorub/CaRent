using CaRentPlusIdentity.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaRentPlusIdentity.Data.Intefraces
{
    public interface ICarRepository : IRepository<Car>
    {
        IEnumerable<Car> GetAllWithCarMark();
        // znajdź z załadowanymi markami
        IEnumerable<Car> FindWithCarMark(Func<Car, bool> predicate);
        // znajdż z załadowanymi markami i wypożyczającymi
        IEnumerable<Car> FindWithCarMarkAndBorrower(Func<Car, bool> predicate);
    }
}
