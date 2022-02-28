using Newtonsoft.Json;

namespace ProyectoServicioWeb.Models
{
    public class Publicacion
    {
        //Se agregan las jsonpropety de jason.net para deserializar los objetos,
        //de esta manera se les ponen los mismos nobres que tendrian las propiedades de la API
        //En el modelo se podria llamar IdUsuario ya aca le agrego [JsonProperty("userId")]
        [JsonProperty("userId")]
        public int userId { get; set; }
        [JsonProperty("id")]
        public int id { get; set; }
        [JsonProperty("title")]
        public string title { get; set; }
        [JsonProperty("body")]
        public string body { get; set; }
    }
}
