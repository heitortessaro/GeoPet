using Microsoft.AspNetCore.Mvc;
using GeoPet.Services;

namespace GeoPet.Controllers
{
    [ApiController]
    [Route("location")]
    public class LocationController : ControllerBase
    {
        public ILocationService _locationService;

        public LocationController(ILocationService locationService)
        {
            _locationService = locationService;
        }

        [HttpGet]
        [Route("{cep}")]
        public async Task<IActionResult> GetLocation(string cep)
        {
            try
            {
                var location = await _locationService.GetLocationByCep(cep);
                return Ok(location);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet]
        [Route("{latitude}/{longitude}")]
        public async Task<IActionResult> GetLocation(string latitude, string longitude)
        {
            try
            {
                var location = await _locationService.GetLocationByLatitudeLongitude(latitude, longitude);
                return Ok(location);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
