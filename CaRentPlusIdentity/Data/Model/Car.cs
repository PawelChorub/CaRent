using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CaRentPlusIdentity.Data.Model
{
    public class Car
    {
        public int CarId { get; set; }
        [Required(ErrorMessage = "Podaj nazwę modelu!"), MinLength(2), MaxLength(20)]
        public string CarModel { get; set; }

        // 2 relacje:
        // virtual pozwala EF na "lazy loading"
        // Id będą potrzebne do widoków
        public virtual CarMark CarMark { get; set; }
        public int CarMarkId { get; set; }

        public virtual Customer Borrower { get; set; }
        public int BorrowerId { get; set; }

    }
}
