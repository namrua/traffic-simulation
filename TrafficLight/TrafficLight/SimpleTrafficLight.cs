using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TrafficLight.Constant;

namespace TrafficLight
{
    public class SimpleTrafficLight : ITrafficLight
    {
        public TrafficLightColor Color { get; set; }
        public int CurrentTimeLeftInSeconds { get; set; }

        public void SwitchToGreen()
        {
            Color = TrafficLightColor.Green;
        }

        public void SwitchToRed()
        {
            Color = TrafficLightColor.Red;
        }

    }
}
