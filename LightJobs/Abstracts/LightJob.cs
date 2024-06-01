using LightsFramework.JobParameters;
using LightsFramework.Jobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightJobs.Abstracts
{
    public abstract class LightJob : IJob
    {
        public abstract string JobName { get; }
        public abstract string JobDescription { get; }
        public abstract ApiArgument[] Arguments { get; }
        protected JobState _state;
        public JobState State { get { return _state; } }
        public LightJob(params object[] args)
        {
            _state = new JobState();
            Initiate(args);
        }
        public abstract JobState Initiate(params object[] args);

    }
}
