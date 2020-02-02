using CaRentPlusIdentity.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaRentPlusIdentity.ViewModel
{
    public class CustomerViewModel
    {
        public Customer Customer { get; set; }
        public int CarCount { get; set; } // ile wypożyczył, dodać jakie wypożyczył
    }
}
