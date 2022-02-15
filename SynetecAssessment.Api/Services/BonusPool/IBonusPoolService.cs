using System.Threading.Tasks;

namespace SynetecAssessment.Api.Services
{
	public interface IBonusPoolService
	{
		Task<string> CalculateAsync(decimal bonusPoolAmount, int selectedEmployeeId);
	}
}
