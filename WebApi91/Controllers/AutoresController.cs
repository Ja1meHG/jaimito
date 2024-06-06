using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using WebApi91.Services;

namespace WebApi91.Controllers
{
    public class AutoresController : Controller
    {

        public readonly IAutoresServices _AutorServices;
        public AutoresController(IAutoresServices AutorServices)
        {
            _AutorServices = AutorServices;
        }



        [HttpPost]
        public async Task<IActionResult> CrearAutor([FromBody] Autor request)
        {
            var result = await _AutorServices.CrearAutor(request);

            return Ok(result);
        }
    }
}
