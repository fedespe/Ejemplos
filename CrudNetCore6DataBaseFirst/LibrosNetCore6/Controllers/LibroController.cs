using BL;
using Microsoft.AspNetCore.Mvc;

namespace LibrosNetCore6.Controllers
{
    public class LibroController : Controller
    {
        private LibroBL libroBL = new LibroBL();
        public IActionResult Index()
        {
            return View(libroBL.FindAllLibros());
        }
    }
}
