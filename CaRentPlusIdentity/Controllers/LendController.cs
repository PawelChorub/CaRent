using CaRentPlusIdentity.Data.Intefraces;
using CaRentPlusIdentity.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaRentPlusIdentity.Controllers
{
    [Authorize]
    public class LendController : Controller
    {
        private readonly ICarRepository _carRepository;
        private readonly ICustomerRepository _customerRepository;

        public LendController(ICarRepository carRepository, ICustomerRepository customerRepository)
        {
            _carRepository = carRepository;
            _customerRepository = customerRepository;
        }
        [Route("Lend")]
        public IActionResult List()
        {
            var availableCars = _carRepository.FindWithCarMark(x => x.BorrowerId == 0);
            if (availableCars.Count() == 0)
            {
                return View("Empty");
            }
            else
            {
                return View(availableCars);
            }
        }
        public IActionResult LendCar(int carId)
        {
            var lendVM = new LendViewModel()
            {
                Car = _carRepository.GetById(carId),
                Customers = _customerRepository.GetAll()
            };
            return View(lendVM);
        }
        [HttpPost]
        public IActionResult LendCar(LendViewModel lendViewModel)
        {
            var car = _carRepository.GetById(lendViewModel.Car.CarId);

            var customer = _customerRepository.GetById(lendViewModel.Car.BorrowerId);

            car.Borrower = customer;

            _carRepository.Update(car);

            return RedirectToAction("List");
        }
    }
}
