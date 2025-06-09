using Microsoft.EntityFrameworkCore;

namespace examintp.Models.Repositories
{
	public class LocationRepository : ILocationRepository
	{
		private readonly AppDbContext context;

		public LocationRepository(AppDbContext context)
		{
			this.context = context;
		}

		public void Add(Location Location)
		{
			context.Locations.Add(Location);
			context.SaveChanges();
		}

		public void Delete(int id)
		{
			var rental = context.Locations.Find(id);
			if (rental != null)
			{
				context.Locations.Remove(rental);
				context.SaveChanges();
			}
		}

        public void Delete(Location location)
        {
            throw new NotImplementedException();
        }

        public IList<Location> GetAll()
		{
			return context.Locations
				.Include(r => r.Voiture)
				.OrderBy(r => r.DateDebutLocation)
				.ToList();
		}

		public Location GetById(int id)
		{
			return context.Locations
				.Include(r => r.Voiture)
				.SingleOrDefault(r => r.Id == id);
		}

		public Location Update(Location location)
		{
			var existing = context.Locations.Find(location.Id);
			if (existing != null)
			{
				existing.DateDebutLocation = location.DateDebutLocation;
				existing.Duree = location.Duree;
				existing.Prix = location.Prix;
				existing.VoitureId = location.VoitureId;
				context.SaveChanges();
			}
			return existing;
		}
	}

}
