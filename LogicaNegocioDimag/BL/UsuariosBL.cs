using AccesoDatosDimag.Models;
using AccesoDatosDimag.Queries;
using AutoMapper;
using LogicaNegocioDimag.MappingProfle;
using LogicaNegocioDimag.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocioDimag.BL
{
    public class UsuariosBL
    {
        public readonly UsuariosQueries _queries;

        private readonly IMapper _mapper;

        public UsuariosBL(UsuariosQueries queries)
        {
            _queries = queries;

            var mapperConfig = new MapperConfiguration(mc => {
                mc.AddProfile(new MappingProfile());
            });

            _mapper = mapperConfig.CreateMapper();
        }

        public bool RegistrarOActualizarUsuario(UsuarioDto usuarioDto)
        {
            var usuario = _mapper.Map<Usuario>(usuarioDto);

            return _queries.RegistrarOActualizarUsuario(usuario);
        }

        public UsuarioDto ConsultarUsuarioPorDocumentoIdentidad(int tipoDocumentoId, string numeroDocumento)
        {
            var usuario = _queries.ConsultarUsuarioPorDocumentoIdentidad(tipoDocumentoId, numeroDocumento);

            var usuarioDto = _mapper.Map<UsuarioDto>(usuario);

            return usuarioDto;
        }

        public bool EliminarUsuarioPorDocumentoIdentidad(int tipoDocumentoId, string numeroDocumento)
        {
            return _queries.EliminarUsuarioPorDocumentoIdentidad(tipoDocumentoId, numeroDocumento);
        }
    }
}
