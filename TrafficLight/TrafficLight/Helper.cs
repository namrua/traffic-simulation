using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficLight
{
    public class Helper
    {
        public static (int, int) CalculateTrafficLight(int totalLightInSeconds, int vehicleFrequencyNS, int vehicleFrequencyEW)
        {
            double m = (double)vehicleFrequencyNS / (vehicleFrequencyEW + vehicleFrequencyNS);
            double timeAsGreen = m * totalLightInSeconds;
            double timeAsRed = totalLightInSeconds - timeAsGreen;
            return (Convert.ToInt32(timeAsGreen), Convert.ToInt32(timeAsRed));
        }
    }
}
