using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedCSharpConceptsConsole
{
    public class AppSettings
    {
        public int TestingAmount { get; set; }
        public string SenderEmailAddress { get; set; }
        public string RecipientErrorEmailAddresses { get; set; }
        public ServiceConnections IntenalServices { get; set; }
    }

    public class ServiceConnections
    {
        public string AccountServiceUrl { get; set; }
    }
}
