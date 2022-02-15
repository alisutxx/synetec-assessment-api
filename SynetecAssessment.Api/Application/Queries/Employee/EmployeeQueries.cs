using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SynetecAssessment.Api.Dtos;
using SynetecAssessment.Persistence;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using SynetecAssessment.Api.Services;
using SynetecAssessment.Domain;

namespace SynetecAssessment.Api.Application.Queries
{
	public class EmployeeQueries : IEmployeeQueries
	{
		private AppDbContext _context;
		private readonly IMapper _mapper;
		private readonly IBonusPoolService _bonusPoolService;
		public EmployeeQueries(AppDbContext context, IMapper mapper, IBonusPoolService bonusPoolService)
		{
			_context = context;
			_mapper = mapper;
			_bonusPoolService = bonusPoolService;
		}
		public async Task<EmployeeListResponseModel> GetAsync()
		{
			try
			{
				List<EmployeeDto> employees = await _context.Employees
					.Select(x => _mapper.Map<EmployeeDto>(x))
					.ToListAsync();
				if (employees is null || employees.Count == 0)
				{
					return new EmployeeListResponseModel
					{
						IsError = false,
						Message = "There are no employees!"
					};
				}

				return new EmployeeListResponseModel
				{
					Employees = employees,
					IsError = false,
					Message = "Successfully retrieved all employees."
				};
			}
			catch (Exception e)
			{
				return new EmployeeListResponseModel
				{
					IsError = true,
					Message = "An error has occured."
				};
			}
		}

		public async Task<EmployeeDto> GetAsync(int id)
		{
			try
			{
				if (id is default(int))
				{
					return new EmployeeDto
					{
						IsError = true,
						Message = "You must specify the employee id."
					};
				}

				var employee = await GetEmployeeFromDB(id);

				if (employee is null)
				{
					return new EmployeeDto
					{
						IsError = true,
						Message = $"Employee with id {id} does not exist!"
					};
				}

				return employee;

			}
			catch (Exception e)
			{
				return new EmployeeDto
				{
					IsError = true,
					Message = "An error has occured."
				};
			}
		}

		/// <summary>
		/// Gets an employee by id and calculates their bonus
		/// </summary>
		/// <param name="selectedEmployeeId">employee id</param>
		/// <param name="bonusPoolAmount">bonus allocated sum</param>
		/// <returns>the employee with all the details and the bonus they would get</returns>
		public async Task<BonusPoolCalculatorResultDto> GetWithBonusByIdAsync(int selectedEmployeeId, decimal bonusPoolAmount)
		{
			try
			{
				if (selectedEmployeeId is default(int))
				{
					return new BonusPoolCalculatorResultDto
					{
						IsError = true,
						Message = "SelectedEmployeeId is not specified."
					};
				}

				var employee = await GetEmployeeFromDB(selectedEmployeeId);

				if (employee is null)
				{
					return new BonusPoolCalculatorResultDto
					{
						IsError = true,
						Message = $"Employee with id { selectedEmployeeId } does not exist!"
					};
				}

				return new BonusPoolCalculatorResultDto
				{
					Amount = await _bonusPoolService.CalculateAsync(bonusPoolAmount, selectedEmployeeId),
					Employee = employee,
					IsError = false,
					Message = "Bonus amount calculated successfully!"
				};
			}
			catch (Exception e)
			{
				return new BonusPoolCalculatorResultDto
				{
					IsError = true,
					Message = "An error has occured."
				};
			}
		}

		protected async Task<EmployeeDto> GetEmployeeFromDB(int employeeId)
		{
			return await _context.Employees
				.Where(x => x.Id == employeeId)
				.Select(x => _mapper.Map<EmployeeDto>(x))
				.FirstOrDefaultAsync();
		}
	}
}
