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
using BCrypt.Net;

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

        public int RegistrarUsuario(UsuarioDto usuarioDto)
        {
            usuarioDto.Password = EncriptarContraseña(usuarioDto.Password);

            var usuario = _mapper.Map<Usuario>(usuarioDto);

            return _queries.RegistrarUsuario(usuario);
        }

        public string EncriptarContraseña(string contraseña)
        {
            return BCrypt.Net.BCrypt.HashPassword(contraseña);
        }

        public UsuarioDto ConsultarUsuarioPorNombreUsuario(string nombreUsuario)
        {
            var usuario = _queries.ConsultarUsuarioPorNombreUsuario(nombreUsuario);

            var usuarioDto = _mapper.Map<UsuarioDto>(usuario);

            return usuarioDto;
        }

        public bool EliminarUsuarioPorNombreUsuario(string nombreUsuario)
        {
            return _queries.EliminarUsuarioPorNombreUsuario(nombreUsuario);
        }
    }
}
