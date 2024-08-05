using AccesoDatosDimag.Models;
using AutoMapper;
using LogicaNegocioDimag.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocioDimag.MappingProfle
{
    public class MappingProfile : Profile 
    {
        public MappingProfile() 
        {    
            CreateMap<CiudadOMunicipio, CiudadOMunicipioDto>();
            CreateMap<CiudadOMunicipioDto, CiudadOMunicipio>();
            CreateMap<Departamento, DepartamentoDto>();
            CreateMap<DepartamentoDto, Departamento>();
            CreateMap<Genero, GeneroDto>();
            CreateMap<GeneroDto, Genero>();
            CreateMap<MedidaPorTallaYGenero, MedidaPorTallaYGeneroDto>();
            CreateMap<MedidaPorTallaYGeneroDto, MedidaPorTallaYGenero>();
            CreateMap<RegistroMedidasCorporalesPorUsuario, RegistroMedidasCorporalesPorUsuarioDto>();
            CreateMap<RegistroMedidasCorporalesPorUsuarioDto, RegistroMedidasCorporalesPorUsuario>();
            CreateMap<Usuario, UsuarioDto>();
            CreateMap<UsuarioDto, Usuario>();
        }
    }
}
