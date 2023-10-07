using  Ecommerce.DTO;
using Ecommer.WebAssembly.Servicio.Contrato;
using System.Net.Http.Json;

namespace Ecommer.WebAssembly.Servicio.Implementacion
{
    public class VentaServicio :IVentaServicio
    {

        private readonly HttpClient _httpClient;

        public VentaServicio(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ResponseDTO<VentaDTO>> Registrar(VentaDTO modelo)
        {
            var response = await _httpClient.PostAsJsonAsync("Venta/Registrar", modelo);
            var result = await response.Content.ReadFromJsonAsync<ResponseDTO<VentaDTO>>();
            return result!;
        }
    }
}
