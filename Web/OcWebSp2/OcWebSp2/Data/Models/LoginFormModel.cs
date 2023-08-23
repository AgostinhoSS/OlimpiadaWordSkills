using System.ComponentModel.DataAnnotations;

namespace BlazorApp1.Data.Models
{
    public class LoginFormModel
    {
        [Required(ErrorMessage = "Favor informar o Email.")]
        [StringLength(225)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Favor informar o Email.")]
        [StringLength(225)]
        public string Senha { get; set; }
    }
}
