namespace SynetecAssessment.Api.Dtos
{
    public class BonusPoolCalculatorResultDto : BaseResponseDto
    {
        public string Amount { get; set; }
        public EmployeeDto Employee { get; set; }
    }
}
