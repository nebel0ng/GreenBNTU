using GreenBNTU.Design.Interfaces;
using GreenBNTU.Design.Repository;
using GreenBNTU.Design.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GreenBNTU.Design.htmlControllers
{
    public class LoginWindowController : Controller
    {
        public ActionResult LoginWindow()
        {
            return View("LoginWindow");
        }

        public ViewResult Login(Admin admin)
        {
            var contextOptions = new DbContextOptions<Context>();
            var context = new Context(contextOptions);
            var adminRep = new AdminRepository(context);
            var currentAdmin = new Admin();
            if (adminRep.AdminExists(admin.Login, admin.Password))
            {
                currentAdmin = adminRep.LoginAdmin(admin.Login, admin.Password);
            }
            while(currentAdmin.Password == null)
            {
                return View("LoginWindow");
            }
            return View("AboutLogged");
        }
    }
}
