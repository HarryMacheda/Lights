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
using static LightsFramework.JobParameters.ApiArgument;

namespace LightJobs.SingleRunJobs
{
    public class SetColour : SingleRunLightJob
    {
        public override string JobName { get { return "Set Colour"; } }
        public override string JobDescription { get { return "Set the strip to a given colour";  } }
        public override ApiArgument[] Arguments
        {
            get
            {
                return new ApiArgument[]
                {
                    new ApiArgument("Colour",ControlType.Colour,"#FFF")
                };
            }
        }


        private Colour _colour;

        public override JobState Initiate(params object[] args)
        {
            Argument ColourArg = new Argument(ControlType.Colour, args[0] != null ? args[0].ToString() : "");
            _colour = (Colour) ColourArg.Value;
            _state.Status = JobStatus.Ready;
            return _state;
        }

        public override JobState RunJob(Ws2812b strip)
        {
            try
            {
                RawPixelContainer image = strip.Image;
                image.Clear();
                for (int i = 0; i <= LedCount; i++)
                {
                    image.SetPixel(i, 0, _colour);
                }

                strip.Update();
                _state.Status = JobStatus.Stopped;
            }
            catch(Exception ex)
            {
                _state.Status = JobStatus.Failed;
                _state.Exception = ex;
            }

            return _state;
        }
    }
}
