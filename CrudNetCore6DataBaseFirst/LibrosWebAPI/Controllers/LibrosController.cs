using BL;
using ET;
using LibrosWebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibrosWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibrosController : ControllerBase
    {
        private LibroBL libroBL = new LibroBL();
        private Retorno retorno = new Retorno();

        [AllowAnonymous]
        [HttpGet, Route("obtenerTodos")]
        public Retorno GetAllLibros()
        {
            try
            {
                List<Libro> libros = libroBL.FindAllLibros();
                foreach (Libro l in libros)
                {
                    retorno.Objetos.Add(l);
                }
                retorno.Codigo = 200;
            }
            catch (ProyectoException ex)
            {
                retorno.Codigo = 1;
                retorno.Mensaje = ex.Message;
            }
            return retorno;
        }
        [AllowAnonymous]
        [HttpGet, Route("obtenerUno/{id}")]
        public Retorno GetLibro(int id)
        {
            try
            {
                Libro l = libroBL.FindById(id);
                retorno.Objetos.Add(l);
                retorno.Codigo = 200;
            }
            catch (ProyectoException ex)
            {
                retorno.Codigo = 1;
                retorno.Mensaje = ex.Message;
            }
            return retorno;
        }
        [HttpPost, Route("crearLibro")]
        public Retorno PostAltaLibro([FromBody] Libro libro)
        {
            try
            {
                libroBL.createLibro(libro);
                retorno.Codigo = 200;
            }
            catch (ProyectoException ex)
            {
                retorno.Codigo = 1;
                retorno.Mensaje = ex.Message;
            }
            return retorno;
        }
        [HttpPut, Route("actualizarLibro")]
        public Retorno PutActualizarLibro([FromBody] Libro libro)
        {
            try
            {
                libroBL.updateLibro(libro);
                retorno.Codigo = 200;
            }
            catch (ProyectoException ex)
            {
                retorno.Codigo = 1;
                retorno.Mensaje = ex.Message;
            }
            return retorno;
        }
        [HttpDelete, Route("borrarLibro/{id}")]
        public Retorno DeleteLibro(int id)
        {
            try
            {
                libroBL.deleteLibro(id);
                retorno.Codigo = 200;
            }
            catch (ProyectoException ex)
            {
                retorno.Codigo = 1;
                retorno.Mensaje = ex.Message;
            }
            return retorno;
        }
    }
}
