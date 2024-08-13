- My initial idea is to design classes/interfaces/handlers for Car and TrafficLight.
- My initial idea is to design the system with classes/interfaces/handlers for Car and TrafficLight.
- Use a queue as suggested in the first place, with events for the Car being arrival and departure, and events for the traffic light being state changes."
- CarHandler: Handle cars arriving, stopping at the crossroad if encountering a red light, and exiting the crossroad when encountering a green light.
- TrafficLightHandler: Handle the traffic lights at each intersection based on input parameters, including the frequency 
of cars on each road and the total number of seconds the green and red lights that based on the user's wish
- Simulator class: "Use it to simulate the operation of a road segment, with events like 'A car is coming from X direction in Y seconds' 
or 'Direction X traffic light turns Green in Y seconds.'"

Note:
- I have tried to separate the configurations and move them into `appsettings.json`
- My further goal is to use Azure App Configuration as a way to optimize the modification 
of configurations as fast as possible without code changes, without re-deployment

=> Imagine that in the future the user decide they want to change the total green and red light duration to 60 seconds to optimize traffic flow 
(the old configuration was 100 seconds). They would only need to update this in Azure App Config, and the new value would be immediately applied to 
the system without any additional actions required.
That's my idea. I shouldn't go too deep into the implementation details, so currently, I am using a secret file as a way to provide 
default values for the configuration.


Step to run:
1. Copy values in secret file into your local (I'll send it over), it includes all configurations that I mentioned above
2. Run the console app, you guys will see an action combo that will run every 5 seconds to update the current situation in Crossroad.

Think we need some unit tests or even functional testing to prove that the Simulator process runs as expected
But that was my idea if I have extra time to do as well as use Azure to store config.
