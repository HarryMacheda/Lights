using System;
using System.Collections;
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

            if (dataType.GetInterface("IList") != null)
            {
                string[] stringElements = value.Split(',');
                Type elementType = dataType.GenericTypeArguments[0];
                Array array = Array.CreateInstance(dataType, stringElements.Length);
                List<object> values= new List<object>();
                for (int i = 0; i < stringElements.Length; i++)
                {
                    object element = null;
                    if (!dataType.IsPrimitive)
                    {
                        element = Activator.CreateInstance(elementType, value);
                    }
                    else
                    {
                        element = Convert.ChangeType(value, dataType);

                    }
                    values.Add(element);
                }

                Value = values;
            }
            else
            {
                object convertedValue = null;
                if (!dataType.IsPrimitive)
                {
                    convertedValue = Activator.CreateInstance(dataType, value);
                }
                else
                {
                    convertedValue = Convert.ChangeType(value,dataType);

                }
                Value = convertedValue;
            }
        }

    }
}
