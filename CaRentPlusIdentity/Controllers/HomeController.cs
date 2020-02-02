using CaRentPlusIdentity.Data.Intefraces;
using CaRentPlusIdentity.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaRentPlusIdentity.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICarRepository _carRepository;
        private readonly ICarMarkRepository _carMarkRepository;
        private readonly ICustomerRepository _customerRepository;

        public HomeController(ICarRepository carRepository,
                              ICarMarkRepository carMarkRepository,
                              ICustomerRepository customerRepository)
        {
            _carRepository = carRepository;
            _carMarkRepository = carMarkRepository;
            _customerRepository = customerRepository;
        }

    public IActionResult Index()
    {
        var homeVM = new HomeViewModel()
        {
            CarMarkCount = _carMarkRepository.Count(x => true),
            CustomerCount = _customerRepository.Count(x => true),
            CarCount = _carRepository.Count(x => true),
            LendCarCount = _carRepository.Count(x => x.Borrower != null)
        };
        return View(homeVM);
    }
}
}
