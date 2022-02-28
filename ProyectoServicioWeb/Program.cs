using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using ProyectoServicioWeb;
using ProyectoServicioWeb.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//Debo colocar estas dos lineas de codigo para conexion a la api.
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://jsonplaceholder.typicode.com/") });
builder.Services.AddScoped<IPruebaService, PruebaService>();

await builder.Build().RunAsync();
