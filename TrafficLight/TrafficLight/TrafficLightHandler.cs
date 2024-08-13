using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TrafficLight.Constant;
using Timer = System.Timers.Timer;

namespace TrafficLight
{
    public class TrafficLightHandler : ITrafficLightHandler
    {
        public ITrafficLight _nsLight;
        public ITrafficLight _ewLight;
        public int periodX1;
        public int periodX2;
        public int EventTime { get; set; }
        private int currentTime = 0;
        public TrafficLightHandler(ITrafficLight nslight, ITrafficLight ewLight)
        {
            _nsLight = nslight;
            _ewLight = ewLight;
        }

        public void SetDefaultValues(int periodX1, int periodX2, int eventTime)
        {
            this.periodX1 = periodX1;
            this.periodX2 = periodX2;
            EventTime = eventTime;
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
                currentTime = currentTime - periodX1;
            }
            _ewLight.TimeLeft = _nsLight.TimeLeft = periodX1 - currentTime;
        }

        public Dictionary<Direction, SampleTrafficLight> GetTrafficLightsStatus()
        {
            var result = new Dictionary<Direction, SampleTrafficLight>
            {
                {
                    Direction.South,
                    new SampleTrafficLight
                    {
                        Color = _nsLight.Color,
                        TimeLeft = _nsLight.TimeLeft
                    }
                },
                 {
                    Direction.North,
                    new SampleTrafficLight
                    {
                        Color = _nsLight.Color,
                        TimeLeft = _nsLight.TimeLeft
                    }
                },
                {
                    Direction.East,
                    new SampleTrafficLight
                    {
                        Color = _ewLight.Color,
                        TimeLeft = _ewLight.TimeLeft
                    }
                },
                {
                    Direction.West,
                    new SampleTrafficLight
                    {
                        Color = _ewLight.Color,
                        TimeLeft = _ewLight.TimeLeft
                    }
                }
            };
            return result;
        }

        public void Execute()
        {
            UpdateLights(EventTime);
        }

        public void ChangeEventTime(int time)
        {
            EventTime = time;
        }
    }
}
