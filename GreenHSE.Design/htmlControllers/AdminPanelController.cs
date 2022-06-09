using GreenBNTU.Design.Models;
using GreenBNTU.Design.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GreenBNTU.Design.Repository;

namespace GreenBNTU.Design.htmlControllers
{
    public class AdminPanelController : Controller
    {
        private readonly IAllProjects _allProjects;
        private readonly IAllLocations _allLocations;
        private readonly IAllObjects _allRecObjects;
        private readonly IAllAdmins _allAdmins;

        public AdminPanelController(IAllProjects allProjects, IAllLocations allLocations, IAllObjects allObjects, IAllAdmins allAdmins)
        {
            _allProjects = allProjects;
            _allLocations = allLocations;
            _allRecObjects = allObjects;
            _allAdmins = allAdmins;
        }

        public ViewResult AdminPanel()
        {
            
            var recObjects = _allRecObjects.GetAllRecObjects();
            var projects = _allProjects.GetAllProjects();
            var admins = _allAdmins.GetAllAdmins();
            var locations = _allLocations.GetAllLocations();
            var newLocation = new Location();
            var newRecObject = new RecyclableObject();
            var newAdmin = new Admin();

            return View(new Tuple<ICollection<Location>, Location, RecyclableObject, Admin, ICollection<RecyclableObject>, ICollection<Project>, ICollection<Admin>>(locations, newLocation, newRecObject, newAdmin, recObjects, projects, admins));
        }
        

        //ProjectCreate
        public ViewResult CreateProjectForm()
        {
            return View();
        }

        public ViewResult ProjectDetails(int id)
        {
            var project = _allProjects.GetProjectById(id);


            return View(project);
        }

        public ViewResult CreateProject(Project project)
        {
            var contextOptions = new DbContextOptions<Context>();
            var context = new Context(contextOptions);

            Project newProject = new Project(project.Name, project.Desc, project.SignUpTill, project.Link);

            context.Projects.Add(newProject);
            context.SaveChanges();

            return View("ProjectDetails", project);
        }


        //LocationCreate        
        public ViewResult CreateLocationForm()
        {
            return View();
        }

        public ViewResult LocationDetails(int id)
        {
            var location = _allLocations.GetLocationById(id);

            return View(location);
        }

        public ViewResult CreateLocation(Location location)
        {
            var contextOptions = new DbContextOptions<Context>();
            var context = new Context(contextOptions);

            Location newLocation = new Location(location.Address, location.Description, location.GeoLat, location.GeoLong, _allRecObjects.GetObjectByName(location.RecObject.Name));

            while (!_allRecObjects.ObjectExists(location.RecObject.Name))
            {
                return View("CreateLocationForm", location);
            }
            int rowsInserted = context.Database.ExecuteSqlRaw($"insert into dbo.Locations(Address, Description, GeoLong, GeoLat, RecObjectId) values('{location.Address}', '{location.Description}', '{location.GeoLong}', '{location.GeoLat}', '{_allRecObjects.GetObjectByName(location.RecObject.Name).Id}')");
            context.SaveChanges();

            return View("LocationDetails", location);
        }


        //ROCreate
        public ViewResult CreateRecObjectForm()
        {
            return View();
        }

        public ViewResult RecObjectDetails(int id)
        {
            var recObj = _allRecObjects.GetObjectById(id);


            return View(recObj);
        }

        public ViewResult CreateRecObject(RecyclableObject recObject)
        {
            var contextOptions = new DbContextOptions<Context>();
            var context = new Context(contextOptions);

            RecyclableObject recyclableObject = new RecyclableObject(recObject.Name, recObject.Color);

            context.RecObjects.Add(recyclableObject);
            context.SaveChanges();

            return View("RecObjectDetails", recyclableObject);
        }


        //AdminCreate
        public ViewResult CreateAdminForm()
        {
            return View();
        }

        public ViewResult AdminDetails(int id)
        {
            var admin = _allAdmins.GetAdminById(id);


            return View(admin);
        }

        public ViewResult CreateAdmin(Admin admin)
        {
            var contextOptions = new DbContextOptions<Context>();
            var context = new Context(contextOptions);

            Admin newAdmin = new Admin(admin.Name, admin.Login, admin.Password);

            context.Admins.Add(newAdmin);
            context.SaveChanges();

            return View("AdminDetails", newAdmin);
        }



        //ProjectEdit
        public ViewResult EditProjectForm(int id)
        {
            var project = _allProjects.GetProjectById(id);
            
            return View(project);
        }

        public ViewResult EditProject(Project project)
        {
            var contextOptions = new DbContextOptions<Context>();
            var context = new Context(contextOptions);
            var editedProject = context.Projects.FirstOrDefault(p => p.Id == project.Id);

            editedProject.Name = project.Name;
            editedProject.Desc = project.Desc;
            editedProject.SignUpTill = project.SignUpTill;
            editedProject.Link = project.Link;

            context.SaveChanges();

            return View("ProjectDetails", context.Projects.FirstOrDefault(p => p.Id == project.Id));
        }



        //LocationEdit
        public ViewResult EditLocationForm(int id)
        {
            var location = _allLocations.GetLocationById(id);

            return View(location);
        }

