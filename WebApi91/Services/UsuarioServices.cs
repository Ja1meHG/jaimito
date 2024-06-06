using Domain.DTO;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using WebApi91.Context;

namespace WebApi91.Services
{
    public class UsuarioServices : IUsuarioServices
    {

        private readonly ApplicationDbContext _context;
        public UsuarioServices(ApplicationDbContext context)
        {
            _context = context;
        }

        //Lista de usuarios
        public async Task<Response<List<Usuario>>> ObtenerUsuarios()
        {
            try
            {
                List<Usuario> response = await _context.Usuarios.Include(x => x.Roles).ToListAsync();

                return new Response<List<Usuario>>(response);
            }
            catch (Exception ex)
            {

                throw new Exception("Sucedido un error" +ex.Message);
            }

            
        }
        public async Task<Response<Usuario>> ObtenerUsuario(int id)

        {
            try
            {
                Usuario res = await _context.Usuarios.FirstOrDefaultAsync(x => x.pkUsuario == id);
                return new Response<Usuario>(res);
            }
            catch (Exception ex)
            {

                throw new Exception("sucedido un error " + ex.Message);
            }
        }

        public async Task <Response<Usuario>> CrearUsuario(UsuarioResponse request)
        {
            try
            {
                Usuario usuario=new Usuario();
                {
                    usuario.Nombre = request.Nombre;
                    usuario.User=request.User;
                    usuario.Password=request.Password;
                    usuario.FkRol=request.FkRol;
                }

                _context.Usuarios.Add(usuario);
                await _context.SaveChangesAsync();

                return new Response<Usuario>(usuario);

              
            }
            catch (Exception ex)
            {

                throw new Exception("sucedido un error"+ex.Message);
            }
        }
        public async Task<Response<int>> DeleteUsuario(int id)
        {
            Usuario res = await _context.Usuarios.FindAsync(id);
            _context.Usuarios.Remove(res);
            await _context.SaveChangesAsync();
            return new Response<int>(id, "Usuario eliminado correctamente");
        }

        public async Task<Response<int>> UpdateUsuario(int id, UserUpdateDTO request)
        {
            var res = await _context.Usuarios.FirstAsync(x => x.pkUsuario == id);

            if (res == null)
            {
                return new Response<int>
                {
                    Succeded = false,
                    Message = "Usuario no encontrado"
                };
            }
            res.Nombre = request.Nombre;
            res.User = request.User;
            res.Password = request.Password;
            res.FkRol = request.FkRol;


            await _context.SaveChangesAsync();

            return new Response<int>
            {
                Succeded = true,
                Message = "Usuario actualizado correctamente"
            };
        }

    }
}
