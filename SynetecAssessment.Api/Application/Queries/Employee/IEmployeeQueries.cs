using SynetecAssessment.Api.Dtos;
using System.Threading.Tasks;

namespace SynetecAssessment.Api.Application.Queries
{
	public interface IEmployeeQueries
	{
		Task<EmployeeListResponseModel> GetAsync();
		Task<EmployeeDto> GetAsync(int employeeId);
		Task<BonusPoolCalculatorResultDto> GetWithBonusByIdAsync(int selectedEmployeeId, decimal bonusPoolAmount);
	}
}
