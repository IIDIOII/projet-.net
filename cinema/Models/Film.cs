namespace test.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Film
    {
        public int FilmId { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Ticket Price (DT):")]
        public float Price { get; set; }

        [Required]
        [Display(Name = "Length (in minutes):")]
        public int QteStock { get; set; }

        public int CinemaId { get; set; }
        public Cinema Cinema { get; set; }

        [Required]
        [Display(Name = "Image:")]
        public string Image { get; set; }
    }


}


