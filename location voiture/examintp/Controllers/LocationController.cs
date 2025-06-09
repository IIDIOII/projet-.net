using examintp.Models;
using examintp.Models.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace examintp.Controllers
{
    public class LocationController : Controller
    {
        private readonly ILocationRepository _locationRepository;
        private readonly IVoitureRepository _voitureRepository;

        public LocationController(ILocationRepository locationRepository, IVoitureRepository voitureRepository)
        {
            _locationRepository = locationRepository;
            _voitureRepository = voitureRepository;
        }

        public IActionResult Index()
        {
            var locations = _locationRepository.GetAll();
            return View(locations);
        }

        public IActionResult Details(int id)
        {
            var location = _locationRepository.GetById(id);
            if (location == null)
            {
                return NotFound();
            }
            return View(location);
        }

        // GET: Location/Create
        public IActionResult Create()
        {
            var voitures = _voitureRepository.GetAll(); 
            ViewBag.VoitureId = new SelectList(voitures, "Id", "Matricule"); 

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Location location)
        {
            _locationRepository.Add(location);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            var location = _locationRepository.GetById(id);
            if (location == null)
                return NotFound();

            var voitures = _voitureRepository.GetAll()
                .Select(v => new {
                    v.Id,
                    Description = v.Marque + " - " + v.Matricule
                });

            ViewBag.VoitureId = new SelectList(voitures, "Id", "Description", location.VoitureId);

            return View(location);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Location location)
        {
            if (id != location.Id)
            {
                return BadRequest();
            }

            _locationRepository.Update(location);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int id)
        {
            var location = _locationRepository.GetById(id);
            if (location == null)
                return NotFound();

            return View(location);
        }

        [HttpPost, ActionName("DeleteConfirmed")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _locationRepository.Delete(id);
            return RedirectToAction("Index");
        }

    }
}
