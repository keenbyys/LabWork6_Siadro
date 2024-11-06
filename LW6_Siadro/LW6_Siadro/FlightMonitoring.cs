using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LW6_Siadro
{
    public class FlightMonitoring
    {
        public FlightMonitoring() { }

        private List<Flight> flightsList = new List<Flight>();
        private Random random = new Random();

        public void AddFlight(Flight flight)
        {
            if (flightsList.Any(f => f.Name == flight.Name))
            {
                Console.Clear();
                Console.WriteLine("\n A flight with the number [{0}] already exists.", flight.Name);
                Program.AddNewFlight();
            }
            else
            {
                flightsList.Add(flight);
                Console.WriteLine("\n Flight {0} has been added.", flight.Name);
            }
        }

        public Flight GetFlight(string flightName)
        {
            return flightsList.Find(f => f.Name == flightName);
        }

        public void RemoveFlights()
        {
            var flightsToRemove = flightsList.Where(f => f.Status == "Dispatched" || f.Status == "Canceled").ToList();

            foreach (var flight in flightsToRemove)
            {
                flightsList.Remove(flight);
            }
        }

        public void ChangeFlightStatus(Flight flight)
        {
            switch (flight.Status)
            {
                case "Expected":
                    int randomStatus = random.Next(3);

                    switch (randomStatus)
                    {
                        case 0:
                            flight.UpdateStatus("Canceled");
                            flight.UnsubscribeAll();
                            RemoveFlights();
                            break;

                        case 1:
                            flight.UpdateStatus("Delayed");
                            break;

                        case 2:
                            flight.UpdateStatus("Boarding");
                            break;
                    }
                    break;

                case "Delayed":
                    randomStatus = random.Next(2);

                    switch (randomStatus) 
                    {
                        case 0:
                            flight.UpdateStatus("Canceled");
                            flight.UnsubscribeAll();
                            RemoveFlights();
                            break;

                        case 1:
                            flight.UpdateStatus("Boarding");
                            break;
                    }
                    break;

                case "Boarding":
                    flight.UpdateStatus("Dispatched");
                    flight.UnsubscribeAll();
                    RemoveFlights();
                    break;
            }
        }

        public void PrintFlights()
        {
            if (flightsList.Count == 0)
            {
                Console.WriteLine("\n No flights available.");
                Program.ConfirmationAddNewFlight();
                return;
            }

            Console.WriteLine("\n List of Flights:");
            foreach (var flight in flightsList)
            {
                Console.WriteLine(" Flight Name: [{0}] (status — {1})", flight.Name, flight.Status);
            }
        }
    }
}
