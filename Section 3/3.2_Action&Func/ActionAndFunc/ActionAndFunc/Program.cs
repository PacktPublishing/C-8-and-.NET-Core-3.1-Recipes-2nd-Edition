using System;
using System.Threading;

namespace ActionAndFunc
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
            Thread.Sleep(1000);
            c.Brake(CanBrake, BrakeReporter);
            c.Brake(CanBrake, BrakeReporter);
            c.Brake(CanBrake, BrakeReporter);
        }

        private static bool CanBrake(int currentSpeed)
        {
            return currentSpeed > 0;
        }

        private static void BrakeReporter(int newCurrentSpeed)
        {
            Console.WriteLine($"Car brakes for current speed {newCurrentSpeed}");
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
