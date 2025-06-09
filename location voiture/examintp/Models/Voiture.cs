using System.ComponentModel.DataAnnotations;
namespace examintp.Models
{
	public class Voiture
	{
		public int Id { get; set; }

		[Required]
		[Display(Name = "Matricule")]
		public string Matricule { get; set; }

		[Required]
		public string Marque { get; set; }

		[Required]
		public string Modele { get; set; }

        [Required]
        [Display(Name = "Image :")]
        public string Image { get; set; }
    }

}
