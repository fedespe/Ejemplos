using DAL;
using ET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class LibroBL
    {
        private LibroDAL libroDAL = new LibroDAL();
        public void createLibro(Libro l)
        {
            validarLibro(l);
            libroDAL.createLibro(l);
        }
        public void updateLibro(Libro l)
        {
            validarLibro(l);
            libroDAL.updateLibro(l);
        }
        public void deleteLibro(int id)
        {
            Libro l = libroDAL.findById(id);
            if (l == null)
            {
                throw new ProyectoException("Error: No se encontro ningun libro con ese id.");
            }
            libroDAL.deleteLibro(id);
        }
        public List<Libro> FindAllLibros()
        {
            return libroDAL.FindAllLibros();
        }
        public Libro FindById(int id)
        {
            return libroDAL.findById(id);
        }
        private void validarLibro(Libro l)
        {
            if(l.Titulo.Length<2 || l.Titulo.Length > 50)
            {
                throw new ProyectoException("Error: Título");
            }
            if (l.Descripcion.Length < 2 || l.Descripcion.Length > 300)
            {
                throw new ProyectoException("Error: Descripción");
            }
        }
    }
}
