using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using TrafficLightSimulation.Car;
using static TrafficLight.Constant;

namespace TrafficLight
{
    public class CarHandler : ICarHandler
    {
        private Queue<Car> carQueue;
        public int EventTime { get; set; }
        private readonly IServiceScopeFactory serviceScopeFactory;
        public CarHandler(IServiceScopeFactory serviceScopeFactory)
        {
            this.serviceScopeFactory = serviceScopeFactory;
            carQueue = new Queue<Car>();
        }
        public void AddCarInQueue(Car car)
        {
            carQueue.Enqueue(car);
        }

        public void Execute()
        {
            //TODO : Implement the logic for each Car
        }

        public string ProcessCarStatus(int time, Dictionary<Direction, SampleTrafficLight> trafficLightsStatus)
        {
            var result = new StringBuilder();
            foreach (var car in carQueue)
            {
                var trafficLight = trafficLightsStatus[car.Direction];
                car.CarArrivalTimeSeconds -= time;
                if (trafficLight.Color == TrafficLightColor.Green && car.CarArrivalTimeSeconds <= 0 && trafficLight.TimeLeft > 0)
                {
                    result.Append($"Cars from {car.Direction} are passed the crossroad\n");
                    car.IsCarExited = true;
                }
                else
                {
                    if (car.CarArrivalTimeSeconds <= 0)
                    {
                        if (trafficLight.Color == TrafficLightColor.Red)
                        {
                            result.Append($"Cars from {car.Direction} are waiting for the green light\n");
                        }
                        else if (trafficLight.TimeLeft > 0)
                        {
                            result.Append($"Cars from {car.Direction} are passed the crossroad\n");
                            car.IsCarExited = true;
                        }
                    }
                    else
                    {
                        result.Append($"Cars from {car.Direction} are coming in {car.CarArrivalTimeSeconds} seconds\n");
                    }
                }
            }
            carQueue = new Queue<Car>(carQueue.Where(car => !car.IsCarExited));
            if (carQueue.Count == 0)
            {
                result.Append("Wating for new Car\n");
            }
            return result.ToString();
        }

        public void ChangeEventTime(int time)
        {
            EventTime = time;
        }
    }
}
