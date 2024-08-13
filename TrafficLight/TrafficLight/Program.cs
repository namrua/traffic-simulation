using System;
using TrafficLight;
using Microsoft.Extensions.DependencyInjection;
using Timer = System.Timers.Timer;
using static TrafficLight.Constant;

//add DI
var serviceProvider = new ServiceCollection()
    .AddTransient<SimpleTrafficLight>()
    .AddTransient<ICarHandler, CarHandler>()
    .AddTransient<ITrafficLightHandler, TrafficLightHandler>()
    .AddTransient<ITrafficLight, SimpleTrafficLight>()
    .BuildServiceProvider();
var initialTimeAppStart = DateTime.Now;

//default those values before we have azure app configs mechanism
int vehicleFrequencyInNorth = 1; // Vehicle frequency per second in direction for North
int vehicleFrequencyInSouth = 1; // Vehicle frequency per second in direction for South
int vehicleFrequencyInEast = 1; // Vehicle frequency second min in direction for East
int vehicleFrequencyInWest = 1; // Vehicle frequency second min in direction for West
int vehicleFrequencyNS = vehicleFrequencyInNorth + vehicleFrequencyInSouth;
int vehicleFrequencyEW = vehicleFrequencyInEast + vehicleFrequencyInWest;
int carExitTime = 5; // Time for a car to exit the crossroad

var nsLight = serviceProvider.GetRequiredService<SimpleTrafficLight>();
var ewLight = serviceProvider.GetRequiredService<SimpleTrafficLight>();
var carHandler = serviceProvider.GetRequiredService<ICarHandler>();
var trafficLightHandler = serviceProvider.GetRequiredService<ITrafficLightHandler>();

var (periodX1, periodX2) = Helper.CalculateTrafficLight(100, vehicleFrequencyNS, vehicleFrequencyEW);
trafficLightHandler.SetDefaultValues(periodX1, periodX2, 0);

//schedular Car direction
carHandler.AddCar(new Car(direction: Direction.North, carExitTime: carExitTime, carArrivalTimeSeconds: vehicleFrequencyInNorth * 60));
carHandler.AddCar(new Car(direction: Direction.South, carExitTime: carExitTime, carArrivalTimeSeconds: vehicleFrequencyInSouth * 60));
carHandler.AddCar(new Car(direction: Direction.East, carExitTime: carExitTime, carArrivalTimeSeconds: vehicleFrequencyInEast * 60));
carHandler.AddCar(new Car(direction: Direction.West, carExitTime: carExitTime, carArrivalTimeSeconds: vehicleFrequencyInWest * 60));
var simulator = new Simulator();

simulator.ScheduleEvent(carHandler, carExitTime);

//default light when application start: NS is Green and EW is Red
simulator.ScheduleEvent(trafficLightHandler, periodX1);

// Run the simulation
simulator.Run();

// This block is out side the implementation
// Simulate the traffic light and Car arrival
var trafficLightTimer = new Timer(1 * 1000);
trafficLightTimer.Elapsed += (sender, e) =>
{
    var time = (DateTime.Now - initialTimeAppStart).Seconds;
    trafficLightHandler.UpdateLights(time);
    Console.WriteLine("TimeAppRun: " + time);
    Console.WriteLine(trafficLightHandler.GetLightStatus());
};
trafficLightTimer.Start();

Console.ReadLine();