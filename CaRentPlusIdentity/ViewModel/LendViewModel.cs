using CaRentPlusIdentity.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaRentPlusIdentity.ViewModel
{
    public class LendViewModel
    {
        public Car Car { get; set; }
        //[Required(ErrorMessage = "Musisz wybrać klienta!")]
        public IEnumerable<Customer> Customers { get; set; }
    }
}
