using AutoMapper;
using CompanyStructure.Data;
using CompanyStructure.Models.Employee;
using CompanyStructure.Models.Role;

namespace CompanyStructure.Configurations
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<Employee, EmployeeReadOnlyDto>()
                .ForMember(q => q.Role, d => d.MapFrom(map => $"{map.Role.Name}"))
                .ReverseMap();
            CreateMap<EmployeeCreateDto, Employee>().ReverseMap();
            CreateMap<EmployeeUpdateDto, Employee>().ReverseMap();

            CreateMap<EmployeeRoleReadOnlyDto, EmployeeRole>().ReverseMap();
            CreateMap<EmployeeRoleCreateDto, EmployeeRole>().ReverseMap();
            CreateMap<EmployeeRoleUpdateDto, EmployeeRole>().ReverseMap();
        }
    }
}
