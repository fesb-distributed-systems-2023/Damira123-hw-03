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
        private readonly Validation _validation;

        public CityLogic(ICityRepository cityRepository, IOptions<Validation> configuration)
        {
            _cityRepository = cityRepository;
            _validation = configuration.Value;
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

            if (!Regex.IsMatch(year.ToString(), _validation.YearRegex))
            {
                throw new UserErrorMessage("Invalid year format! Year must begin with either number 1 or number 2!");
            }
        }

        private void ValidateCountry(string? country)
        {
            if (country == null)
            {
                throw new UserErrorMessage("Field can't be empty!");
            }

            if (country.Length > _validation.CountryMaxCharacters)
            {
                throw new UserErrorMessage("Exceeded maximum number of characters!");
            }

            if (!Regex.IsMatch(country, _validation.CountryRegex))
            {
                throw new UserErrorMessage("Invalid country format! Format must include only letters! First letter must be capital!");
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

            if (!Regex.IsMatch(population.ToString(), _validation.PopulationRegex))
            {
                throw new UserErrorMessage("Invalid population format! Format must include only positive numbers!");
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

            if (!Regex.IsMatch(mayor, _validation.mayorRegex))
            {
                throw new UserErrorMessage("Invalid mayor format. Format must include only letters! First letter must be mayor!");
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
    
