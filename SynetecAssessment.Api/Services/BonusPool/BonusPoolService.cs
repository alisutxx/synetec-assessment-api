using Microsoft.EntityFrameworkCore;
using SynetecAssessment.Api.Dtos;
using SynetecAssessment.Persistence;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace SynetecAssessment.Api.Services
{
	public class BonusPoolService : IBonusPoolService
    {
        private AppDbContext _context;
        private readonly IMapper _mapper;

		public BonusPoolService(AppDbContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

        /// <summary>
        /// Calculates the bonus amount by multiplying the bonus pool percentage and the total sum allocated for the bonus
        /// </summary>
        /// <param name="bonusPoolAmount">total sum allocated for bonus pool</param>
        /// <param name="selectedEmployeeId">employee id whose bonus is going to be calculated</param>
        /// <returns>bonus amount as string</returns>
		public async Task<string> CalculateAsync(decimal bonusPoolAmount, int selectedEmployeeId)
        {
			
			decimal bonusPoolPercentage = await CalculateBonusPoolPercentage(selectedEmployeeId);
            decimal bonusAmount = bonusPoolPercentage * bonusPoolAmount;

            return bonusAmount.ToString("0,0.00");
        }

        /// <summary>
        /// Calculate the bonus pool percecntage by dividing the salary of the employee to the total wage of all employees
        /// </summary>
        /// <param name="selectedEmployeeId">employee id whose bonus is going to be calculated</param>
        /// <returns>the percentage by which we calculate the bonus amount </returns>
        private async Task<decimal> CalculateBonusPoolPercentage(int selectedEmployeeId)
        {
            List<EmployeeSalaryDto> employeesSalaries = await _context.Employees
                .Select(x => _mapper.Map<EmployeeSalaryDto>(x))
                .ToListAsync();

            int selectedEmployeeSalary = employeesSalaries.FirstOrDefault(x => x.Id == selectedEmployeeId).Salary;
            int sumAllSalaries = employeesSalaries.Sum(x => x.Salary);
            decimal bonusPoolPercentage = (decimal)selectedEmployeeSalary / sumAllSalaries;

            return bonusPoolPercentage;
        }
    }
}
