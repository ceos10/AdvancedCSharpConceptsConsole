using System;
using System.Collections.Generic;
using AdvancedCSharpConceptsConsole.Models;
using AdvancedCSharpConceptsConsole.Repositories;

namespace AdvancedCSharpConceptsConsole.Logic
{
    public class AnonymousMethod : IDisposable
    {
        private readonly IEmployeeRepository _employeeRepository;

        public AnonymousMethod(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public void RunAnonymusMethodExample()
        {
            //Create a list of employees
            List<Employee> employees = _employeeRepository.GetEmployees();

            //Anonymus method
            FilterSeniority isJunior = delegate(Employee e) {
                return e.Experience < 3;
            };

            //Anonymus method with lambda expression
            FilterSeniority isSemiSenior = (Employee e) =>  e.Experience >= 3 && e.Experience < 5;

            //Anonymus method
            FilterSeniority isSenior = delegate (Employee e) {
                return e.Experience > 5;
            };

            //Display seniority
            ShowSeniority("Junior", employees, isJunior);
            ShowSeniority("SemiSenior", employees, isSemiSenior);
            ShowSeniority("Senior", employees, isSenior);

            //Console.Read();
        }

        static void ShowSeniority(string seniority, List<Employee> employees, FilterSeniority filter)
        {
            Console.WriteLine(seniority);

            foreach (var e in employees)
            {
                if (filter(e))
                {
                    Console.WriteLine($"{e.Name}, {e.Experience} years of experience");
                }
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
