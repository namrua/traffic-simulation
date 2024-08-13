using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficLightSimulation
{
    public class ApplicationSettings
    {

        public Vehicle Vehicle { get; set; }
        public TrafficLight TrafficLight { get; set; }
    }

    public class Vehicle
    {
        public int VehicleFrequencyInNorth { get; set; }
        public int VehicleFrequencyInSouth { get; set; }
        public int VehicleFrequencyInEast { get; set; }
        public int VehicleFrequencyInWest { get; set; }
        public int CarExitTime { get; set; }
    }

    public class TrafficLight
    {
        public int TotalLightInSeconds { get; set; }
    }
}
