using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Http;

    namespace examintp.ViewModels
    {
        public class EditViewModel
        {
            public int VoitureId { get; set; }

            [Required]
            public string Matricule { get; set; }

            [Required]
            public string Marque { get; set; }

            [Required]
            public string Modele { get; set; }

            [Display(Name = "Nouvelle Image")]
            public IFormFile ImageFile { get; set; }

            public string ExistingImage { get; set; }
        }
    }