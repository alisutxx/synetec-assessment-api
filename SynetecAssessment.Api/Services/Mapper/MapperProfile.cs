using AutoMapper;
using SynetecAssessment.Api.Dtos;
using SynetecAssessment.Domain;

namespace SynetecAssessment.Api.Services
{
	public class MapperProfile: Profile
	{
		public MapperProfile()
		{
			CreateMap<Employee, EmployeeDto>()
				.ForMember(x => x.IsError, opt => opt.MapFrom(_ => false))
				.ForMember(x => x.Message, opt => opt.MapFrom(x => "Successfully retrieved employee!"));

			CreateMap<Department, DepartmentDto>();
			CreateMap<Employee, EmployeeSalaryDto>();
		}
	}
}
