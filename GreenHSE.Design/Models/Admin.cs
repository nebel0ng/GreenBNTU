using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GreenBNTU.Design.Models
{
    public class Admin
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("Имя")]
        public string Name { get; set; }
        [Required]
        [DisplayName("Пароль")]
        public string Password { get; set; }
        [Required]
        [DisplayName("Логин")]
        public string Login { get; set; }
        public Admin()
        {

        }
        public Admin(string name, string login, string password)
        {
            Name = name;
            Login = login;  
            Password = password;
        }
    }
}
