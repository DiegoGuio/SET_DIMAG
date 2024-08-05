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

        public int RegistrarUsuario(Usuario usuario)
        {
            try
            {
                var usuarioRegistrado = (from u in _context.Usuarios
                                         where u.PrimerNombre == usuario.PrimerNombre &&
                                         u.PrimerApellido == usuario.PrimerApellido &&
                                         u.DepartamentoId == usuario.DepartamentoId &&
                                         u.CiudadOMunicipioId == usuario.CiudadOMunicipioId &&
                                         u.Email == usuario.Email &&
                                         u.Celular == usuario.Celular
                                         select u).FirstOrDefault();

                if (usuarioRegistrado == null)
                {
                    _context.Usuarios.Add(usuario);
                    _context.SaveChanges();
                    return 1; //"Usuario registrado con éxito";
                }
                else
                {
                    return 2; //"El usuario ya se encuentra registrado";
                }   
            }
            catch (Exception)
            {
                return 3; //"Error de registro";
            }
        }

        public Usuario ConsultarUsuarioPorNombreUsuario(string nombreUsuario)
        {
            try
            {
                var usuario = (from u in _context.Usuarios
                               where u.NombreUsuario == nombreUsuario
                               select u).FirstOrDefault();

                return usuario;
            }
            catch (Exception)
            {

                return new Usuario();
            }
            
        }

        public bool EliminarUsuarioPorNombreUsuario(string nombreUsuario)
        {
            try
            {
                var usuario = (from u in _context.Usuarios
                               where u.NombreUsuario == nombreUsuario
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

        public List<Genero> ObtenerGeneros()
        {
            return _context.Generos.ToList();
        }

        public RegistroMedidasCorporalesPorUsuario RegistroMedidasCorporalesPorUsuario(RegistroMedidasCorporalesPorUsuario data)
        {
            try
            {
                var talla = (from mptg in _context.MedidasPorTallaYGenero
                             where mptg.GeneroId == data.GeneroId &&
                                data.ContornoPecho >= mptg.ContornoMinimoPecho &&
                                data.ContornoPecho <= mptg.ContornoMaximoPecho &&
                                data.ContornoCintura >= mptg.ContornoMinimoCintura &&
                                data.ContornoCintura <= mptg.ContornoMaximoCintura &&
                                data.ContornoCadera >= mptg.ContornoMinimoCadera &&
                                data.ContornoCadera <= mptg.ContornoMaximoCadera &&
                                data.LongitudHombro >= mptg.LongitudMinimaHombro &&
                                data.LongitudHombro <= mptg.LongitudMaximaHombro
                             select mptg.Talla).FirstOrDefault();

                if (talla != null) 
                {
                    data.TallaSETDimag = talla;
                    _context.RegistrosMedidasCorporalesPorUsuario.Add(data);
                    _context.SaveChanges();

                    return data;
                }
                else {
                    return new RegistroMedidasCorporalesPorUsuario();
                }
            }
            catch (Exception)
            {
                throw;
            }
           
        }
    }
}
