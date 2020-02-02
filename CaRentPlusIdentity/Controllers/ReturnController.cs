using CaRentPlusIdentity.Data.Intefraces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaRentPlusIdentity.Controllers
{
    [Authorize]
    public class ReturnController : Controller
    {
        private readonly ICarRepository _carRepository;
        private readonly ICustomerRepository _customerRepository;

        public ReturnController(ICarRepository carRepository, ICustomerRepository customerRepository)
        {
            _carRepository = carRepository;
            _customerRepository = customerRepository;
        }
        [Route("Return")]
        public IActionResult List()
        {
            var borrowedCars = _carRepository.FindWithCarMarkAndBorrower(x => x.BorrowerId != 0);
            if (borrowedCars == null || borrowedCars.ToList().Count() == 0)
            {
                return View("Empty");
            }
            return View(borrowedCars);
        }

        public IActionResult ReturnACar(int carId)
        {
            var car = _carRepository.GetById(carId);
            car.Borrower = null;

            car.BorrowerId = 0;
            _carRepository.Update(car);

            return RedirectToAction("List");
        }
    }
}
