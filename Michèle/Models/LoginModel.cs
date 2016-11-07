using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
namespace Michèle.Models
{
    public class GoOnModel
    {
        [Required]
        [Display(Name = "Имя пользователя")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }
        public bool IsFailedAttempt { get; set; }
    }
}