using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TrafficLight.Constant;

namespace TrafficLight
{
    public class SampleTrafficLight : ITrafficLight
    {
        /// <summary>
        ///  the color of the traffic light.
        /// </summary>
        public TrafficLightColor Color { get; set; }

        /// <summary>
        ///  the time left for the current traffic light color.
        /// </summary>
        public int TimeLeft { get; set; }

        /// <summary>
        /// Switches the traffic light color to green.
        /// </summary>
        /// <returns>True if the color was switched, false if the color was already green.</returns>
        public bool SwitchToGreen()
        {
            var status = TrafficLightColor.Green == Color ? false : true;
            Color = TrafficLightColor.Green;
            return status;
        }

        /// <summary>
        /// Switches the traffic light color to red.
        /// </summary>
        /// <returns>True if the color was switched, false if the color was already red.</returns>
        public bool SwitchToRed()
        {
            var status = TrafficLightColor.Red == Color ? false : true;
            Color = TrafficLightColor.Red;
            return status;
        }
    }
}
