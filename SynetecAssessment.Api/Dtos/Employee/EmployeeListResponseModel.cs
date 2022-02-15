using System.Collections.Generic;

namespace SynetecAssessment.Api.Dtos
{
	public class EmployeeListResponseModel : BaseResponseDto
	{
		public IList<EmployeeDto> Employees { get; set; }
	}
}
