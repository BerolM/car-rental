using System.ComponentModel.DataAnnotations;

namespace Domain.DTOs
{
    public class UserRegisterDTO
    {
        [Display(Name ="Adı")]
        public string FirstName { get; set; }

        [Display(Name = "Soyadı")]
        public string LastName { get; set; }

        [Display(Name = "E-Posta Adresi")]
        public string EMail { get; set; }

        [Display(Name = "Parola")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}
