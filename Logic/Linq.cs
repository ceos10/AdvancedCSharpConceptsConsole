using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdvancedCSharpConceptsConsole.Models;
using AdvancedCSharpConceptsConsole.Repositories;

namespace AdvancedCSharpConceptsConsole.Logic
{
    public class Linq
    {
        private readonly IEmployeeRepository _employeeRepository;

        public Linq(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public void RunLinqExample()
        {
            //list of employees
            List<Employee> employees = _employeeRepository.GetEmployees();
            List<int> years = employees.Select(e => e.Experience).ToList();

            //MAX - years of experience
            int maxExperience = years.Max();
            Console.WriteLine($"max-experience: {maxExperience}");

            //Average - years of experience
            int minExperience = years.Min();
            Console.WriteLine($"min-experience: {minExperience}");

            //Average - years of experience
            double avgExperience = years.Average();
            Console.WriteLine($"avg-experience: {avgExperience}");

            //To Dictionary
            var staff = employees.ToDictionary(k => k.Id, v => v.Name);

            foreach (KeyValuePair<int, string> dic in staff)
                Console.WriteLine($"Employee {dic.Key} is {dic.Value}");

            //employes with more than 4 years of experience
            var result = employees.Where(e => e.Experience > 4).ToList();
            Console.WriteLine($"There are {result.Count} with more than 4 years of experience");

            //does any of the employees have 10 or more years of experience
            var result2 = employees.Any(e => e.Experience >= 10);
            Console.WriteLine("does any of the employees have 10 or more years of experience");
            Console.WriteLine(result2);

            //diferent years of experience
            var yearsOfExperience = years.Distinct();
            Console.WriteLine("diferent years of experience");
            foreach (var year in yearsOfExperience)
                Console.WriteLine(year);

            //Take 10 employees
            var result3 = employees.Take(10);
        }

        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            GC.SuppressFinalize(this);
        }
    }
}
