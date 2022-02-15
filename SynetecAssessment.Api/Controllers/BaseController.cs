using Microsoft.AspNetCore.Mvc;
using SynetecAssessment.Api.Dtos;

namespace SynetecAssessment.Api.Controllers
{
	public class BaseController : Controller
	{
		/// <summary>
		/// handles the response in API endpoint methods
		/// </summary>
		/// <typeparam name="T">Any class that derives from BaseResponseDto</typeparam>
		/// <param name="responseData">the result of the request processed in the endpoint</param>
		/// <returns>
		/// OK - when responseData.IsError == false (request is successful)
		/// BAD REQUEST - when responseData.IsError == true (request is not successful, either from an error that has occured or conditions were not met)
		/// </returns>
		protected ActionResult<T> HandleResponse<T>(T responseData) where T : BaseResponseDto
		{
			if (responseData.IsError)
			{
				return BadRequest(responseData);
			}

			return Ok(responseData);
		}
	}
}
