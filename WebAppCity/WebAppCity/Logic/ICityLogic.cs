using WebAppCity.Models.Domain;

namespace WebAppCity.Logic
{
    public interface ICityLogic
    {
        void CreateNewCity(City? city);
        void DeleteCity(int id);
        IEnumerable<City> GetAllCities();
        City? GetSingleCity(int id);
        void UpdateCity(int id, City? city);
    }
}