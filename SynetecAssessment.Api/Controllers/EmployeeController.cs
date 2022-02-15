using Microsoft.AspNetCore.Mvc;
using SynetecAssessment.Api.Application.Queries;
using SynetecAssessment.Api.Dtos;
using System.Net;
using System.Threading.Tasks;

namespace SynetecAssessment.Api.Controllers
{
	[Route("api/[controller]")]
	public class EmployeeController : BaseController
	{
		private readonly IEmployeeQueries _employeeQueries;
		public EmployeeController(IEmployeeQueries employeeQueries)
		{
			_employeeQueries = employeeQueries;
		}

		/// <summary>
		/// Get all employees.
		/// </summary>
		/// <returns>
		/// OK - when all the employees have been retrieved or when there are no employees in the database
		/// BAD REQUEST - when an error has occured 
		/// </returns>
		[HttpGet]
		[ProducesResponseType((int)HttpStatusCode.BadRequest)]
		[ProducesResponseType((int)HttpStatusCode.OK)]
		[Route("get-all")]
		public async Task<ActionResult<EmployeeListResponseModel>> GetAll()
		{
			EmployeeListResponseModel responseData = await _employeeQueries.GetAsync();

			return HandleResponse(responseData);
		}

		/// <summary>
		/// Get an employee by id.
		/// </summary>
		/// <param name="id">Id of the employee</param>
		/// <returns>
		/// OK - when the employee has been found and no errors have occured
		/// BAD REQUEST - when the employee has been found, the id was not provided or an error has occured
		/// </returns>
		[HttpGet]
		[ProducesResponseType((int)HttpStatusCode.BadRequest)]
		[ProducesResponseType((int)HttpStatusCode.OK)]
		[Route("get-by-id")]
		public async Task<ActionResult<EmployeeDto>> GetById([FromQuery] int id)
		{
			EmployeeDto responseData = await  _employeeQueries.GetAsync(id);

			return HandleResponse(responseData);	
		}

		/// <summary>
		/// Get an employee by Id and calculate their bonus
		/// </summary>
		/// <param name="selectedEmployeeId"> Id of the employee whose bonus we want to calculate</param>
		/// <param name="bonusPoolAmount">sum allocated to the bonus pool</param>
		/// <returns>
		/// OK - when the employee has been found and the bonus has been successfully calculated
		/// BAD REQUEST - when the selectedEmployeeId is not specified, employee does not exist in the database or an error has occured 
		/// </returns>
		[HttpGet]
		[ProducesResponseType((int)HttpStatusCode.BadRequest)]
		[ProducesResponseType((int)HttpStatusCode.OK)]
		[Route("get-with-bonus-by-id")]
		public async Task<ActionResult<BonusPoolCalculatorResultDto>> GetWithBonusById([FromQuery] int selectedEmployeeId, [FromQuery] decimal bonusPoolAmount)
		{
			BonusPoolCalculatorResultDto responseData = await _employeeQueries.GetWithBonusByIdAsync(selectedEmployeeId, bonusPoolAmount);

			return HandleResponse(responseData);
		}


	}
}
