using Microsoft.AspNetCore.Mvc;
using test.Models;
using test.Models.Repositories;

namespace test.Controllers
{
    public class CinemaController : Controller
    {
        private readonly ICinemaRepository CinemaRepository;

        public CinemaController(ICinemaRepository cinemaRepository)
        {
            CinemaRepository = cinemaRepository;
        }

        public IActionResult Index()
        {
            var cinemas = CinemaRepository.GetAll();
            return View(cinemas);
        }

        public IActionResult Details(int id)
        {
            var cinema = CinemaRepository.GetById(id);
            if (cinema == null) return NotFound();
            return View(cinema);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Cinema cinema)
        {
            // Temporarily ignoring validation
            CinemaRepository.Add(cinema);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var cinema = CinemaRepository.GetById(id);
            if (cinema == null) return NotFound();
            return View(cinema);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Cinema cinema)
        {
            // Temporarily ignoring validation
            CinemaRepository.Update(cinema);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var cinema = CinemaRepository.GetById(id);
            if (cinema == null) return NotFound();
            return View(cinema);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            CinemaRepository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
