using System;
using TrafficLight;
using Microsoft.Extensions.DependencyInjection;
using static TrafficLight.Constant;
using Microsoft.Extensions.Configuration;
using TrafficLightSimulation;
using TrafficLightSimulation.Car;

internal class Program
{
    private static void Main(string[] args)
    {
        // Add DI
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .AddUserSecrets<Program>();

        IConfiguration config = builder.Build();
        var applicationSettings = new ApplicationSettings();
        config.GetSection("ApplicationSettings").Bind(applicationSettings);

        var serviceProvider = new ServiceCollection()
            .AddDI(config)
            .BuildServiceProvider();

        int VNorth = applicationSettings.Vehicle.VehicleFrequencyInNorth;
        int VSouth = applicationSettings.Vehicle.VehicleFrequencyInSouth;
        int VEast = applicationSettings.Vehicle.VehicleFrequencyInEast;
        int VWest = applicationSettings.Vehicle.VehicleFrequencyInWest;
        int carExitTime = applicationSettings.Vehicle.CarExitTime;
        int totalLightInSeconds = applicationSettings.TrafficLight.TotalLightInSeconds;

        var simulator = new Simulator();
        var northSouthLight = serviceProvider.GetRequiredService<SampleTrafficLight>();
        var eastWestLight = serviceProvider.GetRequiredService<SampleTrafficLight>();
        var carHandler = serviceProvider.GetRequiredService<ICarHandler>();
        var trafficLightHandler = serviceProvider.GetRequiredService<ITrafficLightHandler>();

        var (periodX1, periodX2) = Helper.CalculateTrafficLight(totalLightInSeconds, VNorth + VSouth, VEast + VWest);
        trafficLightHandler.SetDefaultValues(periodX1, periodX2, 0);

        // Schedule cars in each direction
        carHandler.AddCarInQueue(new Car(direction: Direction.North, carExitTime: carExitTime, carArrivalTimeSeconds: VNorth));
        carHandler.AddCarInQueue(new Car(direction: Direction.South, carExitTime: carExitTime, carArrivalTimeSeconds: VSouth));
        carHandler.AddCarInQueue(new Car(direction: Direction.East, carExitTime: carExitTime, carArrivalTimeSeconds: VEast));
        carHandler.AddCarInQueue(new Car(direction: Direction.West, carExitTime: carExitTime, carArrivalTimeSeconds: VWest));

        simulator.ScheduleEvent(carHandler, 100);

        // Set default traffic light when application starts: NS is Green and EW is Red
        simulator.ScheduleEvent(trafficLightHandler, periodX1);

        // Run the simulation
        simulator.Run(trafficLightHandler, carHandler);
       
    }
}