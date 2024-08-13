using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrafficLightSimulation.Car;
using static TrafficLight.Constant;

namespace TrafficLight
{
    public interface ICarHandler : IQueueEvent
    {
        public void AddCarInQueue(Car car);
        public void Execute();
        public string ProcessCarStatus(int time, Dictionary<Direction, SampleTrafficLight> trafficLightsStatus);
        public void ChangeEventTime(int time);
    }
}
