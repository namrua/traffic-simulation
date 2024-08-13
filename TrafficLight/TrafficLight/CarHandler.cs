using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TrafficLight.Constant;

namespace TrafficLight
{
    public class CarHandler : ICarHandler
    {
        private readonly Queue<Car> carQueue;
        public int EventTime { get; set; }
        private readonly IServiceScopeFactory serviceScopeFactory;
        public CarHandler(IServiceScopeFactory serviceScopeFactory)
        {
            this.serviceScopeFactory = serviceScopeFactory;
            carQueue = new Queue<Car>();
        }
        public void AddCar(Car car)
        {
            carQueue.Enqueue(car);
        } 

        public void Execute()
        {
            
            while(carQueue.Count > 0)
            {
                var car = carQueue.Dequeue();
                var lightTraffct = serviceScopeFactory.CreateScope().ServiceProvider.GetRequiredService<ITrafficLightHandler>();
                //var nsLight = lightTraffct._nsLight;
                Console.WriteLine($"A Car from the {car.Direction} is comming in {car.CarArrivalTimeSeconds}");
            }
        }

        public string GetCarStatus()
        {
            return $"There are {carQueue.Count} cars in the queue";
        }

        public void ChangeEventTime(int time)
        {
            EventTime = time;
        }
    }
}
