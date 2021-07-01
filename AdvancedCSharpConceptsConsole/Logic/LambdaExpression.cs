using System;
using System.Collections.Generic;
using System.Linq;
using AdvancedCSharpConceptsConsole.Models;
using AdvancedCSharpConceptsConsole.Repositories;

namespace AdvancedCSharpConceptsConsole.Logic
{
    public class LambdaExpression : IDisposable
    {
        private readonly IEmployeeRepository _employeeRepository;

        public LambdaExpression(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public void RunLambdaExample()
        {
            //list of employees
            var employees = _employeeRepository.GetEmployees();

            //Func with lambda expression
            static bool isJunior(Employee e) => e.Experience < 3;

            //Func with lambda expression
            static bool isSemiSenior(Employee e) => e.Experience > 5;

            //Func with lambda expression
            static bool isSenior(Employee e) => e.Experience > 5;

            //Display list of seniors
            ShowSeniority("Junior", employees.Where(isJunior).ToList());
            ShowSeniority("SemiSenior", employees.Where(isSemiSenior).ToList());
            ShowSeniority("Senior", employees.Where(isSenior).ToList());

            //Console.Read();
        }

        static void ShowSeniority(string seniority, List<Employee> employees)
        {
            Console.WriteLine(seniority);

            foreach (var employee in employees)
            {
                Console.WriteLine($"{employee.Name}, {employee.Experience} years of experience");
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
