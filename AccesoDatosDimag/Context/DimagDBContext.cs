using Microsoft.EntityFrameworkCore;
using AccesoDatosDimag.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatosDimag.Context
{
    public class DimagDBContext : DbContext 
    {
        public static string ConnectionString;

        public DimagDBContext()
        {

        }
        public DimagDBContext(DbContextOptions<DimagDBContext> options): base(options) 
        { 
               
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //En caso de que el contexto no este configurado, lo configuramos mediante la cadena de conexion
            if (!optionsBuilder.IsConfigured)
            {
                lock (ConnectionString)
                {
                    optionsBuilder.UseSqlServer(ConnectionString, b =>
                        b.MigrationsAssembly("WebApiDIMAG"));
                }
            }
        }

        public DbSet<CiudadOMunicipio> CiudadesOMunicipios { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Genero> Generos { get; set; }
        public DbSet<MedidaPorTallaYGenero> MedidasPorTallaYGenero { get; set; }
        public DbSet<RegistroMedidasCorporalesPorUsuario> RegistrosMedidasCorporalesPorUsuario { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        
    }
}
