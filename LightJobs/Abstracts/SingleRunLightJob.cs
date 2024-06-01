using Iot.Device.Ws28xx;
using LightsFramework.Jobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightJobs.Abstracts
{
    public abstract class SingleRunLightJob : LightJob
    {
        public abstract JobState RunJob(Ws2812b strip);
    }
}
