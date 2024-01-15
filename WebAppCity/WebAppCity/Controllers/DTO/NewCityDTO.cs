using WebAppCity.Models.Domain;

namespace WebAppCity.Controllers.DTO
{
    public class NewCityDTO
    {
        public string? Mayor { get; set; }
        public int Year { get; set; }
        public string? Country { get; set; }
        public int Population { get; set; }

        public City ToModel()
        {
            return new City
            {
                Id = -1,
                Mayor = Mayor,
                Year = Year,
                Country = Country,
                Population = Population,
               
            };
        }
    }
}
