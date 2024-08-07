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

        [HttpGet]
        public async Task<IActionResult> ObtenerGeneros()
        {
            var client = _httpClientFactory.CreateClient();

            var url = "https://localhost:44315/ObtenerGeneros";

            try
            {
                var response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var datos = await response.Content.ReadFromJsonAsync<List<DepartamentoViewModel>>();
                    return Json(datos);
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Error al obtener los datos del servicio.");
                    return Json(null);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Excepción: {ex.Message}");
                return Json(null);
            }
        }

        [HttpPost]
        public async Task<IActionResult> RegistroMedidasCorporalesPorUsuario([FromBody] RegistroMedidasCorporalesPorUsuarioViewModel usuarioData)
        {
            var httpClient = _httpClientFactory.CreateClient();

            var jsonContent = JsonConvert.SerializeObject(usuarioData);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            try
            {
                // Enviar la solicitud POST
                var response = await httpClient.PostAsync("https://localhost:44315/RegistroMedidasCorporalesPorUsuario", content);

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

        [HttpPost]
        public async Task<IActionResult> IniciarSesion([FromBody] CredencialesUsuarioViewModel credenciales)
        {
            var httpClient = _httpClientFactory.CreateClient();

            var jsonContent = JsonConvert.SerializeObject(credenciales);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            try
            {
                // Enviar la solicitud POST
                var response = await httpClient.PostAsync("https://localhost:44315/IniciarSesion", content);

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
