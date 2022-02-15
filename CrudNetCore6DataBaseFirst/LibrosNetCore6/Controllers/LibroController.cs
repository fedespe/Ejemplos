using BL;
using ET;
using LibrosNetCore6.Models;
using Microsoft.AspNetCore.Mvc;

namespace LibrosNetCore6.Controllers
{
    public class LibroController : Controller
    {
        private LibroBL libroBL = new LibroBL();
        public IActionResult Index()
        {
            try
            {
                return View(libroBL.FindAllLibros());
            }
            catch (ProyectoException ex)
            {
                ViewBag.Mensaje = ex.Message;
                TempData["mensaje"] = ex.Message;
                return View(new List<Libro>());
            }
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(LibroVM l)
        {
            try
            {
                //Validaciones
                //Guardar libro
                if (ModelState.IsValid)
                {
                    Libro nuevoLibro = new Libro
                    {
                        Autor = l.Autor,
                        Descripcion = l.Descripcion,
                        Titulo = l.Titulo,
                        FechaLanzamiento = l.FechaLanzamiento,
                        Precio = l.Precio
                    };
                    libroBL.createLibro(nuevoLibro);
                    TempData["mensaje"] = "El libro se ha creado correctamente";
                    return RedirectToAction("Index");
                }
                return View(l);
            }
            catch (ProyectoException ex)
            {
                //Falta agregar el spam en la vista para mostrar mensaje de error
                ViewBag.Mensaje = ex.Message;
                TempData["mensaje"] = ex.Message;
                return View(l);
            }
        }
        [HttpGet]
        public IActionResult Edit(int id = 0)
        {
            
            try
            {
                if (id == 0)
                {
                    TempData["mensaje"] = "No se encontro el libro.";
                    return RedirectToAction("Index");
                }
                Libro libro = libroBL.FindById(id);
                if (libro == null)
                {
                    TempData["mensaje"] = "No se encontro el libro.";
                    return RedirectToAction("Index");
                }
                LibroVM l = new LibroVM
                {
                    Id = libro.Id,
                    Autor = libro.Autor,
                    Descripcion = libro.Descripcion,
                    Titulo = libro.Titulo,
                    FechaLanzamiento = libro.FechaLanzamiento,
                    Precio = libro.Precio
                };
                return View(l);
            }
            catch (ProyectoException ex)
            {
                ViewBag.Mensaje = ex.Message;
                TempData["mensaje"] = ex.Message;
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public IActionResult Edit(LibroVM l)
        {
            try
            {
                //Validaciones
                //Guardar libro
                if (ModelState.IsValid)
                {
                    Libro unLibro = new Libro
                    {
                        Id = l.Id,
                        Autor = l.Autor,
                        Descripcion = l.Descripcion,
                        Titulo = l.Titulo,
                        FechaLanzamiento = l.FechaLanzamiento,
                        Precio = l.Precio
                    };
                    libroBL.updateLibro(unLibro);
                    TempData["mensaje"] = "El libro se actualizado correctamente";
                    return RedirectToAction("Index");
                }
                return View(l);
            }
            catch (ProyectoException ex)
            {
                ViewBag.Mensaje = ex.Message;
                TempData["mensaje"] = ex.Message;
                return RedirectToAction("Index");
            }
        }
        public IActionResult Delete(int id = 0)
        {
            try
            {
                if (id == 0)
                {
                    TempData["mensaje"] = "No se encontro el libro.";
                    return RedirectToAction("Index");
                }
                libroBL.deleteLibro(id);
                return RedirectToAction("Index");
            }
            catch (ProyectoException ex)
            {
                ViewBag.Mensaje = ex.Message;
                TempData["mensaje"] = ex.Message;
                return RedirectToAction("Index");
            }
        }


    }
}
