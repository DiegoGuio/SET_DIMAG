using AccesoDatosDimag.Context;
using AccesoDatosDimag.Models;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatosDimag.Queries
{
    public class UsuariosQueries
    {
        public readonly DimagDBContext _context;
        public UsuariosQueries(DimagDBContext context) 
        {
            _context = context;
        }

        public bool RegistrarOActualizarUsuario(Usuario usuario)
        {
            try
            {
                var usuarioRegistrado = (from u in _context.Usuarios
                                         where u.NumeroDocumento == usuario.NumeroDocumento
                                         select u).FirstOrDefault();

                if (usuarioRegistrado == null)
                {
                    _context.Usuarios.Add(usuario);
                }
                else
                {
                    usuarioRegistrado.PrimerNombre = usuario.PrimerNombre;
                    usuarioRegistrado.SegundoNombre = usuario.SegundoNombre;
                    usuarioRegistrado.PrimerApellido = usuario.PrimerApellido;
                    usuarioRegistrado.SegundoApellido = usuario.SegundoApellido;
                    usuarioRegistrado.TipoDocumentoId = usuario.TipoDocumentoId;
                    usuarioRegistrado.NumeroDocumento = usuario.NumeroDocumento;
                    usuarioRegistrado.PaisId = usuario.PaisId;
                    usuarioRegistrado.DepartamentoId = usuario.DepartamentoId;
                    usuarioRegistrado.Email = usuario.Email;
                    usuarioRegistrado.Celular = usuario.Celular;
                    usuarioRegistrado.NombreUsuario = usuario.NombreUsuario;
                    usuarioRegistrado.Password = usuario.Password;

                    _context.Usuarios.Update(usuarioRegistrado);
                }

                _context.SaveChanges();

                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public Usuario ConsultarUsuarioPorDocumentoIdentidad(int tipoDocumentoId, string numeroDocumento)
        {
            try
            {
                var usuario = (from u in _context.Usuarios
                               where u.TipoDocumentoId == tipoDocumentoId && u.NumeroDocumento == numeroDocumento
                               select u).FirstOrDefault();

                return usuario;
            }
            catch (Exception)
            {

                return new Usuario();
            }
            
        }

        public bool EliminarUsuarioPorDocumentoIdentidad(int tipoDocumentoId, string numeroDocumento)
        {
            try
            {
                var usuario = (from u in _context.Usuarios
                               where u.TipoDocumentoId == tipoDocumentoId && u.NumeroDocumento == numeroDocumento
                               select u).FirstOrDefault();

                if (usuario == null)
                {
                    return false;
                }

                _context.Usuarios.Remove(usuario);
                _context.SaveChanges();

                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
