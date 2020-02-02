using CaRentPlusIdentity.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaRentPlusIdentity.ViewModel
{
    public class CreateCarMarkViewModel
    {
        // przepływ danych pomiędzy CarMarkContoller a CreateView i spowroem
        public CarMark CarMark { get; set; }
        public string Referer { get; set; } //  przechwytuje ścieżkę do powrotu
    }
}
