using Dapper;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Data;
using WebApi91.Context;

namespace WebApi91.Services
{
    public class AutorServices : IAutoresServices
    {
        private readonly ApplicationDbContext _context;

        public AutorServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Response<List<Autor>>> GetAutores()
        {
            try
            {
                List<Autor> response = new List<Autor>();
                var result = await _context.Database.GetDbConnection().QueryAsync<Autor>("spGetAutores", new { }, commandType: CommandType.StoredProcedure);
                response = result.ToList();
                return new Response<List<Autor>>(response);
            }
            catch (Exception ex)
            {

                throw new Exception("Succedio un error");
            }
        }

        public async Task<Autor> CrearAutor(AutorServices i)
        {
            try
            {
                Autor result = new Autor();

                result = (await _context.Database.GetDbConnection().QueryAsync<Autor>("SpCrearAutor", new { i.Nombre, i.Nacionalidad }, commandType: CommandType.StoredProcedure)).FirstOrDefault();
            }
            catch (Exception ex)
            {

                throw new Exception("Succedio un error" + ex.Message);
            }
        }
    }
}
