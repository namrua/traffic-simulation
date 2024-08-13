using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficLight
{
    public interface IEvent
    {
        void Execute(Simulator simulator);
        int EventTime { get; }
    }
}
