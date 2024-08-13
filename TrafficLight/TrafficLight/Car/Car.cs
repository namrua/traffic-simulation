using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TrafficLight.Constant;

namespace TrafficLightSimulation.Car
{
    public class Car
    {
        public Direction Direction { get; set; }
        public int CarExitTime { get; set; }
        public int CarArrivalTimeSeconds { get; set; }
        public bool IsCarExited { get; set; } = false;
        public Car(Direction direction, int carExitTime, int carArrivalTimeSeconds)
        {
            Direction = direction;
            CarExitTime = carExitTime;
            CarArrivalTimeSeconds = carArrivalTimeSeconds;
        }
    }
}
