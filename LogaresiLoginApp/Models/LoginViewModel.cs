using System.ComponentModel.DataAnnotations;

namespace LogaresiLoginApp.Models {
    public class LoginViewModel {
 
        public string Usuario { get; set; }
        public string Password { get; set; }
        public string TipoDocumento { get; set; }

    }
}