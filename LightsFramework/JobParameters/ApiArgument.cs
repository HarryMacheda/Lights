using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace LightsFramework.JobParameters
{
    public class ApiArgument
    {
        public String Name { get; set; }
        public Argument Argument { get; set; }

        public ApiArgument(string name, Argument argument)
        {
            Name = name;
            Argument = argument;
        }

        public ApiArgument(string name, string type, string value)
        {
            Name = name;
            Argument = new Argument(type, value);
        }
    }
}
