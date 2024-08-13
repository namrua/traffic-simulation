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
        /// <summary>
        /// Switches the traffic light to green.
        /// </summary>
        /// <returns>True if the switch was successful, otherwise false.</returns>
        bool SwitchToGreen();

        /// <summary>
        /// Switches the traffic light to red.
        /// </summary>
        /// <returns>True if the switch was successful, otherwise false.</returns>
        bool SwitchToRed();

        /// <summary>
        /// the time left for the current traffic light state.
        /// </summary>
        int TimeLeft { get; set; }

        /// <summary>
        /// color of the traffic light.
        /// </summary>
        TrafficLightColor Color { get; }
    }
}
