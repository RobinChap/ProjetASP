using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Inventions_by_Women.Backoffice.Models
{
    public class AuthencationLoginViewModel
    {
        [Display(Name = "Login")]
        [Required(ErrorMessage = "Login obligatoire")]
        public string Login { get; set; }

        [Display(Name = "Mot de passe")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Mot de passe obligatoire")]
        public string Password { get; set; }


    }
}