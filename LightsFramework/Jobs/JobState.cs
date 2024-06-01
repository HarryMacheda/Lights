using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightsFramework.Jobs
{
    public enum JobStatus
    {
        Initilising = -1, 
        Ready = 0,
        Running = 1,
        Stopped = 2,
        Failed = 4
    }


    public class JobState
    {
        public JobStatus Status { get; set; }
        public Exception? Exception { get; set; }

        public JobState()
        {
            Status = JobStatus.Initilising;
            Exception = null;
        }
    }
}
