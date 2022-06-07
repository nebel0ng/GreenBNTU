using GreenBNTU.Design.Interfaces;
using GreenBNTU.Design.Models;
using Microsoft.AspNetCore.Mvc;

namespace GreenBNTU.Design.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecObjectController : Controller
    {
        private readonly IAllObjects _allObjects;
        public RecObjectController(IAllObjects allObjects)
        {
            _allObjects = allObjects;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<RecyclableObject>))]
        public IActionResult GetAllObjects()
        {
            var recObjects = _allObjects.GetAllRecObjects();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(recObjects);
        }
    }
}
