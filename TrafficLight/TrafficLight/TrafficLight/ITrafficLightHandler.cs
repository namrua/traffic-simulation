using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TrafficLight.Constant;

namespace TrafficLight
{
    /// <summary>
    /// Represents a traffic light handler that controls the behavior of traffic lights.
    /// </summary>
    public interface ITrafficLightHandler : IQueueEvent
    {
        /// <summary>
        /// Updates the state of the traffic lights based on the specified time.
        /// </summary>
        /// <param name="time">The time value.</param>
        public void UpdateLights(int time);

        /// <summary>
        /// Gets the status of the traffic lights.
        /// </summary>
        /// <returns>A dictionary containing the status of the traffic lights for each direction.</returns>
        public Dictionary<Direction, SampleTrafficLight> GetTrafficLightsStatus();

        /// <summary>
        /// Executes the traffic light handler.
        /// </summary>
        public void Execute();

        public void ChangeEventTime(int time);

        public void SetDefaultValues(int periodX1, int periodX2, int eventTime);
    }
}
