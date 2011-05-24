using System;
using Castle.Facilities.QuartzIntegration;
using Castle.Windsor;
using Castle.Windsor.Configuration.Interpreters;

namespace SampleApp {
    internal class Program {
        private static void Main(string[] args) {
            using (var container = new WindsorContainer(new XmlInterpreter()))
            {
                container.AddFacility<QuartzFacility>("quartznet");

                Console.WriteLine("Press any key to quit...");
                Console.ReadKey();
            }
        }
    }
}