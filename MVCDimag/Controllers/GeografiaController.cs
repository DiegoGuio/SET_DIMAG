using Microsoft.AspNetCore.Mvc;
using MVCDimag.Models;

namespace MVCDimag.Controllers
{
    public class GeografiaController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public GeografiaController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerDepartamentos()
        {
            var client = _httpClientFactory.CreateClient();

            var url = "https://localhost:44315/ObtenerDepartamentos";

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
    }
}
