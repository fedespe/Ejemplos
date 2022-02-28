using ProyectoServicioWeb.Models;

namespace ProyectoServicioWeb.Services
{
    public interface IPruebaService
    {
        Task<IEnumerable<Publicacion>> GetAll();
        Task<Publicacion> GetById(int id);
    }
}
