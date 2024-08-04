using LogicaNegocioDimag.BL;
using LogicaNegocioDimag.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace WebApiDIMAG.Controllers
{
    public class GeografiaController : Controller
    {
        public readonly GeografiaBL _bL;

        public GeografiaController(GeografiaBL bL)
        {
            _bL = bL;
        }

        [HttpGet("ObtenerDepartamentos")]
        public List<DepartamentoDto> ObtenerDepartamentos()
        {
            return _bL.ObtenerDepartamentos();
        }

        [HttpGet("ObtenerCiudadesOMunicipiosPorDepartamento")]
        public List<CiudadOMunicipioDto> ObtenerCiudadesOMunicipiosPorDepartamento(int departamentoId)
        {
            return _bL.ObtenerCiudadesOMunicipiosPorDepartamento(departamentoId);
        }
    }
}
