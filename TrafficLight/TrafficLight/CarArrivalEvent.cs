using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficLight
{
    public class CarArrivalEvent: IEvent
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

        public void Execute(Simulator simulator)
        {
            var car = new Car(direction);
            simulator.CarHandler.ArriveCar(car);
        }
    }
}
