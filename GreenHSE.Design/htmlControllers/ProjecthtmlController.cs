using GreenBNTU.Design.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GreenBNTU.Design.htmlControllers
{
    public class ProjecthtmlController : Controller
    {
        private readonly IAllProjects _allProjects;

        public ProjecthtmlController(IAllProjects allProjects)
        {
            _allProjects = allProjects;
        }

        public ViewResult ProjectList()
        {
            var projects = _allProjects.GetAllProjects();
            return View(projects);
        }

        public ViewResult ProjectListLogged()
        {
            var projects = _allProjects.GetAllProjects();
            return View(projects);
        }
    }
}
