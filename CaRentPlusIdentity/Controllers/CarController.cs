using CaRentPlusIdentity.Data.Intefraces;
using CaRentPlusIdentity.Data.Model;
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
    public class CarController : Controller
    {
        private readonly ICarMarkRepository _carMarkRepository;
        private readonly ICarRepository _carRepository;

        public CarController(ICarMarkRepository carMarkRepository, ICarRepository carRepository)
        {
            _carMarkRepository = carMarkRepository;
            _carRepository = carRepository;
        }

        [Route("Car")] 
        public IActionResult List(int? carMarkId, int? borrowerId)
        {
            if (carMarkId == null && borrowerId == null)
            {
                var cars = _carRepository.GetAllWithCarMark();
                return CheckCars(cars);
            }
            else if (carMarkId != null)
            {
                var mark = _carMarkRepository.GetWithCars((int)carMarkId);
                if (mark.Cars.Count() == 0)
                {
                    return View("CarMarkEmpty", mark);
                }
                else
                {
                    return View(mark.Cars);
                }

            }
            else if (borrowerId != null)
            {
                var cars = _carRepository.FindWithCarMarkAndBorrower(car => car.BorrowerId == borrowerId);
                return CheckCars(cars);
            }
            else  
            {
                throw new ArgumentException();
            }
        }
        public IActionResult CheckCars(IEnumerable<Car> cars)
        {
            if (cars.Count() == 0)
            {
                return View("Empty");
            }
            else
            {
                return View(cars);
            }
        }
        public IActionResult Create()
        {
            var carVM = new CarViewModel()
            {
                CarMarks = _carMarkRepository.GetAll()
            };
            return View(carVM);
        }

        [HttpPost]
        public IActionResult Create(CarViewModel carViewModel)
        {
            if (!ModelState.IsValid)
            {
                carViewModel.CarMarks = _carMarkRepository.GetAll();
                return View(carViewModel);
            }
            _carRepository.Create(carViewModel.Car);

            return RedirectToAction("List");
        }

        public IActionResult Update(int id)
        {
            var carVM = new CarViewModel()
            {
                Car = _carRepository.GetById(id),
                CarMarks = _carMarkRepository.GetAll()
            };
            return View(carVM);
        }

        [HttpPost]
        public IActionResult Update(CarViewModel carViewModel)
        {
            if (!ModelState.IsValid)
            {
                carViewModel.CarMarks = _carMarkRepository.GetAll();
                return View(carViewModel);
            }
            _carRepository.Update(carViewModel.Car);

            return RedirectToAction("List");
        }
        public IActionResult Delete(int id)
        {
            var car = _carRepository.GetById(id);

            _carRepository.Delete(car);

            return RedirectToAction("List");
        }
    }
}
