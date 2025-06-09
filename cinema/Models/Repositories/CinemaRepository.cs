using Microsoft.EntityFrameworkCore;
using test.Models.data.test.Data;

namespace test.Models.Repositories
{
    public class CinemaRepository : ICinemaRepository
    {
        readonly AppDbContext context;

        public CinemaRepository(AppDbContext context)
        {
            this.context = context;
        }

        public IList<Cinema> GetAll()
        {
            return context.Cinemas
                .Include(c => c.Films)
                .OrderBy(c => c.CinemaName)
                .ToList();
        }

        public Cinema GetById(int id)
        {
            return context.Cinemas.Find(id);
        }

        public void Add(Cinema c)
        {
            context.Cinemas.Add(c);
            context.SaveChanges();
        }

        public Cinema Update(Cinema c)
        {
            Cinema existing = context.Cinemas.Find(c.CinemaId);
            if (existing != null)
            {
                existing.CinemaName = c.CinemaName;
                context.SaveChanges();
            }
            return existing;
        }

        public void Delete(int cinemaId)
        {
            Cinema c = context.Cinemas.Find(cinemaId);
            if (c != null)
            {
                context.Cinemas.Remove(c);
                context.SaveChanges();
            }
        }
    }

}
