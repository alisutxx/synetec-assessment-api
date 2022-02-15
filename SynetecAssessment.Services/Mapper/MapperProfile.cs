using AutoMapper;
using SynetecAssessment.Api.Dtos;
using SynetecAssessment.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynetecAssessment.Services
{
	public class MapperProfile: Profile
	{
		public MapperProfile()
		{
			CreateMap<Employee, EmployeeDto>()
				.ForMember(x => x.Fullname, opt => opt.MapFrom(x => x.Fullname))
				.ForMember(x => x.Department, opt => opt.MapFrom(x => x.Department))
				.ForMember(x => x.JobTitle, opt => opt.MapFrom(x => x.JobTitle))
				.ForMember(x => x.Salary, opt => opt.MapFrom(x => x.Salary))
				.ForMember(x => x.IsError, opt => opt.MapFrom(_ => false))
				.ForMember(x => x.Message, opt => opt.MapFrom(x => "Successfully retrieved employee!"));
		}
	}
}
