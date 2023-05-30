using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;
using ConsultaCepAPI;

namespace viaCepApi
{
    public class ConsultaCEP
    { 
        private static readonly HttpClient _httpClient = new();

        public static async Task<Endereco?> BuscarCEPAsync(string cep)
        {
            try
            {
                var response = await _httpClient.GetAsync($"https://viacep.com.br/ws/{cep}/json/");

                return response.StatusCode switch
                {
                    System.Net.HttpStatusCode.OK =>
                    await response.Content.ReadFromJsonAsync<Endereco>(),
                    System.Net.HttpStatusCode.NotFound => null,
                    _ => throw new HttpRequestException($"Erro ao buscar CEP: {response.StatusCode}")
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao buscar CEP: {ex.Message}");
                return null;
            }
        }
    }
}
