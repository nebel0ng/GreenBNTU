using GreenBNTU.Design.Models;

namespace GreenBNTU.Design.Interfaces
{
    public interface IAllObjects
    {
        RecyclableObject GetObjectById(int id);
        RecyclableObject GetObjectByName(string name);
        string GetObjectName(int id);
        string GetLocationColor(int id);
        ICollection<RecyclableObject> GetAllRecObjects();
        bool ObjectExists(string name);
    }
}
