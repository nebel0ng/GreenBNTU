using GreenBNTU.Design.Interfaces;
using GreenBNTU.Design.Models;

namespace GreenBNTU.Design.Repository
{
    public class AdminRepository : IAllAdmins
    {
        private readonly Context _context;

        public AdminRepository(Context context)
        {
            _context = context;
        }
        public Admin LoginAdmin(string login, string password)
        {
            return _context.Admins.Where(a => a.Login == login && a.Password ==password).FirstOrDefault();
        }

        public bool AdminExists(string login, string password)
        {
            return _context.Admins.Where(a => a.Login == login && a.Password == password).Any();
        }

        public Admin GetAdminById(int id)
        {
            return _context.Admins.Where(a => a.Id == id).FirstOrDefault();
        }

        public ICollection<Admin> GetAllAdmins()
        {
            return _context.Admins.OrderBy(a => a.Id).ToList();
        }
    }
}
