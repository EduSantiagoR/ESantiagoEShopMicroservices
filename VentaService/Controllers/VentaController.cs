using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VentaService.Models;

namespace VentaService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        [ProducesResponseType(typeof(Result), 200)]
        public IActionResult GetAll()
        {
            Result result = Venta.GetAll();
            return result.Correct ? Ok(result) : BadRequest(result);
        }

        [HttpPost]
        [Route("")]
        [ProducesResponseType(typeof(Result), 200)]
        public IActionResult Add(Producto producto)
        {
            Result result = Venta.Add(producto);
            return result.Correct ? Ok(result) : BadRequest(result);
        }

        [HttpDelete]
        [Route("{idVenta}")]
        [ProducesResponseType(typeof (Result), 200)]
        public IActionResult Delete(int idVenta)
        {
            Result result = Venta.Delete(idVenta);
            return result.Correct ? Ok(result) : BadRequest(result);
        }
    }
}