        public ViewResult EditLocation(Location location)
        {
            while (!_allRecObjects.ObjectExists(location.RecObject.Name))
            {
                return View("EditLocationForm", location);
            }
            var contextOptions = new DbContextOptions<Context>();
            var context = new Context(contextOptions);
            var editedLocation = context.Locations.FirstOrDefault(l => l.Id == location.Id);            

            editedLocation.Address = location.Address;
            editedLocation.Description = location.Description;
            editedLocation.GeoLat = location.GeoLat;
            editedLocation.GeoLong = location.GeoLong;
            editedLocation.RecObject = _allRecObjects.GetObjectByName(location.RecObject.Name);

            context.SaveChanges();

            return View("LocationDetails", context.Locations.FirstOrDefault(p => p.Id == location.Id));
        }



        //ROEdit
        public ViewResult EditROForm(int id)
        {
            var recObject = _allRecObjects.GetObjectById(id);

            return View(recObject);
        }

        public ViewResult EditRO(RecyclableObject recObject)
        {
            var contextOptions = new DbContextOptions<Context>();
            var context = new Context(contextOptions);
            var editedRO = context.RecObjects.FirstOrDefault(ro => ro.Id == recObject.Id);

            editedRO.Name = recObject.Name;
            editedRO.Color = recObject.Color;

            context.SaveChanges();

            return View("RecObjectDetails", context.RecObjects.FirstOrDefault(ro => ro.Id == recObject.Id));
        }



        //AdminEdit
        public ViewResult EditAdminForm(int id)
        {
            var admin = _allAdmins.GetAdminById(id);

            return View(admin);
        }

        public ViewResult EditAdmin(Admin admin)
        {
            var contextOptions = new DbContextOptions<Context>();
            var context = new Context(contextOptions);
            var editedAdmin = context.Admins.FirstOrDefault(a => a.Id == admin.Id);

            editedAdmin.Name = admin.Name;
            editedAdmin.Password = admin.Password;
            editedAdmin.Login = admin.Login;

            context.SaveChanges();

            return View("AdminDetails", context.Admins.FirstOrDefault(a => a.Id == admin.Id));
        }



        //ProjectDelete
        public ViewResult DeleteProjectForm(int id)
        {
            //var project = _allProjects.GetProjectById(id);
            var contextOptions = new DbContextOptions<Context>();
            var context = new Context(contextOptions);
            context.Projects.Remove(context.Projects.Where(p => p.Id == id).FirstOrDefault());
            context.SaveChanges();

            var recObjects = _allRecObjects.GetAllRecObjects();
            var projects = _allProjects.GetAllProjects();
            var admins = _allAdmins.GetAllAdmins();
            var locations = _allLocations.GetAllLocations();
            var newLocation = new Location();
            var newRecObject = new RecyclableObject();
            var newAdmin = new Admin();

            return View("AdminPanel", new Tuple<ICollection<Location>, Location, RecyclableObject, Admin, ICollection<RecyclableObject>, ICollection<Project>, ICollection<Admin>>(locations, newLocation, newRecObject, newAdmin, recObjects, projects, admins));
        }

        //LocationDelete
        public ViewResult DeleteLocationForm(int id)
        {
            var contextOptions = new DbContextOptions<Context>();
            var context = new Context(contextOptions);
            context.Locations.Remove(context.Locations.Where(l => l.Id == id).FirstOrDefault());
            context.SaveChanges();

            var recObjects = _allRecObjects.GetAllRecObjects();
            var projects = _allProjects.GetAllProjects();
            var admins = _allAdmins.GetAllAdmins();
            var locations = _allLocations.GetAllLocations();
            var newLocation = new Location();
            var newRecObject = new RecyclableObject();
            var newAdmin = new Admin();

            return View("AdminPanel", new Tuple<ICollection<Location>, Location, RecyclableObject, Admin, ICollection<RecyclableObject>, ICollection<Project>, ICollection<Admin>>(locations, newLocation, newRecObject, newAdmin, recObjects, projects, admins));
        }


        //RODelete
        public ViewResult DeleteROForm(int id)
        {
            var contextOptions = new DbContextOptions<Context>();
            var context = new Context(contextOptions);
            context.RecObjects.Remove(context.RecObjects.Where(ro => ro.Id == id).FirstOrDefault());
            context.SaveChanges();

            var recObjects = _allRecObjects.GetAllRecObjects();
            var projects = _allProjects.GetAllProjects();
            var admins = _allAdmins.GetAllAdmins();
            var locations = _allLocations.GetAllLocations();
            var newLocation = new Location();
            var newRecObject = new RecyclableObject();
            var newAdmin = new Admin();

            return View("AdminPanel", new Tuple<ICollection<Location>, Location, RecyclableObject, Admin, ICollection<RecyclableObject>, ICollection<Project>, ICollection<Admin>>(locations, newLocation, newRecObject, newAdmin, recObjects, projects, admins));
        }

        //AdminDelete
        public ViewResult DeleteAdminForm(int id)
        {
            var contextOptions = new DbContextOptions<Context>();
            var context = new Context(contextOptions);
            context.Admins.Remove(context.Admins.Where(a => a.Id == id).FirstOrDefault());
            context.SaveChanges();

            var recObjects = _allRecObjects.GetAllRecObjects();
            var projects = _allProjects.GetAllProjects();
            var admins = _allAdmins.GetAllAdmins();
            var locations = _allLocations.GetAllLocations();
            var newLocation = new Location();
            var newRecObject = new RecyclableObject();
            var newAdmin = new Admin();

            return View("AdminPanel", new Tuple<ICollection<Location>, Location, RecyclableObject, Admin, ICollection<RecyclableObject>, ICollection<Project>, ICollection<Admin>>(locations, newLocation, newRecObject, newAdmin, recObjects, projects, admins));
        }


        

    }
}
