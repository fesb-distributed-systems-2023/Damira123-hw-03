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
    public class CityRepository
    {
        // List of all cities
        private List<City> m_lstCities;

        public CityRepository()
        {
            // Creating new list
            m_lstCities = new List<City>();
        }
        // CREATE : Create new city
        public bool CreateNewCity(City city)
        {
            // Adding new city to the list
            m_lstCities.Add(city);

            return true;
        }
        // READ : Get all cities
        public IEnumerable<City> GetAllCities()
        {
            // Returns entire list 
            return m_lstCities;
        }
        // READ : Get single city (specified by ID)
        public City GetSingCity(int id)
        {
            if (!m_lstCities.Any(city => city.Id == id))
            {
                // Checks if any city matches currently used id, if not returns null
                return null;
            }

            var city = m_lstCities.FirstOrDefault(city => city.Id == id);

            // Checks if city matches an id, if yes returns that city
            return city;
        }
        // DELETE : Delete city (specified by ID)
        public bool DeleteCity(int id)
        {
            // Check if city matches ID
            var cityToDelete = m_lstCities.FirstOrDefault(itemCity => itemCity.Id == id);
            if (cityToDelete == null)
            {
                return false;
            }

            m_lstCities.Remove(cityToDelete);

            return true;
        }

    }
}
