using System;

namespace LogaresiLoginApp.Models
{
    public class User
    {
        public int Id { get; set; }
        public string TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public string Nombres { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }

        public string Nacionalidad { get; set; }
        public string Sexo { get; set; }
        public DateTime FechaNacimiento { get; set; }

        public string EmailPrincipal { get; set; }
        public string EmailSecundario { get; set; }

        public string TelefonoMovil { get; set; }
        public string TelefonoSecundario { get; set; }

        public string TipoContratacion { get; set; }
        public DateTime FechaContratacion { get; set; }

        public string PasswordHash { get; set; }
        public int IntentosFallidos { get; set; }
        public DateTime? BloqueadoHasta { get; set; }

        public string NombreCompleto
            => $"{Nombres} {ApellidoPaterno} {ApellidoMaterno}";
    }
}
