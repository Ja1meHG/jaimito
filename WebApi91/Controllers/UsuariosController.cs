using Domain.DTO;
using Microsoft.AspNetCore.Mvc;
using WebApi91.Services;

namespace WebApi91.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuariosController : ControllerBase
    {
        public readonly IUsuarioServices _usuarioServices;
      public UsuariosController(IUsuarioServices usuarioServices)
        {
            _usuarioServices = usuarioServices;
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerLista()
        {
            var result = await _usuarioServices.ObtenerUsuarios();

            return Ok(result);
        }
        [HttpGet("id")]

        public async Task <IActionResult> ObtenerUsuario(int id)
        {
            var result = await _usuarioServices.ObtenerUsuario(id);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] UsuarioResponse request)
        {
            var result = await _usuarioServices.CrearUsuario(request);

            return Ok(result);
        }

          [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUsuario(int id, [FromBody] UserUpdateDTO request)
        {
            var response = await _usuarioServices.UpdateUsuario(id, request);
            if (response.Succeded)
            {
                return Ok(response);
            }
            else
            {
                return NotFound(response.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            var response = await _usuarioServices.DeleteUsuario(id);
            return Ok(response);
        }

        
    }
}
