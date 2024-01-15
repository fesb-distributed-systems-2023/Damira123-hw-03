using WebAppCity.Models.Domain;

namespace WebAppCity.Controllers.DTO
{
    public class CityInfoDTO
    {
        public int Id { get; set; }
        public string? Mayor { get; set; }
        public int Year { get; set; }
        public string? Country { get; set; }
        public int Population { get; set; }
        

        public static CityInfoDTO FromModel(City model)
        {
            return new CityInfoDTO
            {
                Id = model.Id,
                Mayor = model.Mayor,
                Year = model.Year,
                Country = model.Country,
                Population = model.Population,
              
            };
        }
    }
}
