using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficLight
{
    public interface IQueueEvent
    {
        void Execute();
        int EventTime { get; }
        void ChangeEventTime(int time);
    }
}
