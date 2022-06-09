using GreenBNTU.Design.Interfaces;
using GreenBNTU.Design.Models;
using Microsoft.AspNetCore.Mvc;

namespace GreenBNTU.Design.htmlControllers
{
    public class GoogleMapsController : Controller
    {
        private readonly IAllLocations _allLocations;
        private readonly IAllObjects _allObjects;
        public GoogleMapsController(IAllLocations allLocations, IAllObjects allObjects)
        {
            _allLocations = allLocations;
            _allObjects = allObjects;
        }
        
        public ActionResult GoogleMap()
        {
            var recObjects = _allObjects.GetAllRecObjects();
            var locations = _allLocations.GetAllLocations();
            return View(new Tuple<ICollection<Location>, ICollection<RecyclableObject>>(locations, recObjects));
        }

        public ActionResult GoogleMapLogged()
        {
            var recObjects = _allObjects.GetAllRecObjects();
            var locations = _allLocations.GetAllLocations();
            return View(new Tuple<ICollection<Location>, ICollection<RecyclableObject>>(locations, recObjects));
        }

    }
}
