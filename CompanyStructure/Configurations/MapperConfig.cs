using AutoMapper;
using CompanyStructure.Data;
using CompanyStructure.Models.Employee;

namespace CompanyStructure.Configurations
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<EmployeeReadOnlyDto, Employee>().ReverseMap();
            CreateMap<EmployeeCreateDto, Employee>().ReverseMap();
            CreateMap<EmployeeUpdateDto, Employee>().ReverseMap();
        }
    }
}
