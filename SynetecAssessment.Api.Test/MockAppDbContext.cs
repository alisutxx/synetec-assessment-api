using Microsoft.EntityFrameworkCore;
using SynetecAssessment.Domain;
using SynetecAssessment.Persistence;
using System.Collections.Generic;
using System.Linq;

namespace SynetecAssessment.Api.Tests
{
	public  class MockAppDbContext
	{
		public AppDbContext Context { get; set; }

		public MockAppDbContext(string name)
		{
			DbContextOptions<AppDbContext> options = new DbContextOptionsBuilder<AppDbContext>()
			.UseInMemoryDatabase(databaseName: name)
			.Options;
			Context = new AppDbContext(options);

			var empData = new List<Employee>
			{
				new Employee(1, "John Doe", string.Empty, 1000, default(int)),
				new Employee(2, "Jenny Doe", string.Empty, 2000, default(int)),
				new Employee(3, "Jonathan Doe", string.Empty, 2000, default(int)),
				new Employee(4, "John Snow", string.Empty, 1000, default(int)),
				new Employee(5,"Jenny Snow", string.Empty, 2000, default(int)),
				new Employee(6, "Jonathan Snow", string.Empty, 2000, default(int))
			}.AsQueryable();

			var depData = new List<Department>
			{   new Department(1, "First department", "This is the first department"),
				new Department(2, "Second department", "This is the second department"),
				new Department(3, "Third department", "This is the third deparment")
			};
			Context.AddRange(empData);
			Context.AddRange(depData);
			Context.SaveChanges();
		}
	}
}
