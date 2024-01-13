/*
**********************************
* Author: Damira Mamuzić
* Project Task: City - Phase 2
**********************************
* Description:
* 
*    CREATE - Add new city
*    READ - Get all cities
*    READ - Get single city
*    DELETE - Delete city
*
**********************************
*/



using WebAppCity.Models.Domain;

namespace WebAppCity.Repositories
{
    public interface ICityRepository
    {
        void CreateNewCity(City city);
        void DeleteCity(int id);
        List<City> GetAllCities();
        City GetSingCity(int id);
        void UpdateCity(int id, City updatedCity);
    }
}