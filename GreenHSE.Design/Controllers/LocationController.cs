using GreenBNTU.Design.Interfaces;
using GreenBNTU.Design.Models;
using Microsoft.AspNetCore.Mvc;

namespace GreenBNTU.Design.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : Controller
    {
        private readonly IAllLocations _allLocations;
        public LocationController(IAllLocations allLocations)
        {
            _allLocations = allLocations;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Location>))]
        public IActionResult GetAllLocations()
        {
            var locations = _allLocations.GetAllLocations();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(locations);
        }
    }
}
