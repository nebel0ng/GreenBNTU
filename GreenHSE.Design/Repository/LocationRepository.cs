using GreenBNTU.Design.Interfaces;
using GreenBNTU.Design.Models;

namespace GreenBNTU.Design.Repository
{
    public class LocationRepository : IAllLocations
    {
        private readonly Context _context;

        public LocationRepository(Context context)
        {
            _context = context;
        }

        public ICollection<Location> GetAllLocations()
        {
            return _context.Locations.OrderBy(l => l.Id).ToList();
        }

        public string GetLocationAddress(int id)
        {
            return _context.Locations.Where(l => l.Id == id).FirstOrDefault().Address;
        }

        public Location GetLocationById(int id)
        {
            return _context.Locations.Where(l => l.Id == id).FirstOrDefault();
        }

        public string GetLocationDesc(int id)
        {
            return _context.Locations.Where(l => l.Id == id).FirstOrDefault().Description;
        }

        public double GetLocationLat(int id)
        {
            return _context.Locations.Where(l => l.Id == id).FirstOrDefault().GeoLat;
        }

        public double GetLocationLong(int id)
        {
            return _context.Locations.Where(l => l.Id == id).FirstOrDefault().GeoLong;
        }

        public RecyclableObject GetRecyclableObject(int id)
        {
            return _context.Locations.Where(l => l.Id == id).FirstOrDefault().RecObject;
        }
    }
}
