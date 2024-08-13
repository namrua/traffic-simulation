using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficLight
{
    public class CarArrivalEvent: IQueueEvent
    {
        public int EventTime { get; }
        private readonly string direction;
        private readonly Simulator simulator;

        public CarArrivalEvent(int eventTime, string direction, Simulator simulator)
        {
            EventTime = eventTime;
            this.direction = direction;
            this.simulator = simulator;
        }

        public void Execute()
        {
            var car = new Car(direction);
            simulator.CarHandler.ArriveCar(car);
        }
    }
}
