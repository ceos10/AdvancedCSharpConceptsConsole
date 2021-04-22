using System.Collections.Generic;
using AdvancedCSharpConceptsConsole.Models;

namespace AdvancedCSharpConceptsConsole.Repositories
{
    public interface IEmployeeRepository
    {
        List<Employee> GetEmployees();
    }
}
