using Microsoft.AspNetCore.Mvc;
using GeoPet.Services;

namespace GeoPet.Controllers
{
    [ApiController]
    [Route("location")]
    public class LocationController : ControllerBase
    {
        public IViaCepAPI _viaCepAPI;

        public LocationController(IViaCepAPI viaCepAPI)
        {
            _viaCepAPI = viaCepAPI;
        }

        [HttpGet]
        [Route("{cep}")]
        public async Task<IActionResult> GetLocation(string cep)
        {
            try
            {
                var location = await _viaCepAPI.GetLocation(cep);
                return Ok(location);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
