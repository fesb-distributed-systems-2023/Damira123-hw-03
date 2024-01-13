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
        private readonly ICityRepository _cityRepository;

        public CityController(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }
        [HttpPost("/cities/new")]
        public IActionResult CreateNewCity([FromBody] City city)
        {
             _cityRepository.CreateNewCity(city);

            return Ok();
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
            _cityRepository.DeleteCity(id);
            return Ok();
        }

        [HttpPut("/cities/{id}")]
        public ActionResult UpdatedCity(int id, [FromBody] City updatedCity)
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

            _cityRepository.UpdateCity(id, updatedCity);

            return Ok();
        }
    }
}
