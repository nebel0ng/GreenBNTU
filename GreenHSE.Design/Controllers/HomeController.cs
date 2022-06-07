using Microsoft.AspNetCore.Mvc;

namespace GreenBNTU.Design.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            
            return View();  
        }
        public ViewResult AboutLogged()
        {

            return View();
        }
    }
}
