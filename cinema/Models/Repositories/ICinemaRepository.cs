namespace test.Models.Repositories
{
    public interface ICinemaRepository
    {
        Cinema GetById(int Id);
        IList<Cinema> GetAll();
        void Add(Cinema c);
        Cinema Update(Cinema c);
        void Delete(int Id);
    }

}
