namespace MVCDimag.Models
{
    public class UsuarioViewModel
    {
        public int Id { get; set; }

        public string PrimerNombre { get; set; }

        public string SegundoNombre { get; set; }

        public string PrimerApellido { get; set; }

        public string SegundoApellido { get; set; }    

        public int DepartamentoId { get; set; }

        public int CiudadOMunicipioId { get; set; }

        public string Email { get; set; }

        public string Celular { get; set; }

        public string NombreUsuario { get; set; }

        public string Password { get; set; }
        public UsuarioViewModel()
        {
            PrimerNombre = string.Empty;
            SegundoNombre = string.Empty;
            PrimerApellido = string.Empty;
            SegundoApellido = string.Empty;
            Email = string.Empty;
            Celular = string.Empty;
            NombreUsuario = string.Empty;
            Password = string.Empty;
        }
    }
}
