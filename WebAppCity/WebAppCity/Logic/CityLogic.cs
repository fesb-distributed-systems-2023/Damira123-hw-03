using Microsoft.Extensions.Options;
using System.Text.RegularExpressions;
using WebAppCity.Confiration;
using WebAppCity.Exceptions;
using WebAppCity.Models.Domain;
using WebAppCity.Repositories;

namespace WebAppCity.Logic
{
    public class CityLogic : ICityLogic
    {
        private readonly ICityRepository _cityRepository;
       

        public CityLogic(ICityRepository cityRepository, configuration)
        {
            _cityRepository = cityRepository;
            
        }

        private void ValidateYear(int year)
        {

            if (year.ToString() is null)
            {
                throw new UserErrorMessage("Field can't be empty!");
            }

            if (year < 0)
            {
                throw new UserErrorMessage("Year can't be less then 0!");
            }

            if (year.ToString().Length != 4)
            {
                throw new UserErrorMessage("Year must be a 4-digit number!");
            }

           
        }

        private void ValidateCountry(string? country)
        {
            if (country == null)
            {
                throw new UserErrorMessage("Field can't be empty!");
            }

            if (country.Length > 23)
            {
                throw new UserErrorMessage("Exceeded maximum number of characters!");
            }

           
        }

        private void ValidatePopulation(int population)
        {
            if (population.ToString() is null)
            {
                throw new UserErrorMessage("Field can't be empty!");
            }

            if (population > 5000)
            {
                throw new UserErrorMessage("Capacity must be more then 5000!");
            }

           
        }

        private void ValidateMayor(string? mayor)
        {
            if (mayor == null)
            {
                throw new UserErrorMessage("Field can't be empty!");
            }

            if (mayor.Length > _validation.mayorMaxCharacters)
            {
                throw new UserErrorMessage("Exceeded maximum number of characters!");
            }

           
        }
        public void CreateNewCity(City? city)
        {
            if (city is null)
            {
                throw new UserErrorMessage("Cannot create a new city. All fields must be entered correctly!");
            }

            city.Id = -1;
            ValidateYear(city.Year);
            ValidateCountry(city.Country);
            ValidatePopulation(city.Population);
            ValidateMayor(city.Mayor);

            _cityRepository.CreateNewCity(city);
        }
        public void UpdateCity(int id, City? city)
        {
            if (city is null)
            {
                throw new UserErrorMessage("Cannot update city. All fields must be entered correctly!");
            }

            city.Id = -1;

            ValidateYear(city.Year);
            ValidateCountry(city.Country);
            ValidatePopulation(city.Population);
            ValidateMayor(city.Mayor);

            _cityRepository.UpdateCity(id, city);
        }
        public void DeleteCity(int id)
        {
            _cityRepository.DeleteCity(id);
        }

        public City? GetSingleCity(int id)
        {
            return _cityRepository.GetSingCity(id);
        }

        public IEnumerable<City> GetAllCities()
        {
            return _cityRepository.GetAllCities();
        }
    }
}
    
