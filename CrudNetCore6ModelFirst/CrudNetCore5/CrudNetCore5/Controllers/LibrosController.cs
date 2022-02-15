using CrudNetCore5.Data;
using CrudNetCore5.Models;
using Microsoft.AspNetCore.Mvc;

namespace CrudNetCore5.Controllers
{
    public class LibrosController : Controller
    {
        private readonly ApplicationDbContext _context;
        public LibrosController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            IEnumerable<Libro> listaLibros = _context.Libro;
            return View(listaLibros);
        }

        //Http Get Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        //Http Post Create
        [HttpPost]
        [ValidateAntiForgeryToken]//Para que un bot no pueda hacer peticiones y peticiones del formulario de forma automatica
        public IActionResult Create(Libro libro)
        {
            if (ModelState.IsValid)
            {
                _context.Libro.Add(libro);
                _context.SaveChanges();
                TempData["mensaje"] = "El libro se ha creado correctamente";
                return RedirectToAction("Index");
            }
            return View();
        }
        //Http Get Edit
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if(id == null && id ==0)
            {
                return NotFound();
            };
            Libro l = _context.Libro.Find(id);
            if(l == null)
            {
                return NotFound();
            }

            return View(l);
        }
        //Http Post Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Libro libro)
        {
            if (ModelState.IsValid && libro.Id>0)
            {
                _context.Libro.Update(libro);
                _context.SaveChanges();
                TempData["mensaje"] = "El libro se ha modificado correctamente";
                return RedirectToAction("Index");
            }
            return View();
        }
        //Http Get Delete
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null && id == 0)
            {
                return NotFound();
            };
            Libro l = _context.Libro.Find(id);
            if (l == null)
            {
                return NotFound();
            }

            return View(l);
        }
        //Http Post Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Libro l)
        {
            if (l.Id > 0)
            {
                Libro libro = _context.Libro.Find(l.Id);
                if (libro == null)
                {
                    return NotFound(); 
                }
                _context.Libro.Remove(libro);
                _context.SaveChanges();
                TempData["mensaje"] = "El libro se ha eliminado";
                return RedirectToAction("Index");
            }
            return View();
        }


    }
}
