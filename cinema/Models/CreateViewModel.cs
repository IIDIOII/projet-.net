namespace test.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.Net.Sockets;
    using Microsoft.AspNetCore.Http;

    public class CreateViewModel
    {
        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Ticket Price(DT):")]
        public float Price { get; set; }

        [Required]
        [Display(Name = "Length (in minutes):")]
        public int QteStock { get; set; }

        public int CinemaId { get; set; }
        public Cinema Cinema { get; set; }

        [Required]
        [Display(Name = "Image :")]
        public IFormFile ImagePath { get; set; }
    }

}
