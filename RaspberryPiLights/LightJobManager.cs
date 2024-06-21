using LightsFramework.Jobs;
using Iot.Device.Ws28xx;

namespace RaspberryPiLights
{
    public static class LightJobManager
    {
        private static IJob _currentJob = null;
        public static IJob CurrentJob { get { return _currentJob; } }

        private static bool _isContinuousJob = false;
        public static bool IsContinuousJob
        {
            get { return _isContinuousJob; }
            set { _isContinuousJob = value; }
        }

        private static Ws2812b _ledStrip;
        public static Ws2812b LedStrip
        {
            get { return _ledStrip; }
            set { _ledStrip = value; }
        }


        public static int LedCount { get { return 250; } }
        public static Task<bool> StopCurrentJob()
        {
            if(_currentJob.State.Status == JobStatus.Stopped || _currentJob.State.Status == JobStatus.Failed)
            {
                return Task.FromResult(true);
            } 

            _currentJob.State.Status = JobStatus.Stopped;
            return Task.FromResult(true);
        }
        public static Task<bool> QueueJob(IJob job)
        {
            if (!(_currentJob.State.Status == JobStatus.Stopped || _currentJob.State.Status == JobStatus.Failed))
            {
                StopCurrentJob();
            }
            _currentJob = job;
            return Task.FromResult(true);
        }
    }
}
