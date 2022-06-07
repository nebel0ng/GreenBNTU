using GreenBNTU.Design.Interfaces;
using GreenBNTU.Design.Models;

namespace GreenBNTU.Design.Repository
{
    public class ProjectRepository : IAllProjects
    {
        private readonly Context _context;

        public ProjectRepository(Context context)
        {
            _context = context;
        }

        public ICollection<Project> GetAllProjects()
        {
            return _context.Projects.OrderBy(p => p.Id).ToList();
        }

        public Project GetProjectById(int id)
        {
            return _context.Projects.Where(p => p.Id == id).FirstOrDefault();
        }

        public Project GetProjectByName(string name)
        {
            return _context.Projects.Where(p => p.Name == name).FirstOrDefault();
        }

        public DateTime GetProjectDate(int id)
        {
            return _context.Projects.Where(p => p.Id == id).FirstOrDefault().SignUpTill;
        }

        public string GetProjectDescription(int id)
        {
            return _context.Projects.Where(p => p.Id == id).FirstOrDefault().Desc;
        }

        public string GetProjectLink(int id)
        {
            return _context.Projects.Where(p => p.Id == id).FirstOrDefault().Link;
        }

        public string GetProjectName(int id)
        {
            return _context.Projects.Where(p => p.Id == id).FirstOrDefault().Name;
        }

        public bool ProjectExists(int id)
        {
            return _context.Projects.Where(p => p.Id == id).Any();
        }

        
    }
}
