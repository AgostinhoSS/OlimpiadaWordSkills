using System.ComponentModel.DataAnnotations;

namespace OcWebSp.Data.Models
{
    public class Usuario
    {
        [Required(ErrorMessage ="Favor informar o Email.")]
        [StringLength(225)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Favor informar a Senha.")]
        [StringLength(50)]
        public string Senha { get; set; }
        
    }
}
