namespace examintp.Models.Repositories
{
	public interface ILocationRepository
	{
		Location GetById(int id);
		IList<Location> GetAll();
		void Add(Location Location);
		Location Update(Location Location);
		void Delete(int id);
        void Delete(Location location);
    }
}
