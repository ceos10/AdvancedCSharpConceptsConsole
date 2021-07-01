using System;
using System.Collections.Generic;
using AdvancedCSharpConceptsConsole.Models;
using AdvancedCSharpConceptsConsole.Repositories;

namespace AdvancedCSharpConceptsConsole.Logic
{
    // Please extract this class on separated file inside a folder called Extensions
    public static class EmployeeExtensions
    {
        //extension method
        public static void PrintInformation(this Employee e) 
        {
            Console.WriteLine($"{e.Name}, {e.Experience} years of experience");
        }
    }

    public class ExtensionMethod : IDisposable
    {
        private readonly IEmployeeRepository _employeeRepository;

        public ExtensionMethod(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public void RunExtensionMethodExample()
        {
            // Create a list of employees
            // Please use var instead of specific types (Delete this comment please)
            List<Employee> employees = _employeeRepository.GetEmployees();

            //Func with anonymus method
            Func<Employee, bool> isJunior = delegate (Employee e) {
                return e.Experience < 3;
            };

            //Func with lambda expression
            Func<Employee, bool> isSemiSenior = (Employee e) => e.Experience >= 3 && e.Experience < 5;

            //Func with anonymus method
            // In this case please use the lambda expression ... e => e.Experience > 5
            Func<Employee, bool> isSenior = delegate (Employee e) {
                return e.Experience > 5;
            };

            //Display seniority
            ShowSeniority("Junior", employees, isJunior);
            ShowSeniority("SemiSenior", employees, isSemiSenior);
            ShowSeniority("Senior", employees, isSenior);

            //Console.Read();
        }

        // Please rename the variable filter to seniorityFilter (Delete this comment please)
        static void ShowSeniority(string seniority, List<Employee> employees, Func<Employee, bool> filter)
        {
            Console.WriteLine(seniority);

            // Please rename e to employee (Delete this comment please)
            foreach (var e in employees)
            {
                if (filter(e))
                {
                    //use extension method
                    e.PrintInformation();
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
