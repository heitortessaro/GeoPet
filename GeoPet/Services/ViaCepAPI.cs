using System.Net.Http.Json;
using GeoPet.Interfaces;

namespace GeoPet.Services


{
    public class ViaCepAPI
    {
        private readonly string _baseURL = "https://viacep.com.br/ws/";
        private readonly HttpClient _client;

        public ViaCepAPI(HttpClient client)
        {
            _client = client;
            _client.BaseAddress = new Uri(_baseURL);
        }
        
        public async Task<IAddress> GetLocation(string cep)
        {
            var response = await _client.GetAsync($"{cep}/json/");
            if (!response.IsSuccessStatusCode)
                {
                    return null;
                }

            var address = await response.Content.ReadFromJsonAsync<IAddress>();
            return address;
        }
    }
}
