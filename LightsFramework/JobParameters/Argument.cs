using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightsFramework.JobParameters
{
    public class Argument
    {
        public object? Value { get; set; }

        public Argument(string type, string value) 
        {
                Type? dataType = Type.GetType(type);

                if (dataType == null) { throw new Exception("Specified data type " + type + " is not a valid datatype"); }

                if (dataType.IsArray)
                {
                    string[] stringElements = value.Split(',');
                    Array array = Array.CreateInstance(dataType, stringElements.Length);
                    for (int i = 0; i < stringElements.Length; i++)
                    {
                        object element = Convert.ChangeType(stringElements[i], dataType);
                        array.SetValue(element, i);
                    }

                    Value = array;
                }
                else
                {
                    object convertedValue = Convert.ChangeType(value, dataType);
                    Value = convertedValue;
                }
        }

    }
}
