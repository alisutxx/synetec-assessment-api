using AutoMapper;
using SynetecAssessment.Api.Application.Queries;
using SynetecAssessment.Api.Services;
using SynetecAssessment.Persistence;
using System;
using Xunit;

namespace SynetecAssessment.Api.Tests
{
	public class EmployeeQueriesTests : IDisposable
	{
		private readonly IEmployeeQueries sut;
		private readonly IBonusPoolService _mockBonusPoolService;
		private AppDbContext _mockDbContext;
		private readonly IMapper _mapper;
		public EmployeeQueriesTests()
		{
			_mockDbContext = new MockAppDbContext("EmployeeDb").Context;

			var config = new MapperConfiguration(cfg => cfg.AddProfile<MapperProfile>());
			_mapper = config.CreateMapper();

			_mockBonusPoolService = new BonusPoolService(_mockDbContext, _mapper);

			sut = new EmployeeQueries(_mockDbContext, _mapper, _mockBonusPoolService);
		}

		public void Dispose()
		{
			_mockDbContext.Employees.RemoveRange(_mockDbContext.Employees);
			_mockDbContext.Departments.RemoveRange(_mockDbContext.Departments);

			_mockDbContext.SaveChanges();
		}

		[Fact]
		public async void GetAsync_All_Employees()
		{
			// Act
			Dtos.EmployeeListResponseModel result = await sut.GetAsync();

			// Assert
			Assert.Equal(6, result.Employees.Count);
		}

		[Fact]
		public async void GetAsync_By_Id()
		{
			// Act
			Dtos.EmployeeDto result = await sut.GetAsync(5);

			// Assert
			Assert.Equal("Jenny Snow", result.Fullname);
		}
	}
}
