using GreenBNTU.Design.Models;
using GreenBNTU.Design.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GreenBNTU.Design.htmlControllers
{
    public class GoogleMapsController : Controller
    {
        public ActionResult GoogleMap()
        {
            var contextOptions = new DbContextOptions<Context>();
            var context = new Context(contextOptions);
            var recObjectRepository = new RecObjectRepository(context);
            var recObjects = recObjectRepository.GetAllRecObjects();
            var locationRep = new LocationRepository(context);
            var locations = locationRep.GetAllLocations();
            return View(locations);
        }

        public ActionResult GoogleMapLogged()
        {
            var contextOptions = new DbContextOptions<Context>();
            var context = new Context(contextOptions);
            var recObjectRepository = new RecObjectRepository(context);
            var recObjects = recObjectRepository.GetAllRecObjects();
            var locationRep = new LocationRepository(context);
            var locations = locationRep.GetAllLocations();
            return View(locations);
        }

    }
}
