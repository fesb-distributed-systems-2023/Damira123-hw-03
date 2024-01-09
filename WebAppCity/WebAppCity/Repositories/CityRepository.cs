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
    public class CityRepository : ICityRepository
    {
        // List of all cities
        private List<City> m_lstCities;

        public CityRepository()
        {
            // Creating new list
            m_lstCities = new List<City>();
        }
        // CREATE : Create new city
        public void CreateNewCity(City city)
        {
            // Adding new city to the list
            m_lstCities.Add(city);
        }
        // READ : Get all cities
        public List<City> GetAllCities()
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
        public void DeleteCity(int id)
        {
            City? cityToRemove = GetSingCity(id);
            if (cityToRemove != null)
            {
                m_lstCities.Remove(cityToRemove);
            }
            else
            {
                throw new KeyNotFoundException($"City with ID '{id}' not found.");
            }
        }

        public void UpdateCity(int id, City updatedCity)
        {

            City? existingCity = GetSingCity(id);
            if (existingCity is not null)
            {
                // Update only if the user has permission
                // Implement access control logic as needed
                existingCity.Mayor = updatedCity.Mayor;
                existingCity.Year = updatedCity.Year;
                existingCity.Country = updatedCity.Country;
                existingCity.Population = updatedCity.Population;
                existingCity.Monuments = updatedCity.Monuments;
            }
            else
            {
                throw new KeyNotFoundException($"City with ID '{id}' not found.");
            }

        }
    }
}
