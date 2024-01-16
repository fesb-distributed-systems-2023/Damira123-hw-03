using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Options;
using WebAppCity.Configuration;
using WebAppCity.Models.Domain;

namespace WebAppCity.Repositories
{
    public class CityRepository_SQL : ICityRepository
    {
        private readonly string _connectionString;

        public CityRepository_SQL(IOptions<DBConfiguration> configuration)
        {
            _connectionString = configuration.Value.ConnectionDB;
        }

        public void CreateNewCity(City city)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText =
            @"
                INSERT INTO City (Mayor, Year, Country, Population)
                VALUES ($mayor, $year, $country, $population)";

            command.Parameters.AddWithValue("$mayor", city.Mayor);
            command.Parameters.AddWithValue("$year", city.Year);
            command.Parameters.AddWithValue("$country", city.Country);
            command.Parameters.AddWithValue("$population", city.Population);

            int rowsAffected = command.ExecuteNonQuery();

            if (rowsAffected < 1)
            {
                throw new ArgumentException("Could not insert city into database.");
            }
        }

        public void DeleteCity(int id)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText =
            @"
                DELETE FROM City
                WHERE ID == $id";

            command.Parameters.AddWithValue("$id", id);

            int rowsAffected = command.ExecuteNonQuery();

            if (rowsAffected < 1)
            {
                throw new ArgumentException($"No city with ID = {id}.");
            }
        }

        public List<City> GetAllCities()
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText =
            @"SELECT ID, Mayor, Year, Country, Population FROM City";

            using var reader = command.ExecuteReader();

            var results = new List<City>();
            while (reader.Read())
            {

                var row = new City
                {
                    Id = reader.GetInt32(0),
                    Mayor = reader.GetString(1),
                    Year = reader.GetInt32(2),
                    Country = reader.GetString(3),
                    Population = reader.GetInt32(4),
                };

                results.Add(row);
            }

            return results;
        }

        public City GetSingCity(int id)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText =
            @"SELECT ID, Mayor, Year, Country, Population FROM City WHERE ID == $id";

            command.Parameters.AddWithValue("$id", id);

            using var reader = command.ExecuteReader();

            City result = null;

            if (reader.Read())
            {
                result = new City
                {
                    Id = reader.GetInt32(0),
                    Mayor = reader.GetString(1),
                    Year = reader.GetInt32(2),
                    Country = reader.GetString(3),
                    Population = reader.GetInt32(4),
                };
            }

            return result;
        }

        public void UpdateCity(int id, City updatedCity)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText =
            @"
                UPDATE City
                SET
                    Mayor = $mayor,
                    Year = $year,
                    Country = $country,
                    Population = $population
                WHERE
                    ID == $id";

            command.Parameters.AddWithValue("$id", id);
            command.Parameters.AddWithValue("$mayor", updatedCity.Mayor);
            command.Parameters.AddWithValue("$year", updatedCity.Year);
            command.Parameters.AddWithValue("$country", updatedCity.Country);
            command.Parameters.AddWithValue("$population", updatedCity.Population);

            int rowsAffected = command.ExecuteNonQuery();

            if (rowsAffected < 1)
            {
                throw new ArgumentException($"Could not update city with ID = {id}.");
            }
        }
    }
}
