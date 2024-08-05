using Microsoft.AspNetCore.Mvc;
using MVCDimag.Models;
using System.Net.Http;
using System.Text;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace MVCDimag.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public UsuariosController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpPost]
        public async Task<IActionResult> RegistrarUsuario([FromBody] UsuarioViewModel usuario)
        {
            var httpClient = _httpClientFactory.CreateClient();

            var jsonContent = JsonConvert.SerializeObject(usuario);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            try
            {
                // Enviar la solicitud POST
                var response = await httpClient.PostAsync("https://localhost:44315/RegistrarUsuario", content);

                if (!response.IsSuccessStatusCode)
                {
                    // Manejar errores de la solicitud
                    var errorMessage = await response.Content.ReadAsStringAsync();
                    return StatusCode((int)response.StatusCode, errorMessage);
                }

                var result = await response.Content.ReadAsStringAsync();
                // Manejar la respuesta de la API si es necesario
                return Ok(result);
            }
            catch (Exception ex)
            {
                // Manejar excepciones
                return StatusCode(500, "Error en la solicitud: " + ex.Message);
            }
        }
    }
}
