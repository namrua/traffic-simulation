using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficLight
{
    public class Simulator
    {
        private readonly PriorityQueue<IQueueEvent, int> eventQueue;

        public Simulator()
        {
            eventQueue = new PriorityQueue<IQueueEvent, int>();
        }

        public void ScheduleEvent(IQueueEvent evt, int time)
        {
            evt.ChangeEventTime(time);
            eventQueue.Enqueue(evt, time);
        }

        public void Run()
        {
            while (eventQueue.Count > 0)
            {
                var res = eventQueue.Dequeue();
                res.Execute();
            }
        }
    }
}
