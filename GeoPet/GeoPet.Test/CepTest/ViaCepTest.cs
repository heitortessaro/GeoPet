using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http.Json;
using System.Text.Json;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Microsoft.AspNetCore.Mvc.Razor.TagHelpers;
using Microsoft.AspNetCore.Mvc.Testing;
using GeoPet.Interfaces;

namespace GeoPet.Test.CepTest
{
    internal class ViaCepTest : IClassFixture<TestingWebAppFactory<Program>>
    {
        private readonly HttpClient _client;

        public ViaCepTest(TestingWebAppFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        private readonly IAddress address = new IAddress() 
        {
                cep = "21040-113",
                logradouro = "Avenida Teixeira de Castro",
                complemento = "de 277 ao fim - lado ímpar",
                bairro = "Ramos",
                localidade = "Rio de Janeiro",
                uf = "RJ",
                ibge = "3304557",
                gia = "",
                ddd = "21",
                siafi = "6001"
        }
        

        [Theory]
        ['21040-113', address]
        public async Task shouldReturnAAdress(string cep)
        {
            var response = await _client.GetAsync($"https://viacep.com.br/ws/{address.cep}/json/");
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            var responseAddress = JsonSerializer.Deserialize<IAddress>(responseString);
            responseAddress.Should().BeEquivalentTo(address);
        }
    }
}
