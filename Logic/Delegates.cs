using System;
using System.Collections.Generic;
using AdvancedCSharpConceptsConsole.Models;
using AdvancedCSharpConceptsConsole.Repositories;

namespace AdvancedCSharpConceptsConsole.Logic
{
    public delegate bool FilterSeniority(Employee e);

    public class Delegates : IDisposable
    {
        private readonly AppSettings _appSettings;
        private readonly IEmployeeRepository _employeeRepository;

        public Delegates(AppSettings appSettings, IEmployeeRepository employeeRepository)
        {
            _appSettings = appSettings;
            _employeeRepository = employeeRepository;
        }

        public static bool IsJunior(Employee e) => e.Experience < 3;
        public static bool IsSemiSenior(Employee e) => e.Experience >= 3 && e.Experience < 5;
        public static bool IsSenior(Employee e) => e.Experience > 5;

        public void RunDelegateExample()
        {
            //Create a list of employees
            List<Employee> employees = _employeeRepository.GetEmployees();

            //Display seniority
            ShowSeniority("Junior",employees, IsJunior);
            ShowSeniority("SemiSenior",employees, IsSemiSenior);
            ShowSeniority("Senior",employees, IsSenior);

            Console.Read();
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
