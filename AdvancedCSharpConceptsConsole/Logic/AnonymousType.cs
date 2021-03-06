using System;
using System.Collections.Generic;
using System.Linq;
using AdvancedCSharpConceptsConsole.Models;
using AdvancedCSharpConceptsConsole.Repositories;

namespace AdvancedCSharpConceptsConsole.Logic
{
    public class AnonymousType : IDisposable
    {
        private readonly IEmployeeRepository _employeeRepository;

        public AnonymousType(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public void RunAnonymousTypeExample()
        {
            //Create a list of employees
            List<Employee> employees = _employeeRepository.GetEmployees();

            //array of anonymous type
            var staff = from e in employees
                            select new { Id = e.Id, Name = e.Name };

            //array of anonymous type using Linq
            var experience = employees.Select(e => new { Id = e.Id, Experience = e.Experience });

            Console.WriteLine("Staff");
            //Display staff
            foreach (var s in staff)
            {
                Console.WriteLine(s.Id + "-" + s.Name);
            }

            Console.WriteLine("Experience");
            //Display experience of staff
            foreach (var e in experience)
            {
                Console.WriteLine(e.Id + "-" + e.Experience);
            }

            //Console.Read();
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
