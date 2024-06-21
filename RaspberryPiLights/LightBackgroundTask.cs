using Iot.Device.Display;

namespace RaspberryPiLights
{
    public class LightBackgroundTask : BackgroundService
    {

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await BackgroundProcessing(stoppingToken);
        }

        private async Task BackgroundProcessing(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                // While we have a job to run
                int step = 0;
                while(LightJobManager.CurrentJob != null)
                {
                    if (LightJobManager.IsContinuousJob)
                    {
                        LightJobs.Abstracts.ContinuousLightJob job = LightJobManager.CurrentJob as LightJobs.Abstracts.ContinuousLightJob;
                        job.RunJobStep(LightJobManager.LedStrip, step);
                        step++;
                    }
                }
            }
        }
    }
}
