namespace test.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;

    public class Cinema
    {
        public int CinemaId { get; set; }

        [Required]
        [Display(Name = "Nom")]
        public string CinemaName { get; set; }

        public virtual ICollection<Film> Films { get; set; }
    }

}
