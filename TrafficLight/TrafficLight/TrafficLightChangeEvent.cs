using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficLight
{
    public class TrafficLightChangeEvent : IEvent
    {
        public int EventTime { get; }
        private readonly Simulator simulator;

        public TrafficLightChangeEvent(int eventTime, Simulator simulator)
        {
            EventTime = eventTime;
            this.simulator = simulator;
        }

        public void Execute(Simulator simulator)
        {
            simulator.TrafficLightController.UpdateLights(EventTime);
        }
    }
}
