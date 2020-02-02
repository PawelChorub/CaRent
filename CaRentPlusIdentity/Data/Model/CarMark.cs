using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CaRentPlusIdentity.Data.Model
{
    public class CarMark
    {
        // Aby EF użyło primary key musi być prop jak nazwa klasy z postfixem Id!
        public int CarMarkId { get; set; }
        [Required(ErrorMessage = "Podaj nazwę marki!"), MinLength(2), MaxLength(20)]
        public string Name { get; set; }
        // virtual pozwala EF na "lazy loading"
        public virtual ICollection<Car> Cars { get; set; }
    }
}
