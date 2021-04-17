using System.Collections.Generic;
using Bogus;
using AdvancedCSharpConceptsConsole.Models;

namespace AdvancedCSharpConceptsConsole.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        readonly AppSettings _appSettings;
        public EmployeeRepository(AppSettings appSettings)
        {
            _appSettings = appSettings;
        }

        public List<Employee> GetEmployees()
        {
            var faker = new Faker<Employee>()
                .RuleFor(c => c.Name, f => f.Person.FirstName)
                .RuleFor(c => c.Experience, f => f.Random.Int(1, 10));

            return faker.Generate(_appSettings.TestingAmount);
        }
    }
}
