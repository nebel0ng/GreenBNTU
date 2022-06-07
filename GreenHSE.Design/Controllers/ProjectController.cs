using AutoMapper;
using GreenBNTU.Design.Dto;
using GreenBNTU.Design.Interfaces;
using GreenBNTU.Design.Models;
using Microsoft.AspNetCore.Mvc;

namespace GreenBNTU.Design.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : Controller
    {
        private readonly IAllProjects _allProjects;
        private readonly IMapper _mapper;
        public ProjectController(IAllProjects allProjects, IMapper mapper)
        {
            _allProjects = allProjects;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type= typeof(IEnumerable<Project>))]
        public IActionResult GetAllProjects()
        {
            var projects = _mapper.Map<List<ProjectDto>>(_allProjects.GetAllProjects());
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(projects);
        }

        [HttpGet("{projectId}")]
        [ProducesResponseType(200, Type = typeof(Project))]
        [ProducesResponseType(400)]
        public IActionResult GetProject(int projectId)
        {
            if (!_allProjects.ProjectExists(projectId))
            {
                return NotFound();
            }

            var project = _mapper.Map<ProjectDto>(_allProjects.GetProjectById(projectId));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(project);

        }

        [HttpGet("{projectId}/Desc")]
        [ProducesResponseType(200, Type = typeof(string))]
        [ProducesResponseType(400)]
        public IActionResult GetProjectDesc(int projectId)
        {
            if (!_allProjects.ProjectExists(projectId))
            {
                return NotFound();
            }

            var projectDesc = _allProjects.GetProjectDescription(projectId);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(projectDesc);

        }

        [HttpGet("{projectId}/Date")]
        [ProducesResponseType(200, Type = typeof(DateTime))]
        [ProducesResponseType(400)]
        public IActionResult GetProjectDate(int projectId)
        {
            if (!_allProjects.ProjectExists(projectId))
            {
                return NotFound();
            }

            var projectDate = _allProjects.GetProjectDate(projectId);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(projectDate);

        }

        [HttpGet("{projectId}/Name")]
        [ProducesResponseType(200, Type = typeof(string))]
        [ProducesResponseType(400)]
        public IActionResult GetProjectName(int projectId)
        {
            if (!_allProjects.ProjectExists(projectId))
            {
                return NotFound();
            }

            var projectName = _allProjects.GetProjectName(projectId);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(projectName);

        }
    }
}
