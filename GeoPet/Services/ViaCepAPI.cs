namespace GeoPet.Services
{
    public class ViaCepAPI : IViaCepAPI
    {
        private readonly HttpClient _client;
        private const string _baseURL = "https://viacep.com.br/ws/";

        public ViaCepAPI(HttpClient client)
        {
            _client = client;
            client.BaseAddress = new Uri(_baseURL);
        }
        
        public async Task<object> GetLocation(string cep)
        {
            var response = await _client.GetAsync($"{cep}/json/");
            if (!response.IsSuccessStatusCode)
                {
                    return default(object)!;
                }

            var address = await response.Content.ReadFromJsonAsync<object>();
            return address!;
        }
    }
}
