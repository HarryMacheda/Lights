using LightsFramework.Jobs;

namespace RaspberryPiLights
{
    public static class LightJobManager
    {
        private static IJob _currentJob = null;
        public static IJob CurrentJob { get { return _currentJob; } }
        public static int LedCount { get { return 250; } }
        public static async Task<bool> StopCurrentJob()
        {
            if(_currentJob.State.Status == JobStatus.Stopped || _currentJob.State.Status == JobStatus.Failed)
            {
                return Task.FromResult(true);
            } 
        }
        public static Task<bool> QueueJob(IJob job);
        public static Task<bool> StartCurrentJob();
    }
}
