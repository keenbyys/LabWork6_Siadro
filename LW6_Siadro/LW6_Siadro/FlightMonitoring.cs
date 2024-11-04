using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LW6_Siadro
{
    public class FlightMonitoring
    {
        public FlightMonitoring()
        { 
        }

        private List<Flight> flightsList = new List<Flight>();
        private Random random = new Random();

        public void AddFlight(Flight flight)
        {
            flightsList.Add(flight);
        }

        public Flight GetFlight(string flightName)
        {
            return flightsList.Find(f => f.Name == flightName);
        }

        public void ChangeFlightStatus(Flight flight)
        {
            switch (flight.Status)
            {
                case "Expected":
                    int randomStatus = random.Next(3);
                    if (randomStatus == 0)
                    {
                        flight.UpdateStatus("Canceled");
                        flight.UnsubscribeAll(); // Unsubscribe if canceled
                    }
                    else if (randomStatus == 1)
                    {
                        flight.UpdateStatus("Delayed");
                    }
                    else
                    {
                        flight.UpdateStatus("Boarding");
                    }

                    break;

                case "Delayed":
                    flight.UpdateStatus("Boarding"); // Update to Boarding
                    break;

                case "Boarding":
                    flight.UpdateStatus("Dispatched"); // Update to Dispatched
                    flight.UnsubscribeAll(); // Unsubscribe after dispatch
                    break;
            }
        }
    }
}
