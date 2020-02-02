using CaRentPlusIdentity.Data.Intefraces;
using CaRentPlusIdentity.Data.Model;
using CaRentPlusIdentity.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace CaRentPlusIdentity.Controllers
{
    [Authorize]
    public class CarMarkController : Controller
    {
        private readonly ICarMarkRepository _carMarkRepository;

        public CarMarkController(ICarMarkRepository carMarkRepository)
        {
            _carMarkRepository = carMarkRepository;
        }
        [Route("CarMark")]
        public IActionResult List()
        {
            var marks = _carMarkRepository.GetAllWithCars();

            if (marks.Count() == 0)
            {
                return View("Empty");
            }

            return View(marks);
        }

        public IActionResult Update(int id)
        {
            var mark = _carMarkRepository.GetById(id);

            if (mark == null)
            {
                return NotFound();
            }

            return View(mark);
        }

        [HttpPost]
        public IActionResult Update(CarMark carMark)
        {
            if (!ModelState.IsValid)
            {
                return View(carMark);
            }

            _carMarkRepository.Update(carMark);

            return RedirectToAction("List");
        }

        public IActionResult Create()
        {
            // tworzę nowy VM, wkładam refere i wołam widok
            var viewModel = new CreateCarMarkViewModel
            // przechwytuje url    // odnośnik ma wrócić do tworzenia auta po utworzeniu marki
            {
                Referer = Request.Headers["Referer"].ToString()
            };
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Create(CreateCarMarkViewModel carMarkVM)
        {
            if (!ModelState.IsValid)
            {
                return View(carMarkVM);
            }
            _carMarkRepository.Create(carMarkVM.CarMark);

            if (!String.IsNullOrEmpty(carMarkVM.Referer))
            {
                return Redirect(carMarkVM.Referer);
            }
            return RedirectToAction("List");
        }

        public IActionResult Delete(int id)
        {
            var mark = _carMarkRepository.GetById(id);

            _carMarkRepository.Delete(mark);

            return RedirectToAction("List");
        }
    }
}
