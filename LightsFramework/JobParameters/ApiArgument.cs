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
        public enum ControlType
        {
            None = 0,
            Int = 1,
            String = 2,
            Bool = 3,
            Colour = 4,
            ColourList = 5,
        }

        public static Dictionary<ControlType,String> ControlName 
        { 
            get {
                return new Dictionary<ControlType, String>() {
                { ControlType.None, "" },
                { ControlType.Int, "System.Int32" },
                { ControlType.String, "System.String" },
                { ControlType.Bool, " System.Boolean" },
                { ControlType.Colour, "Utility.Types.Colour, Utility" },
                { ControlType.ColourList, "System.Collections.Generic.List`1[[Utility.Types.Colour, Utility]]" }
            };
            } 
        }

        public String Name { get; set; }
        public Argument Argument { get; set; }

        public ApiArgument(string name, Argument argument)
        {
            Name = name;
            Argument = argument;
        }

        public ApiArgument(string name, ControlType type, string value)
        {
            Name = name;
            Argument = new Argument(type, value);
        }
    }
}
