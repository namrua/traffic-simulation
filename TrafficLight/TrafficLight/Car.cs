using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TrafficLight.Constant;

namespace TrafficLight
{
    public class Car
    {
        public Direction Direction { get; set; }
        public int CarExitTime { get; set; }
        public bool IsPassedCrossroad { get; set; } 
        public int CarArrivalTimeSeconds { get; set; }
        public Car(Direction direction, int carExitTime, int carArrivalTimeSeconds)
        {
            Direction = direction;
            CarExitTime = carExitTime;
            CarArrivalTimeSeconds = carArrivalTimeSeconds;
        }
    }
}
