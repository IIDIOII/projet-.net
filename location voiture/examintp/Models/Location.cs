using examintp.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.ConstrainedExecution;

public class Location
{
	public int Id { get; set; }

	[Required]
	[Display(Name = "Date Début Location")]
	public DateTime DateDebutLocation { get; set; }

	[Required]
	public int Duree { get; set; } // en jours

	[Required]
	public float Prix { get; set; }

	// Foreign Key
	public int VoitureId { get; set; }
	public Voiture Voiture { get; set; }
}
