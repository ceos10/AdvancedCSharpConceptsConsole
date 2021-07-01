using System;
using System.Collections.Generic;
using AdvancedCSharpConceptsConsole.Models;
using AdvancedCSharpConceptsConsole.Repositories;

namespace AdvancedCSharpConceptsConsole.Logic
{
    public class Action : IDisposable
    {
        private readonly IEmployeeRepository _employeeRepository;

        public Action(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public void RunActionExample()
        {
            //list of employees
            var employees = _employeeRepository.GetEmployees();

            //Action with lambda expression
            Action<Employee> printSeniority = (Employee employee) =>
            {
                string seniority;

                if (employee.Experience < 3)
                {
                    seniority = "Junior";
                }
                else if (employee.Experience >= 3 && employee.Experience < 5)
                {
                    seniority = "SemiSenior";
                }
                else
                {
                    seniority = "Senior";
                }

                Console.WriteLine($"{employee.Name} is a {seniority} with {employee.Experience} years of experience");
            };

            //Display seniority
            ShowSeniority("Junior", employees, printSeniority);

            //Console.Read();
        }

        static void ShowSeniority(string seniority, List<Employee> employees, Action<Employee> printSeniority)
        {
            Console.WriteLine(seniority); // I think this line should be removed.

            foreach (var employee in employees)
            {
                printSeniority(employee);
            }

            Console.WriteLine();
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
