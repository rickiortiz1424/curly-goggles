using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Ecommerce.Servicio.Contrato;
using Ecommerce.DTO;
using Ecommerce.Servicio.Implementacion;

namespace Ecommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashBoardController : ControllerBase
    {

        private readonly IDashboardServicio _dashboardServicio;

        public DashBoardController(IDashboardServicio dashBoardServicio)
        {
            _dashboardServicio= dashBoardServicio;
        }



        [HttpGet("Resumen")]
        public IActionResult Resumen()
        {
            var response = new ResponseDTO<DashboardDTO>();

            try
            {

                response.EsCorrecto = true;
                response.Resultado =  _dashboardServicio.Resumen();

            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }
    }
}
