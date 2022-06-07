using GreenBNTU.Design.Models;

namespace GreenBNTU.Design.Interfaces
{
    public interface IAllAdmins
    {
        Admin LoginAdmin(string login, string password);
        bool AdminExists(string login, string password);
        Admin GetAdminById(int id);
        ICollection<Admin> GetAllAdmins();
    }
}
