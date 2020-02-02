using CaRentPlusIdentity.Data.Intefraces;
using CaRentPlusIdentity.Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaRentPlusIdentity.Data.Repository
{
    // niezbędne metody----wszystkie metody
    public class CarMarkRepository : Repository<CarMark>, ICarMarkRepository
    {
        // konstruktor obowiązkowy!
        public CarMarkRepository(ApplicationDbContext context) : base(context)
        {

        }
        public IEnumerable<CarMark> GetAllWithCars()
        {                               //EF
            return _context.CarMarks.Include(a => a.Cars);
        }

        public CarMark GetWithCars(int id)
        {
            return _context.CarMarks
                .Where(a => a.CarMarkId == id)
                .Include(a => a.Cars)
                .FirstOrDefault();
        }
    }
}
