
using Microsoft.EntityFrameworkCore;

namespace examintp.Models.Repositories
{
	public class VoitureRepository : IVoitureRepository
	{
		private readonly AppDbContext context;

		public VoitureRepository(AppDbContext context)
		{
			this.context = context;
		}

        public IList<Voiture> FindByName(string val)
        {
            return context.Voitures
                .Where(v => v.Matricule.Contains(val) || v.Marque.Contains(val))
                .ToList();
        }




        public void Add(Voiture voiture)
		{
			context.Voitures.Add(voiture);
			context.SaveChanges();
		}

		public void Delete(int id)
		{
			var Voiture = context.Voitures.Find(id);
			if (Voiture != null)
			{
				context.Voitures.Remove(Voiture);
				context.SaveChanges();
			}
		}

		public IList<Voiture> GetAll() => context.Voitures.OrderBy(c => c.Matricule).ToList();

		public Voiture GetById(int id) => context.Voitures.Find(id);

		public Voiture Update(Voiture voiture)
		{
			var existing = context.Voitures.Find(voiture.Id);
			if (existing != null)
			{
				existing.Matricule = voiture.Matricule;
				existing.Marque = voiture.Marque;
				existing.Modele = voiture.Modele;
				context.SaveChanges();
			}
			return existing;
		}
	}

}
