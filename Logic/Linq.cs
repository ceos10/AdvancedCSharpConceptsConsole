using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdvancedCSharpConceptsConsole.Models;
using AdvancedCSharpConceptsConsole.Repositories;

namespace AdvancedCSharpConceptsConsole.Logic
{
    public class Linq
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly AppSettings _appSettings;

        public Linq(IEmployeeRepository employeeRepository, AppSettings appSettings)
        {
            _employeeRepository = employeeRepository;
            _appSettings = appSettings;
        }

        public async Task<List<CustomerRank>> CallStoredProcedure()
        {
            return new List<CustomerRank>();
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
