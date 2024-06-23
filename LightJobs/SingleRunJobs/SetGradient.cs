using LightJobs.Abstracts;
using LightsFramework.Jobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using LightsFramework.JobParameters;
using Iot.Device.Ws28xx;
using Iot.Device.Graphics;
using Utility.Types;

namespace LightJobs.SingleRunJobs
{
    public class SetGradient : SingleRunLightJob
    {
        public override string JobName { get { return "Set Colour"; } }
        public override string JobDescription { get { return "Set the strip to a given number"; } }

        public override ApiArgument[] Arguments
        {
            get
            {
                return new ApiArgument[]
                {
                    new ApiArgument("Colours","System.Collections.Generic.List`1[[Utility.Types.Colour, Utility]]","#FFF")
                };
            }
        }


        private List<Colour> _colours;

        public override JobState Initiate(params object[] args)
        {
            Argument ColourArg = new Argument("System.Collections.Generic.List`1[[Utility.Types.Colour, Utility]]", args[0] != null ? args[0].ToString() : "");
            _colours = (List<Colour>)((List<object>)ColourArg.Value).Cast<Colour>().ToList();
            _state.Status = JobStatus.Ready;
            return _state;
        }

        public override JobState RunJob(Ws2812b strip)
        {
            try
            {
                RawPixelContainer image = strip.Image;

                List<Colour> colours = Colour.Gradient(_colours, LedCount, true);

                image.Clear();
                for (int i = 0; i <= LedCount; i++)
                {
                    image.SetPixel(i, 0, colours[i]);
                }

                strip.Update();
                _state.Status = JobStatus.Stopped;
            }
            catch (Exception ex)
            {
                _state.Status = JobStatus.Failed;
                _state.Exception = ex;
            }

            return _state;
        }
    }
}
