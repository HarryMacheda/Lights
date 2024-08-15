using Iot.Device.Ws28xx;
using LightJobs.Abstracts;
using LightsFramework.JobParameters;
using LightsFramework.Jobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitsNet;
using Utility.Types;
using static LightsFramework.JobParameters.ApiArgument;

namespace LightJobs.ContinuousJob
{
    public class AnimatedGradient : ContinuousLightJob
    {
        public override string JobName { get { return "Set Animated Gradient"; } }
        public override string JobDescription { get { return "Set the strip to a given gradient and have it move along the strip"; } }

        public override ApiArgument[] Arguments
        {
            get
            {
                return new ApiArgument[]
                {
                    new ApiArgument("Colours", new Argument(ControlType.ColourList, "#FFFFFF",true)),
                    new ApiArgument("Step count", new Argument(ControlType.Int,"0",true))
                };
            }
        }


        private List<List<Colour>> _colours;

        public override JobState Initiate(params object[] args)
        {
            Argument ColourArg = new Argument(ControlType.ColourList, args[0] != null ? args[0].ToString() : "");
            List<Colour> colours = (List<Colour>)((List<object>)ColourArg.Value).Cast<Colour>().ToList();

            Argument IntArg = new Argument(ControlType.Int, args[1] != null ? args[1].ToString() : "");
            int steps = (int)IntArg.Value;
            StepCount = steps;
            //Calculate the gradient
            List<Colour> gradient = Colour.Gradient(colours, LedCount, true);
            _colours = new List<List<Colour>>();

            //Generate an array of split indexes


            for (int i = 0; i < steps; i++)
            {
                int splitIndex = gradient.Count - ((int)(LedCount / steps) * i);
                _colours.Add(gradient.Skip(splitIndex).Concat(gradient.Take(splitIndex)).ToList());
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
                for (int i = 0; i < LedCount; i++)
                {
                    image.SetPixel(i, 0, _colours[step % StepCount][i]);
                }
                Console.WriteLine("Step: " + step.ToString() + " " + _colours[step % StepCount][0].ToString());
                strip.Update();
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
