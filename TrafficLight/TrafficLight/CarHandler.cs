using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficLight
{
    public class CarHandler
    {
        private readonly TrafficLightHandler lightHandler;
        private readonly Queue<Car> northQueue;
        private readonly Queue<Car> southQueue;
        private readonly Queue<Car> eastQueue;
        private readonly Queue<Car> westQueue;
        private readonly int carExitTime;

        public CarHandler(TrafficLightHandler lightHandler, int carExitTime)
        {
            this.lightHandler = lightHandler;
            northQueue = new Queue<Car>();
            southQueue = new Queue<Car>();
            eastQueue = new Queue<Car>();
            westQueue = new Queue<Car>();
            this.carExitTime = carExitTime;
        }

        public void ArriveCar(Car car)
        {
            switch (car.Direction)
            {
                case "North":
                    northQueue.Enqueue(car);
                    break;
                case "South":
                    southQueue.Enqueue(car);
                    break;
                case "East":
                    eastQueue.Enqueue(car);
                    break;
                case "West":
                    westQueue.Enqueue(car);
                    break;
            }
        }

        public Queue<Car> GetQueue(string direction)
        {
            return direction switch
            {
                "North" => northQueue,
                "South" => southQueue,
                "East" => eastQueue,
                "West" => westQueue,
                _ => new Queue<Car>()
            };
        }

        public TrafficLightHandler TrafficLightController => lightHandler;
    }
}
