using Microsoft.AspNetCore.Mvc;
using GeoPet.Services;

namespace GeoPet.Controllers
{
    [Route("location")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly HttpClient _client;
        private const string _baseUrl = "https://nominatim.openstreetmap.org/reverse?";
        
        public LocationController(HttpClient client)
        {
            _client = client;
            _client.BaseAddress = new Uri(_baseUrl);
        }

        [HttpGet]
        [Route("{latitude}/{longitude}")]
        public async Task<ActionResult> GetLocation(double latitude, double longitude)
        {
            var response = await _client.GetAsync($"lat={latitude}&lon={longitude}&format=json");

            if (response.IsSuccessStatusCode)
            {
                return Ok(response.Content.ReadFromJsonAsync<object>());
            }

            return BadRequest();
        }
    }
}
