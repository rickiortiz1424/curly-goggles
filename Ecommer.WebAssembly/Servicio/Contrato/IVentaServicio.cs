using Ecommerce.DTO;


namespace Ecommer.WebAssembly.Servicio.Contrato
{
    public interface IVentaServicio
    {

        Task<ResponseDTO<VentaDTO>> Registrar(VentaDTO modelo);

    }
}
