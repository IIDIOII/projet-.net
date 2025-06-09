namespace examintp.ViewModels
{
    using Microsoft.AspNetCore.Http;
    using System.ComponentModel.DataAnnotations;

    public class VoitureViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Matricule { get; set; }

        [Required]
        public string Marque { get; set; }

        [Required]
        public string Modele { get; set; }

        public string ExistingImage { get; set; }

        [Required]
        [Display(Name = "Image :")]
        public IFormFile ImageFile { get; set; }
    }

}
