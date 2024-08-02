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
            CreateMap<Usuario, UsuarioDto>();
            CreateMap<UsuarioDto, Usuario>();
        }
    }
}
