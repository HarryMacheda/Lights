using Iot.Device.Ws28xx;
using LightJobs.Abstracts;
using LightsFramework.JobParameters;
using LightsFramework.Jobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility.Types;

namespace LightJobs.ContinuousJob
{
    public class AnimatedTwinkle : ContinuousLightJob
    {
        public override string JobName { get { return "Set Animated Twinkle"; } }
        public override string JobDescription { get { return "Set the strip twinkle through an array of colours"; } }

        public override ApiArgument[] Arguments
        {
            get
            {
                return new ApiArgument[]
                {
                    new ApiArgument("Colours","System.Collections.Generic.List`1[[Utility.Types.Colour, Utility]]","#FFF"),
                    new ApiArgument("Step count","System.Int32","0")
                };
            }
        }


        private List<List<Colour>> _colours;

        public override JobState Initiate(params object[] args)
        {
            Argument ColourArg = new Argument("List<Colour>", args[0] != null ? args[0].ToString() : "");
            List<Colour> colours = (List<Colour>)ColourArg.Value;

            Argument IntArg = new Argument("Int", args[1] != null ? args[1].ToString() : "");
            int steps = (int)IntArg.Value;

            //Calculate the gradient
            List<Colour> gradient = Colour.Gradient(colours, steps, true);
            Random rnd = new Random();

            for (int i = 0; i < LedCount; i++)
            {
                int offset = rnd.Next(steps);
                _colours.Add(gradient.Skip(offset).Concat(gradient.Take(offset)).ToList());
            }

            _state.Status = JobStatus.Ready;
            return _state;
        }

        public override JobState RunJobStep(Ws2812b strip, int step)
        {
            try
            {
                RawPixelContainer image = strip.Image;
                image.Clear();
                for (int i = 0; i <= LedCount; i++)
                {
                    image.SetPixel(i, 0, _colours[i][step]);
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
