using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficLight
{
    public class Simulator
    {
        private readonly PriorityQueue<IEvent, int> eventQueue;
        public CarHandler CarHandler { get; }
        public TrafficLightHandler TrafficLightController { get; }

        public Simulator(CarHandler carHandler, TrafficLightHandler trafficLightController)
        {
            eventQueue = new PriorityQueue<IEvent, int>();
            CarHandler = carHandler;
            TrafficLightController = trafficLightController;
        }

        public void ScheduleEvent(IEvent evt)
        {
            eventQueue.Enqueue(evt, evt.EventTime);
        }

        public void Run()
        {
            while (eventQueue.Count > 0)
            {
                var res = eventQueue.Dequeue();
                res.Execute(this);
            }
        }
    }
}
