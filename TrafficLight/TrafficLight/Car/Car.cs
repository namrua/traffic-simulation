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
        /// <summary>
        ///  the direction of the car.
        /// </summary>
        public Direction Direction { get; set; }

        /// <summary>
        ///  the time when the car will exit.
        /// </summary>
        public int CarExitTime { get; set; }

        /// <summary>
        ///  the arrival time of the car in seconds.
        /// </summary>
        public int CarArrivalTimeSeconds { get; set; }

        /// <summary>
        ///  a value indicating whether the car has exited.
        /// </summary>
        public bool IsCarExited { get; set; } = false;

        public Car(Direction direction, int carExitTime, int carArrivalTimeSeconds)
        {
            Direction = direction;
            CarExitTime = carExitTime;
            CarArrivalTimeSeconds = carArrivalTimeSeconds;
        }
    }
}
