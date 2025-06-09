namespace test.Models.Repositories
{
    public interface IFilmRepository
    {
        Film GetById(int Id);
        IList<Film> GetAll();
        void Add(Film f);
        Film Update(Film f);
        void Delete(int Id);
        IList<Film> GetFilmsByCinemaID(int? cinemaId);
        IList<Film> FindByName(string name);
    }

}
