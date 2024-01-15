/*
**********************************
* Author: Damira Mamuzić
* Project Task: City - Phase 2
**********************************
* Description:
* 
*    CREATE - Add new city
*    READ - Get 
*    READ - Get specific city
*    DELETE - Delete city
*
**********************************
 */




using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAppCity.Controllers.DTO;
using WebAppCity.Filters;
using WebAppCity.Models.Domain;
using WebAppCity.Repositories;

namespace WebAppCity.Controllers
{
    [LogFilter]
    [ApiController]
   public class CityController : ControllerBase
   {
        private readonly ICityRepository _cityRepository;

        public CityController(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }
        [HttpPost("/cities/new")]
        public ActionResult Post([FromBody] NewCityDTO city)
        {
            if (city == null)
            {
                return BadRequest($"Wrong city format!");
            }

            _cityRepository.CreateNewCity(city.ToModel());
            return Ok();
        }
        [HttpGet("/cities/all")]
        public ActionResult<IEnumerable<CityInfoDTO>> GetAllCity()
        {
            var allCities = _cityRepository.GetAllCities().Select(x => CityInfoDTO.FromModel(x));
            return Ok(_cityRepository.GetAllCities());
        }
        [HttpGet("/cities/{id}")]
        public ActionResult<CityInfoDTO> GetSingleCity(int id)
        {
            var city = _cityRepository.GetSingCity(id);

            if (city is null)
            {
                return NotFound($"City with id:{id} doesn't exist!");
            }
            else
            {
                return Ok(CityInfoDTO.FromModel(city));
            }
        }
        [HttpDelete("/cities/{id}")]
        public IActionResult DeleteCity( int id)
        {
            _cityRepository.DeleteCity(id);
            return Ok();
        }

        [HttpPut("/cities/{id}")]
        public ActionResult UpdatedCity(int id, [FromBody] NewCityDTO updatedCity)
        {
            if (updatedCity == null)
            {
                return BadRequest();
            }

            var existingCity = _cityRepository.GetSingCity(id);
            if (existingCity == null)
            {
                return NotFound();
            }

            _cityRepository.UpdateCity(id, updatedCity.ToModel());

            return Ok();
        }
    }
}
