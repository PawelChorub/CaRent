using CaRentPlusIdentity.Data.Intefraces;
using CaRentPlusIdentity.Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaRentPlusIdentity.Data.Repository
{
    public class CarRepository : Repository<Car>, ICarRepository
    {

        public CarRepository(ApplicationDbContext context) : base(context)
        {

        }
        public IEnumerable<Car> FindWithCarMark(Func<Car, bool> predicate)
        {                       //EF
            return _context.Cars.Include(a => a.CarMark).Where(predicate);
        }

        public IEnumerable<Car> FindWithCarMarkAndBorrower(Func<Car, bool> predicate)
        {
            return _context.Cars
                .Include(a => a.CarMark)
                .Include(a => a.Borrower)
                .Where(predicate);
        }

        public IEnumerable<Car> GetAllWithCarMark()
        {
            return _context.Cars.Include(a => a.CarMark);
        }
    }
}
