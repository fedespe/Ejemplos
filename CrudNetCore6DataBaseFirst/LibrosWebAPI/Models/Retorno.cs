namespace LibrosWebAPI.Models
{
    public class Retorno
    {
        public int Codigo { get; set; }
        public string Mensaje { get; set; }
        public List<Object> Objetos { get; set; }

        public Retorno()
        {
            Objetos = new List<Object>();
        }
    }
}
