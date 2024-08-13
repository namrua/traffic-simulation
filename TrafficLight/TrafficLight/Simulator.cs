using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timer = System.Timers.Timer;

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

        public void Run(ITrafficLightHandler trafficLightHandler, ICarHandler carHandler)
        {
            var initialTimeAppStart = DateTime.Now;
            while (eventQueue.Count > 0)
            {
                var res = eventQueue.Dequeue();
                res.Execute();
            }
            Console.WriteLine("Application is running...");

            // Simulate the traffic light and car arrival
            // Update information every 5 seconds
            var trafficLightTimer = new Timer(5 * 1000);
            var elapsedTime = 0;
            trafficLightTimer.Elapsed += (sender, e) =>
            {
                elapsedTime = (int)(DateTime.Now - initialTimeAppStart).TotalSeconds;
                trafficLightHandler.UpdateLights(elapsedTime);
                var trafficLightsStatus = trafficLightHandler.GetTrafficLightsStatus();
                Console.WriteLine("Elapsed Time: " + elapsedTime);
                foreach (var light in trafficLightsStatus)
                {
                    Console.WriteLine($"{light.Key}: {light.Value.Color} with {light.Value.TimeLeft} seconds left");
                }
                Console.WriteLine(carHandler.ProcessCarStatus(5, trafficLightsStatus));
            };
            trafficLightTimer.Start();

            Console.ReadLine();
        }
    }
}
