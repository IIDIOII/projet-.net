using Microsoft.EntityFrameworkCore;
using test.Models.data.test.Data;

namespace test.Models.Repositories
{
    using Microsoft.EntityFrameworkCore;

    public class FilmRepository : IFilmRepository
    {
        readonly AppDbContext context;

        public FilmRepository(AppDbContext context)
        {
            this.context = context;
        }

        public IList<Film> GetAll()
        {
            return context.Films
                .OrderBy(f => f.Name)
                .Include(f => f.Cinema)
                .ToList();
        }

        public Film GetById(int id)
        {
            return context.Films
                .Where(f => f.FilmId == id)
                .Include(f => f.Cinema)
                .SingleOrDefault();
        }

        public void Add(Film f)
        {
            context.Films.Add(f);
            context.SaveChanges();
        }

        public IList<Film> FindByName(string name)
        {
            return context.Films
                .Where(f => f.Name.Contains(name) || f.Cinema.CinemaName.Contains(name))
                .Include(f => f.Cinema)
                .ToList();
        }

        public Film Update(Film f)
        {
            Film existing = context.Films.Find(f.FilmId);
            if (existing != null)
            {
                existing.Name = f.Name;
                existing.Price = f.Price;
                existing.QteStock = f.QteStock;
                existing.CinemaId = f.CinemaId;
                existing.Image = f.Image;
                context.SaveChanges();
            }
            return existing;
        }

        public void Delete(int filmId)
        {
            Film f = context.Films.Find(filmId);
            if (f != null)
            {
                context.Films.Remove(f);
                context.SaveChanges();
            }
        }

        public IList<Film> GetFilmsByCinemaID(int? cinemaId)
        {
            return context.Films
                .Where(f => f.CinemaId == cinemaId)
                .OrderBy(f => f.FilmId)
                .Include(f => f.Cinema)
                .ToList();
        }
    }

}
