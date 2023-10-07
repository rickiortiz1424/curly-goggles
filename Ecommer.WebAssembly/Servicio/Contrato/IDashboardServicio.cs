using Ecommerce.DTO;

namespace Ecommer.WebAssembly.Servicio.Contrato
{
    public interface IDashboardServicio
    {

        Task<ResponseDTO<DashboardDTO>> Resumen();

    }
}
