using test.Models;
using test.Models.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.IO;
using System;

namespace test.Controllers
{
    public class FilmController : Controller
    {
        private readonly IFilmRepository FilmRepository;
        private readonly ICinemaRepository CinemaRepository;
        private readonly IWebHostEnvironment hostingEnvironment;

        public FilmController(IFilmRepository filmRepo, ICinemaRepository cinemaRepo, IWebHostEnvironment environment)
        {
            FilmRepository = filmRepo;
            CinemaRepository = cinemaRepo;
            hostingEnvironment = environment;
        }

        public IActionResult Index()
        {
            var films = FilmRepository.GetAll();
            return View(films);
        }

        public IActionResult Details(int id)
        {
            var film = FilmRepository.GetById(id);
            if (film == null) return NotFound();
            return View(film);
        }

        public IActionResult Create()
        {
            ViewBag.CinemaId = new SelectList(CinemaRepository.GetAll(), "CinemaId", "CinemaName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateViewModel model)
        {
            // Skipping ModelState validation
            string uniqueFileName = UploadImage(model.ImagePath);
            var film = new Film
            {
                Name = model.Name,
                Price = model.Price,
                QteStock = model.QteStock,
                CinemaId = model.CinemaId,
                Image = uniqueFileName
            };
            FilmRepository.Add(film);
            return RedirectToAction("Details", new { id = film.FilmId });
        }

        public IActionResult Edit(int id)
        {
            var film = FilmRepository.GetById(id);
            if (film == null) return NotFound();

            var model = new EditViewModel
            {
                FilmId = film.FilmId,
                Name = film.Name,
                Price = film.Price,
                QteStock = film.QteStock,
                CinemaId = film.CinemaId,
                ExistingImagePath = film.Image
            };
            ViewBag.CinemaId = new SelectList(CinemaRepository.GetAll(), "CinemaId", "CinemaName");
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(EditViewModel model)
        {
            // Skipping ModelState validation
            var film = FilmRepository.GetById(model.FilmId);
            if (film == null) return NotFound();

            film.Name = model.Name;
            film.Price = model.Price;
            film.QteStock = model.QteStock;
            film.CinemaId = model.CinemaId;

            if (model.ImagePath != null)
            {
                if (!string.IsNullOrEmpty(model.ExistingImagePath))
                {
                    string filePath = Path.Combine(hostingEnvironment.WebRootPath, "images", model.ExistingImagePath);
                    System.IO.File.Delete(filePath);
                }
                film.Image = UploadImage(model.ImagePath);
            }

            FilmRepository.Update(film);
            return RedirectToAction("Index");
        }
        public IActionResult Search(string val)
        {
            var results = FilmRepository.FindByName(val);
            return View("Index", results);
        }

        public IActionResult Delete(int id)
        {
            var film = FilmRepository.GetById(id);
            if (film == null) return NotFound();
            return View(film);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            FilmRepository.Delete(id);
            return RedirectToAction("Index");
        }

        public IActionResult Search(string val)
        {
            var results = FilmRepository.FindByName(val);
            return View("Index", results);
        }

        private string UploadImage(IFormFile imageFile)
        {
            string uniqueFileName = null;
            if (imageFile != null)
            {
                string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + imageFile.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    imageFile.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }
    }
}
