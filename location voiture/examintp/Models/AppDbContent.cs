using examintp.Models.examintp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
namespace examintp.Models
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

		public DbSet<Voiture> Voitures { get; set; }
		public DbSet<Location> Locations { get; set; }
        public DbSet<User> Users { get; set; }

    }

}
