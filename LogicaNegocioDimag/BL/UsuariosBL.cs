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
using Microsoft.EntityFrameworkCore;

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

        public List<GeneroDto> ObtenerGeneros()
        {
            var generos = _queries.ObtenerGeneros();
            var generosDto = _mapper.Map<List<GeneroDto>>(generos);

            return generosDto;
        }

        public RegistroMedidasCorporalesPorUsuarioDto RegistroMedidasCorporalesPorUsuario(RegistroMedidasCorporalesPorUsuarioDto data)
        {
            data.FechaRegistro =  DateTime.Now;
            var registroMedidasCorporalesPorUsuario = _mapper.Map<RegistroMedidasCorporalesPorUsuario>(data);
            var registroMedidas = _queries.RegistroMedidasCorporalesPorUsuario(registroMedidasCorporalesPorUsuario);
            var registroMedidasCorporalesPorUsuarioDto = _mapper.Map<RegistroMedidasCorporalesPorUsuarioDto>(registroMedidas);

            return registroMedidasCorporalesPorUsuarioDto;
        }

        public int IniciarSesion(CredencialesUsuarioDto credenciales)
        {
            var credencialesUsuario = _mapper.Map<CredencialesUsuario>(credenciales);
            var usuario = _queries.IniciarSesion(credencialesUsuario);
            var verificarContraseña = VerificarContraseña(credenciales.Password, usuario.Password);

            if (verificarContraseña)
            {
                return 1; //Datos correctos
            }
            else
            {
                return -2; //Datos incorrectos
            }
   
        }

        public bool VerificarContraseña(string contraseñaIngresada, string contraseñaAlmacenada)
        {
            try
            {
                return BCrypt.Net.BCrypt.Verify(contraseñaIngresada, contraseñaAlmacenada);
            }
            catch (Exception)
            {
                return false;
            }
            
        }
    }
}
