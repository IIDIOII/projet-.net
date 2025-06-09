namespace examintp.Models.Repositories
{
	public interface IVoitureRepository
	{
        IList<Voiture> FindByName(string val);

        Voiture GetById(int id);
		IList<Voiture> GetAll();
		void Add(Voiture car);
		Voiture Update(Voiture car);
		void Delete(int id);
	}
}
