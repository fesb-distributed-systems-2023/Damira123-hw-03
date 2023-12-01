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
using WebAppCity.Models.Domain;
using WebAppCity.Repositories;

namespace WebAppCity.Controllers
{

   [ApiController]
   public class CityController : ControllerBase
   {
        private readonly CityRepository _cityRepository;

        public CityController(CityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }
        [HttpPost("/cities/new")]
        public IActionResult CreateNewCity([FromBody] City city)
        {
            bool fSuccess = _cityRepository.CreateNewCity(city);

            if (fSuccess)
            {
                return Ok("New city created!");
            }
            else
            {
                return BadRequest("Something went wrong!");
            }
        }
        [HttpGet("/cities/all")]
        public IActionResult GetAllCity()
        {
            return Ok(_cityRepository.GetAllCities());
        }
        [HttpGet("/cities/{id}")]
        public IActionResult GetSingleCity([FromRoute] int id)
        {
            var city = _cityRepository.GetSingCity(id);

            if (city is null)
            {
                return NotFound($"City with id:{id} doesn't exist!");
            }
            else
            {
                return Ok(city);
            }
        }
        [HttpDelete("/cities/{id}")]
        public IActionResult DeleteCity([FromRoute] int id)
        {
            if (_cityRepository.DeleteCity(id))
            {
                return Ok($"Deleted city with id={id}!");
            }
            else
            {
                return NotFound($"Could not find city with id={id}!");
            }
        }
    }
}
