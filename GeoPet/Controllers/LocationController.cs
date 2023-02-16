using Microsoft.AspNetCore.Mvc;

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
        public async Task<ActionResult> GetLocation(string latitude, string longitude)
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
