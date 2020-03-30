using System;
using System.Threading;

namespace EventsAndDelegates
{
    class Program
    {
        static void Main(string[] args)
        {
            Car c = new Car()
            {
                Make = "Foo",
                Model = "Bar"
            };
            c.OnCarSpeedChanged += CarSpeedWatcher1;
            c.OnCarSpeedChanged += CarSpeedWatcher2;
            c.Accelerate();
            Thread.Sleep(1000);
            c.Accelerate();
        }

        private static void CarSpeedWatcher2(object sender, CarSpeedChangedEventArgs e)
        {
            Console.WriteLine($"Watcher 2: Car went from {e.PrevSpeed}km/h to {e.CurrentSpeed}km/h");
        }

        private static void CarSpeedWatcher1(object sender, CarSpeedChangedEventArgs e)
        {
            Console.WriteLine($"Watcher 1 reporting current speed: {e.CurrentSpeed}");
        }
    }
}
