using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightsFramework.Jobs
{
    public interface IJobManager
    {
        public IJob CurrentJob { get; }
        public Task<bool> StopCurrentJob();
        public Task<bool> QueueJob(IJob job);
        public Task<bool> StartCurrentJob();

    }
}
