using Application.Common.Models;
using Application.Employee.CreateEmployee;
using AutoMapper;
using Domain.Models;

namespace Application.Common.Mappings
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateEmployeeCommand, Domain.Models.Employee>();
            CreateMap<Domain.Models.Employee, EmployeeDto>().ReverseMap();
            CreateMap<EmployeeEducation, EmployeeEducationDto>().ReverseMap();
        }
    }
}
