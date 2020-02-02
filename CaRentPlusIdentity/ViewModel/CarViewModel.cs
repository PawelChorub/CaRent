using CaRentPlusIdentity.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaRentPlusIdentity.ViewModel
{
    public class CarViewModel
    {
        public Car Car { get; set; }
        public IEnumerable<CarMark> CarMarks { get; set; }
    }
}
