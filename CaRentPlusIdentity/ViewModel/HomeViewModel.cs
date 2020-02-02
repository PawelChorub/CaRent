using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaRentPlusIdentity.ViewModel
{
    public class HomeViewModel
    {
        //dane do wyświetlania w widoku

        public int CustomerCount { get; set; }
        public int CarMarkCount { get; set; }
        public int CarCount { get; set; }
        public int LendCarCount { get; set; }

    }
}
