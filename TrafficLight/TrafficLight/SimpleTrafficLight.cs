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
        public int CurrentGreenTime { get; set; }

        public bool SwitchToGreen()
        {
            var status = TrafficLightColor.Green == Color ? false : true;
            Color = TrafficLightColor.Green;
            return status;
        }

        public bool SwitchToRed()
        {
            var status = TrafficLightColor.Red == Color ? false : true;
            Color = TrafficLightColor.Red;
            return status;
        }

    }
}
