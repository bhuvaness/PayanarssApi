using CustomerBlazorWasm.Models.Dto;
using System.Net.Http.Json;

namespace CustomerBlazorWasm.Services
{
    public class CustomerService
    {
        private readonly HttpClient _http;

        public CustomerService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<CustomerDto>> GetAllAsync()
        {
            return await _http.GetFromJsonAsync<List<CustomerDto>>("api/customer") ?? new();
        }

        public async Task<CustomerDto?> CreateAsync(CustomerDto dto)
        {
            var response = await _http.PostAsJsonAsync("api/customer", dto);
            return await response.Content.ReadFromJsonAsync<CustomerDto>();
        }
    }
}
