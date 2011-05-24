using System;
using Quartz;

namespace SampleApp {
	public class SampleJob : IJob, IDisposable {
        static int counter;
        readonly int nr = ++counter;
        bool disposed;

        public SampleJob()
        {
            Console.WriteLine("Created " + nr);
        }

		public void Execute(JobExecutionContext context) {
            if (disposed) throw new ObjectDisposedException(GetType().FullName);
			Console.WriteLine("Hello world!");
		}

        public void Dispose()
        {
            Dispose(true);
        }

        ~SampleJob()
        {
            Dispose(false);
        }

        private void Dispose(bool dispose)
        {
            Console.WriteLine("Dispose " + nr);
            if (disposed) return;

            if (dispose)
            {
                Console.WriteLine("Disposing");
                disposed = true;
                GC.SuppressFinalize(this);
            }
        }
    }
}