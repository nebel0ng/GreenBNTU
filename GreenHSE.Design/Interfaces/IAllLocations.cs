using GreenBNTU.Design.Models;

namespace GreenBNTU.Design.Interfaces
{
    public interface IAllLocations
    {
        Location GetLocationById(int id);
        string GetLocationAddress(int id);
        double GetLocationLat(int id);
        double GetLocationLong(int id);
        string GetLocationDesc(int id);
        RecyclableObject GetRecyclableObject(int id);
        ICollection<Location> GetAllLocations();        
    }
}
