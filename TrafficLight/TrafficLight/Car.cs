using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficLight
{
    public class Car
    {
        public string Direction { get; }
        public bool IsPassedCrossroad { get; set; } 
        public Car(string direction)
        {
            Direction = direction;
        }
    }
}
