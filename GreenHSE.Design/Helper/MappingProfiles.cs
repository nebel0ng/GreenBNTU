using AutoMapper;
using GreenBNTU.Design.Dto;
using GreenBNTU.Design.Models;

namespace GreenBNTU.Design.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Project, ProjectDto>();
        }
    }
}
