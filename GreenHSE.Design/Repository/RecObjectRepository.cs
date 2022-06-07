using GreenBNTU.Design.Interfaces;
using GreenBNTU.Design.Models;

namespace GreenBNTU.Design.Repository
{
    public class RecObjectRepository : IAllObjects
    {
        private readonly Context _context;

        public RecObjectRepository(Context context)
        {
            _context = context;
        }
        public ICollection<RecyclableObject> GetAllRecObjects()
        {
            return _context.RecObjects.OrderBy(ro => ro.Id).ToList();
        }

        public string GetLocationColor(int id)
        {
            return _context.RecObjects.OrderBy(ro => ro.Id == id).FirstOrDefault().Color;
        }

        public RecyclableObject GetObjectById(int id)
        {
            return _context.RecObjects.Where(ro => ro.Id == id).FirstOrDefault();
        }

        public RecyclableObject GetObjectByName(string name)
        {
            return _context.RecObjects.Where(ro => ro.Name == name).FirstOrDefault();
        }

        public string GetObjectName(int id)
        {
            return _context.RecObjects.OrderBy(ro => ro.Id == id).FirstOrDefault().Name;
        }

        public bool ObjectExists(string name)
        {
            return _context.RecObjects.Where(ro => ro.Name == name).Any();
        }
    }
}
