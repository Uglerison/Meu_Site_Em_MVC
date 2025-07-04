using Meu_Site_Em_MVC.Enums;

namespace Meu_Site_Em_MVC.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public PerfilEnum perfil { get; set; }
        public DateTime DateOfRegistry { get; set; }
        public DateTime? DateOfChange { get; set; }
    }
}
