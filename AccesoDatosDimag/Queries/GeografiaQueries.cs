using AccesoDatosDimag.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatosDimag.Models;
using System.Net.Http.Headers;

namespace AccesoDatosDimag.Queries
{
    public class GeografiaQueries
    {
        public readonly DimagDBContext _context;
        public GeografiaQueries(DimagDBContext context)
        {
            _context = context;
        }

        public List<Departamento> ObtenerDepartamentos()
        {
            return _context.Departamentos.ToList();
        }

        public List<CiudadOMunicipio> ObtenerCiudadesOMunicipiosPorDepartamento(int departamentoId)
        {
            var ciudadesOMunicipios = (from com in _context.CiudadesOMunicipios
                                       where com.DepartamentoId == departamentoId
                                       select com).ToList();

            return ciudadesOMunicipios;
        }
    }
}
