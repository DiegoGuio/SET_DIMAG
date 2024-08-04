using AccesoDatosDimag.Models;
using AccesoDatosDimag.Queries;
using AutoMapper;
using LogicaNegocioDimag.MappingProfle;
using LogicaNegocioDimag.Models.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocioDimag.BL
{
    public class GeografiaBL
    {
        public readonly GeografiaQueries _queries;

        private readonly IMapper _mapper;

        public GeografiaBL(GeografiaQueries queries)
        {
            _queries = queries;

            var mapperConfig = new MapperConfiguration(mc => {
                mc.AddProfile(new MappingProfile());
            });

            _mapper = mapperConfig.CreateMapper();
        }

        public List<DepartamentoDto> ObtenerDepartamentos()
        {
            var departamentos = _queries.ObtenerDepartamentos();
            var departamentosDto = _mapper.Map<List<DepartamentoDto>>(departamentos);

            return departamentosDto;
        }

        public List<CiudadOMunicipioDto> ObtenerCiudadesOMunicipiosPorDepartamento(int departamentoId)
        {
            var ciudadesOMunicipios = _queries.ObtenerCiudadesOMunicipiosPorDepartamento(departamentoId);
            var ciudadesOMunicipiosDto = _mapper.Map<List<CiudadOMunicipioDto>>(ciudadesOMunicipios);

            return ciudadesOMunicipiosDto;
        }
    }
}
