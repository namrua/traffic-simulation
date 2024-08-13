using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficLightSimulation
{
    public class ApplicationSettings
    {

        public VehicleSetting Vehicle { get; set; }
        public TrafficLightSetting TrafficLight { get; set; }
    }

    public class VehicleSetting
    {
        public int VehicleFrequencyInNorth { get; set; }
        public int VehicleFrequencyInSouth { get; set; }
        public int VehicleFrequencyInEast { get; set; }
        public int VehicleFrequencyInWest { get; set; }
        public int CarExitTime { get; set; }
    }

    public class TrafficLightSetting
    {
        public int TotalLightInSeconds { get; set; }
    }
}
