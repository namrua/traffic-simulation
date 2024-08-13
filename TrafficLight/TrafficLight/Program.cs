using System;
using TrafficLight;
using Microsoft.Extensions.DependencyInjection;
using Timer = System.Timers.Timer;
using static TrafficLight.Constant;

//add DI
var serviceProvider = new ServiceCollection()
    .AddScoped<ITrafficLight, SimpleTrafficLight>()
    .AddScoped<IEvent, CarArrivalEvent>()
    .AddScoped<IEvent, TrafficLightChangeEvent>()
    .BuildServiceProvider();

var initialTimeAppStart = DateTime.Now;
int applicationTimeRun;
var nsLight = serviceProvider.GetRequiredService<ITrafficLight>();
var ewLight = serviceProvider.GetRequiredService<ITrafficLight>();

//default those values before we have azure app configs mechanism
int vehicleFrequencyInNorth = 60; // Vehicle frequency per second in direction for North
int vehicleFrequencyInSouth = 60; // Vehicle frequency per second in direction for South
int vehicleFrequencyInEast = 60; // Vehicle frequency second min in direction for East
int vehicleFrequencyInWest = 60; // Vehicle frequency second min in direction for West
int vehicleFrequencyNS = vehicleFrequencyInNorth + vehicleFrequencyInSouth;
int vehicleFrequencyEW = vehicleFrequencyInEast + vehicleFrequencyInWest;
int carExitTime = 5; // Time for a car to exit the crossroad

var (periodX1, periodX2) = Helper.CalculateTrafficLight(100, vehicleFrequencyNS, vehicleFrequencyEW);
var trafficLightHandler = new TrafficLightHandler(nsLight, ewLight, periodX1, periodX2);
var crossroad = new CarHandler(trafficLightHandler, carExitTime);
var simulator = new Simulator(crossroad, trafficLightHandler);

// Schedule for car arrivals based on vehicle frequency, simulate 5 cars for each direction
//for (int i = 1; i <= 5; i++)
//{
//    simulator.ScheduleEvent(new CarArrivalEvent(i * vehicleFrequencyInNorth, "North", simulator));
//    simulator.ScheduleEvent(new CarArrivalEvent(i * vehicleFrequencyInSouth, "South", simulator));
//    simulator.ScheduleEvent(new CarArrivalEvent(i * vehicleFrequencyInEast, "East", simulator));
//    simulator.ScheduleEvent(new CarArrivalEvent(i * vehicleFrequencyInWest, "West", simulator));
//}

// Schedule for car arrivals based on vehicle frequency, simulate 5 cars for each direction
var carTimer = new Timer(vehicleFrequencyInNorth * 100);
var loopCount = 0;
carTimer.Elapsed += (sender, e) =>
{
    loopCount++;
    simulator.ScheduleEvent(new CarArrivalEvent(loopCount * vehicleFrequencyInNorth, Direction.North.ToString(), simulator));
};

//default light when application start: NS is Green and EW is Red
simulator.ScheduleEvent(new TrafficLightChangeEvent(0, simulator));

// Schedule the event to run every 5 seconds for example
var trafficLightTimer = new Timer(5 * 1000);
trafficLightTimer.Elapsed += (sender, e) =>
{
    applicationTimeRun = (DateTime.Now - initialTimeAppStart).Seconds;
    simulator.ScheduleEvent(new TrafficLightChangeEvent(applicationTimeRun, simulator));
};
trafficLightTimer.Start();

//stop simulation after 10 minutes
if ((DateTime.Now - initialTimeAppStart).Minutes == 10)
{
    trafficLightTimer.Stop();
}

// Get the initial light status
trafficLightHandler.GetLightStatus();
// Run the simulation
simulator.Run();