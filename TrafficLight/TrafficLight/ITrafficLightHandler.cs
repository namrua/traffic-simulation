using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TrafficLight.Constant;

namespace TrafficLight
{
    public interface ITrafficLightHandler : IQueueEvent
    {
        public void UpdateLights(int time);
        public Dictionary<Direction, SampleTrafficLight> GetTrafficLightsStatus();
        public void Execute();
        public void ChangeEventTime(int time);
        public void SetDefaultValues(int periodX1, int periodX2, int eventTime);
    }
}
