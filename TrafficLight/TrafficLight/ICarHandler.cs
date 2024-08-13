using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficLight
{
    public interface ICarHandler: IQueueEvent
    {
        public void AddCar(Car car);
        public void Execute();
        public string GetCarStatus();
        public void ChangeEventTime(int time);
    }
}
