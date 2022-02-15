using AutoMapper;
using SynetecAssessment.Api.Services;
using SynetecAssessment.Persistence;
using System;
using Xunit;

namespace SynetecAssessment.Api.Tests
{
	public class BonusPoolServiceTests : IDisposable
	{
		private readonly IBonusPoolService sut;
		private AppDbContext _mockDbContext;
		private readonly IMapper _mapper;

		public BonusPoolServiceTests()
		{
			_mockDbContext = new MockAppDbContext("BonusPoolDb").Context;

			var config = new MapperConfiguration(cfg => cfg.AddProfile<MapperProfile>());
			_mapper = config.CreateMapper();

			sut = new BonusPoolService(_mockDbContext, _mapper);
		}

		public void Dispose()
		{
			_mockDbContext.Employees.RemoveRange(_mockDbContext.Employees);
			_mockDbContext.Departments.RemoveRange(_mockDbContext.Departments);

			_mockDbContext.SaveChanges();
		}

		[Fact]
		public async void CalculateAsync_If_BonusPoolAmount_Is_Not_Zero_Return_Correct_Value()
		{
			// Act
			string result = await sut.CalculateAsync(12345M,1);
			string expectedResult = "1,234.50";

			// Assert
			Assert.Equal(expectedResult, result);
		}

		[Fact]
		public async void CalculateAsync_If_BonusPoolAmount_Is_Zero_Return_Zero()
		{
			// Act
			string result = await sut.CalculateAsync(0, 4);
			string expectedResult = "00.00";

			// Assert
			Assert.Equal(expectedResult, result);
		}
	}
}
