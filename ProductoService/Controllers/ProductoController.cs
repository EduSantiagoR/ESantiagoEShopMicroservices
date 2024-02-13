using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ProductoService.Models;

namespace ProductoService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public ProductoController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        [Route("")]
        [ProducesResponseType(typeof(Result), 200)]
        public IActionResult GetAll()
        {
            Result result = Producto.GetAll();
            return result.Correct ? Ok(result) : BadRequest(result);
        }

        [HttpGet]
        [Route("{idProducto}")]
        [ProducesResponseType(typeof(Result), 200)]
        public IActionResult GetById(int idProducto)
        {
            Result result = Producto.GetById(idProducto);
            return result.Correct ? Ok(result) : BadRequest(result);
        }

        [HttpPost]
        [Route("")]
        [ProducesResponseType(typeof(Result), 200)]
        public IActionResult Add([FromBody]Producto producto)
        {
            Result result = Producto.Add(producto);
            return result.Correct ? Ok(result) : BadRequest(result);
        }

        [HttpPut]
        [Route("{idProducto}")]
        [ProducesResponseType(typeof(Result), 200)]
        public IActionResult Update(int idProducto, [FromBody]Producto producto)
        {
            producto.IdProducto = idProducto;
            Result result = Producto.Update(producto);
            return result.Correct ? Ok(result) : BadRequest(result);
        }

        [HttpDelete]
        [Route("{idProducto}")]
        [ProducesResponseType(typeof(Result), 200)]
        public IActionResult Delete(int idProducto)
        {
            Result result = Producto.Delete(idProducto);
            return result.Correct ? Ok(result) : BadRequest(result);
        }
    }
}
