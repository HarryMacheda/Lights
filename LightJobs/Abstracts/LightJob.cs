using LightsFramework.JobParameters;
using LightsFramework.Jobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace LightJobs.Abstracts
{
    public abstract class LightJob : IJob
    {
        [JsonIgnore]
        public static int LedCount { get { return 250; } }
        public abstract string JobName { get; }
        public abstract string JobDescription { get; }
        public abstract ApiArgument[] Arguments { get; }
        [JsonIgnore]
        protected JobState _state;
        [JsonIgnore]
        public JobState State { get { return _state; } }
        public LightJob(params object[] args)
        {
            _state = new JobState();
            //allows us to get an instance without paramaters ie for job name, description ect
        }
        public abstract JobState Initiate(params object[] args);

    }
}
