using ET;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class LibroDAL
    {
        public void createLibro(Libro l)
        {
            string cadenaInsert = @"INSERT INTO LIBRO VALUES(@titulo, @descripcion, @fechaLanzamiento, 
                                    @autor, @precio);";
            try
            {
                using (SqlConnection con = new SqlConnection(Utilidades.conn))
                {
                    using (SqlCommand cmd = new SqlCommand(cadenaInsert, con))
                    {
                        cmd.Parameters.AddWithValue("@titulo", l.Titulo);
                        cmd.Parameters.AddWithValue("@descripcion", l.Descripcion);
                        cmd.Parameters.AddWithValue("@fechaLanzamiento", l.FechaLanzamiento);
                        cmd.Parameters.AddWithValue("@autor", l.Autor);
                        cmd.Parameters.AddWithValue("@precio", l.Precio);

                        con.Open();

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new ProyectoException("Error: " + ex.Message);
            }
        }

        public static Libro findById(int id)
        {
            throw new NotImplementedException();
        }

        public void deleteLibro(Libro l)
        {
            throw new NotImplementedException();
        }

        public void updateLibro(Libro l)
        {
            throw new NotImplementedException();
        }

        public List<Libro> FindAllLibros()
        {
            List<Libro> libros = new List<Libro>();
            string cadenaSelect = @"SELECT l.Id as IdLibro, l.Titulo as Titulo, l.Descripcion as Descripcion, l.FechaLanzamiento as FechaLanzamiento
                                    , l.Autor as Autor, l.Precio as Precio FROM LIBRO l;";
            try
            {
                using (SqlConnection con = new SqlConnection(Utilidades.conn))
                {
                    con.Open();

                    using (SqlCommand cmd = new SqlCommand(cadenaSelect, con))
                    {
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                Libro libro = new Libro
                                {
                                    Id = Convert.ToInt32(dr["IdLibro"]),
                                    Titulo = dr["Titulo"].ToString(),
                                    Descripcion = dr["Descripcion"].ToString(),
                                    FechaLanzamiento = Convert.ToDateTime(dr["FechaLanzamiento"]),
                                    Autor = dr["Autor"].ToString(),
                                    Precio = Convert.ToDouble(dr["Precio"]),

                                };
                                libros.Add(libro);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new ProyectoException("Error: " + ex.Message);
            }

            return libros;
        }
    }
}
