using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TrafficLight.Constant;

namespace TrafficLight
{
    public interface ITrafficLight
    {
        void SwitchToGreen();
        void SwitchToRed();
        int CurrentTimeLeftInSeconds { get; }
        TrafficLightColor Color { get; }
    }
}
