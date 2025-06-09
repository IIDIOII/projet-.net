namespace examintp.Controllers
{
	using examintp.Models;
	using examintp.Models.Repositories;
    using examintp.ViewModels;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
	using Microsoft.AspNetCore.Mvc.Rendering;
    using System;

    public class VoitureController : Controller
	{
		private readonly IVoitureRepository _voitureRepository;
        private readonly IWebHostEnvironment _env;
        public VoitureController(IVoitureRepository repo, IWebHostEnvironment env)
        {
            _voitureRepository = repo;
            _env = env;
        }
        public ActionResult Search(string val)
        {
            var result = _voitureRepository.FindByName(val);
            return View("Index", result);
        }
        public IActionResult Index()
		{
			var Voitures = _voitureRepository.GetAll();
			return View(Voitures);
		}

		public IActionResult Details(int id)
		{
			var Voiture = _voitureRepository.GetById(id);
			if (Voiture == null)
				return NotFound();

			return View(Voiture);
		}

		public IActionResult Create()
		{
			return View();
		}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(VoitureViewModel model)
        {
            string uniqueFileName = UploadImage(model.ImageFile);

            var voiture = new Voiture
            {
                Matricule = model.Matricule,
                Marque = model.Marque,
                Modele = model.Modele,
                Image = uniqueFileName
            };

            _voitureRepository.Add(voiture);
            return RedirectToAction("Index");
        }


        [NonAction]
        private string UploadImage(IFormFile file)
        {
            if (file == null) return null;

            string uploadsFolder = Path.Combine(_env.WebRootPath, "images");
            string uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            string filePath = Path.Combine(uploadsFolder, uniqueFileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            return uniqueFileName;
        }



        public IActionResult Edit(int id)
        {
            var voiture = _voitureRepository.GetById(id);
            if (voiture == null)
                return NotFound();

            var viewModel = new EditViewModel
            {
                VoitureId = voiture.Id,
                Matricule = voiture.Matricule,
                Marque = voiture.Marque,
                Modele = voiture.Modele,
                ExistingImage = voiture.Image
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(EditViewModel model)
        {
            var voiture = _voitureRepository.GetById(model.VoitureId);
            if (voiture == null)
                return NotFound();

            voiture.Matricule = model.Matricule;
            voiture.Marque = model.Marque;
            voiture.Modele = model.Modele;

            if (model.ImageFile != null)
            {
                // Delete old image
                if (!string.IsNullOrEmpty(model.ExistingImage))
                {
                    var oldImagePath = Path.Combine(_env.WebRootPath, "images", model.ExistingImage);
                    if (System.IO.File.Exists(oldImagePath))
                        System.IO.File.Delete(oldImagePath);
                }

                voiture.Image = UploadImage(model.ImageFile);
            }

            _voitureRepository.Update(voiture);
            return RedirectToAction("Index");
        }



        public IActionResult Delete(int id)
		{
			var voiture = _voitureRepository.GetById(id);
			if (voiture == null)
				return NotFound();

			return View(voiture);
		}

		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public IActionResult DeleteConfirmed(int id)
		{
			_voitureRepository.Delete(id);
			return RedirectToAction("Index");
		}
	}

}
