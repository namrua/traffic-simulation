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
        bool SwitchToGreen();
        bool SwitchToRed();
        int CurrentGreenTime { get; }
        TrafficLightColor Color { get; }
    }
}
