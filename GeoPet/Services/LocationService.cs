namespace GeoPet.Services
{
    public class LocationService : ILocationService
    {
        private readonly HttpClient _client;

        public LocationService(HttpClient client)
        {
            _client = client;
        }

        public async Task<object> GetLocationByCep(string cep)
        {
            var response = await _client.GetAsync($"https://viacep.com.br/ws/{cep}/json/");
            if (!response.IsSuccessStatusCode)
            {
                return default(object)!;
            }

            var address = await response.Content.ReadFromJsonAsync<object>();
            return address!;
        }

        public async Task<object> GetLocationByLatitudeLongitude(string latitude, string longitude)
            
        {
            _client.DefaultRequestHeaders.Add("User-Agent", "GeoPet");
            var response = await _client.GetAsync($"https://nominatim.openstreetmap.org/reverse?lat={latitude}&lon={longitude}&format=json");
            if (!response.IsSuccessStatusCode)
            {
                return default(object)!;
            }
            var address = await response.Content.ReadFromJsonAsync<object>();
            return address;
        }
    }
}
