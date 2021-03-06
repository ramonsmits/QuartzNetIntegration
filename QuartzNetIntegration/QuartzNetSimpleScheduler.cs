using System;
using System.Collections.Generic;
using Quartz;

namespace Castle.Facilities.QuartzIntegration {
	public class QuartzNetSimpleScheduler : IJobScheduler {
		private readonly IScheduler scheduler;

		public QuartzNetSimpleScheduler(IScheduler scheduler) {
			this.scheduler = scheduler;
		}

	    public void ResumeJob(string jobName) {
            scheduler.ResumeJob(jobName, null);
	    }

	    public bool DeleteJob(string jobName) {
			return scheduler.DeleteJob(jobName, null);
		}

		public bool Interrupt(string jobName) {
			return scheduler.Interrupt(jobName, null);
		}

	    public TriggerState GetJobStatus(string jobName) {
	        var triggerName = scheduler.GetTriggersOfJob(jobName, null)[0].Name;
	        return scheduler.GetTriggerState(triggerName, null);
	    }

	    public ICollection<string> GetJobNames() {
			return scheduler.GetJobNames(null);
		}

		public void RunJob(string jobName) {
			scheduler.TriggerJob(jobName, null);
		}

		public ICollection<string> GetExecutingJobs() {
		    var r = new List<string>();
            foreach (JobExecutionContext j in scheduler.GetCurrentlyExecutingJobs())
                r.Add(j.JobDetail.Name);
		    return r;
		}

		public void PauseAll() {
			scheduler.PauseAll();
		}

		public void ResumeAll() {
			scheduler.ResumeAll();
		}

		public void PauseJob(string jobName) {
			scheduler.PauseJob(jobName, null);
		}
	}
}