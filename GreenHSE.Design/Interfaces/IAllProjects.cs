using GreenBNTU.Design.Models;

namespace GreenBNTU.Design.Interfaces
{
    public interface IAllProjects
    {
        
        Project GetProjectById(int id);
        Project GetProjectByName(string name);
        DateTime GetProjectDate(int id);
        string GetProjectName(int id);
        string GetProjectDescription(int id);   
        string GetProjectLink(int id);  
        bool ProjectExists(int id);
        ICollection<Project> GetAllProjects();
    }
}
