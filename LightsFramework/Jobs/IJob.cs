using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightsFramework.Jobs
{
    public interface IJob
    {
        public string JobName { get; }
        public JobState State { get; }

        public JobState Initiate(params object[] args);
    }
}
