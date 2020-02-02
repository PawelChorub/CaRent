using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CaRentPlusIdentity.Data.Model
{
    public class Customer
    {
        public int CustomerId { get; set; }     // entity zrozumie z postfixem, że to ID
        [Required(ErrorMessage = "Podaj nazwę klienta!"), MinLength(2), MaxLength(20)]
        public string Name { get; set; }
    }
}
