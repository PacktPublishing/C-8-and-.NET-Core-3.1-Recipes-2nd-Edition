using System;
using System.Collections.Generic;
using System.Text;

namespace ActionAndFunc
{
    public delegate void CarSpeedChanged(int prevSpeed, int currentSpeed);

    public class CarSpeedChangedEventArgs : EventArgs
    {
        public int PrevSpeed { get; private set; }
        public int CurrentSpeed { get; private set; }

        public CarSpeedChangedEventArgs(int prevSpeed, int currentSpeed)
        {
            PrevSpeed = prevSpeed;
            CurrentSpeed = currentSpeed;
        }
    }

    public class Car
    {
        public event EventHandler<CarSpeedChangedEventArgs> OnCarSpeedChanged;

        public string Make { get; set; }
        public string Model { get; set; }
        public int CurrentSpeed { get; protected set; } = 0;

        public void Accelerate()
        {
            int prevSpeed = CurrentSpeed;
            CurrentSpeed += 5;
            if (OnCarSpeedChanged != null)
            {
                OnCarSpeedChanged.Invoke(this, new CarSpeedChangedEventArgs(prevSpeed, CurrentSpeed));
            }
        }

        public void Brake(Func<int, bool> canBrake, Action<int> reporter)
        {
            if (canBrake(CurrentSpeed))
            {
                CurrentSpeed -= 5;
            }
            reporter(CurrentSpeed);
        }
    }
}
