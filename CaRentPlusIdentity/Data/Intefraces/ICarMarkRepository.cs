using CaRentPlusIdentity.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaRentPlusIdentity.Data.Intefraces
{
    public interface ICarMarkRepository : IRepository<CarMark>
    {
        // znajdź wszystkie marki z ich nazwami
        IEnumerable<CarMark> GetAllWithCars();
        // znajdź jedną markę po jej samochodzie
        CarMark GetWithCars(int id);
    }
}
