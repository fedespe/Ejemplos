using Newtonsoft.Json;
using ProyectoServicioWeb.Models;

namespace ProyectoServicioWeb.Services
{
    public class PruebaService : IPruebaService
    {
        private readonly HttpClient _httpClient;
        public PruebaService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Publicacion>> GetAll()
        {
            //Deserializo el objeto para transformar el string a el objeto,
            //la respuesta viene en un string debido a GetStringAscync
            //JsonConvert es del paquete json.net instalado
            return JsonConvert.DeserializeObject<IEnumerable<Publicacion>>(
                await _httpClient.GetStringAsync($"posts"));
        }

        public async Task<Publicacion> GetById(int id)
        {
            return JsonConvert.DeserializeObject<Publicacion>(
                await _httpClient.GetStringAsync($"posts/{id}"));
        }
    }
}
