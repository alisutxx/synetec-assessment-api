namespace SynetecAssessment.Api.Dtos
{
    public class EmployeeDto : BaseResponseDto
    {
        public string Fullname { get; set; }
        public string JobTitle { get; set; }
        public int Salary { get; set; }
        public DepartmentDto Department { get; set; }
    }
}
