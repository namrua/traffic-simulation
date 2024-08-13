using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficLight
{
    public class TrafficLightHandler
    {
        private readonly ITrafficLight _nsLight;
        private readonly ITrafficLight _ewLight;
        private readonly int periodX1;
        private readonly int periodX2;
        private int currentTime = 0;

        public TrafficLightHandler(ITrafficLight nslight, ITrafficLight ewLight, int periodX1, int periodX2)
        {
            _nsLight = nslight;
            _ewLight = ewLight;
            this.periodX1 = periodX1;
            this.periodX2 = periodX2;
        }

        public void UpdateLights(int time)
        {
            currentTime = time % (periodX1 + periodX2);
            if (currentTime < periodX1)
            {
                _nsLight.SwitchToGreen();
                _ewLight.SwitchToRed();
            }
            else
            {
                _nsLight.SwitchToRed();
                _ewLight.SwitchToGreen();
            }
        }

        public string GetLightStatus()
        {
            return $"NS: {_nsLight.Color}, Time left: {_nsLight.CurrentTimeLeftInSeconds}, " +
                $"\nEW: {_ewLight.Color}, Time left: {_ewLight.CurrentTimeLeftInSeconds}";
        }
    }
}
