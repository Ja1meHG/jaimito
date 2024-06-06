using Domain.DTO;
using Domain.Entities;

namespace WebApi91.Services
{
    public interface IAutoresServices
    {
        public Task<Response<List<Autor>>> GetAutores();

        public Task<Response<Autor>> CrearAutor(Autor i);
    }
}
