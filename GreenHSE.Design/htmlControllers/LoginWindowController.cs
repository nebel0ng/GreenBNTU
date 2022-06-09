using GreenBNTU.Design.Interfaces;
using GreenBNTU.Design.Models;
using Microsoft.AspNetCore.Mvc;

namespace GreenBNTU.Design.htmlControllers
{
    public class LoginWindowController : Controller
    {
        private readonly IAllAdmins _AllAdmins;

        public LoginWindowController(IAllAdmins allAdmins)
        {
            _AllAdmins = allAdmins;
        }
        public ActionResult LoginWindow()
        {
            return View("LoginWindow");
        }

        public ViewResult Login(Admin admin)
        {           
            var currentAdmin = new Admin();
            if (_AllAdmins.AdminExists(admin.Login, admin.Password))
            {
                currentAdmin = _AllAdmins.LoginAdmin(admin.Login, admin.Password);
            }
            while(currentAdmin.Password == null)
            {
                return View("LoginWindow");
            }
            return View("AboutLogged");
        }
    }
}
