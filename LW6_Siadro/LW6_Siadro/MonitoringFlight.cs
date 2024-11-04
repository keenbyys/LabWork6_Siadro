using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LW6_Siadro
{
    public class MonitoringFlight
    {
        private List<Flight> flights = new List<Flight>();

        public void AddFlight(Flight flight)
        {
            flights.Add(flight);
        }

        public void ChangeStatus(Flight flight, int randomNumber, string nameFlight)
        {
            //Flight passengerFlight = flights.Find(f => f.Name == nameFlight);

            if (flight.Status == "Expected")
            {
                if (randomNumber == 0)
                {
                    flight.Boarding();
                }
                else if (randomNumber == 1)
                {
                    flight.Canceled();
                }
            }

            /*switch (flight.Status)
            {
                case "Expected":
                    
                    switch (randomNumber)
                    {
                        case 0:
                            Status = "Canceled";
                            FlightStatusChanged?.Invoke(this);
                            break;
                    }


                    Status = "Boarding";
                    Console.WriteLine();
                    FlightStatusChanged?.Invoke(this);
                    break;

                case "":
                    break;
            }*/
        }

        public void StartMonitoring()
        {
            bool continueMonitoring = true;

            while (continueMonitoring)
            {
                Console.WriteLine("Select an action:");
                Console.WriteLine("1. Add Flight");
                Console.WriteLine("2. Register Passenger");
                Console.WriteLine("3. Register Staff");
                Console.WriteLine("4. Change Flight Status");
                Console.WriteLine("5. Exit");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Console.Write("Enter Flight Number: ");
                        string flightNumber = Console.ReadLine();
                        Console.Write("Enter Flight Number: ");
                        string flightStatus = Console.ReadLine();
                        Flight flight = new Flight(flightNumber, flightStatus);
                        AddFlight(flight);
                        Console.WriteLine("Flight added.");
                        break;
                    case "2":
                        Console.Write("Enter Passenger Name: ");
                        string passengerName = Console.ReadLine();
                        Console.Write("Enter Flight Number: ");
                        string flightNumberForPassenger = Console.ReadLine();
                        var passenger = new Passenger(passengerName);
                        Flight passengerFlight = flights.Find(f => f.Name == flightNumberForPassenger);
                        if (passengerFlight != null)
                        {
                            passengerFlight.AddPassenger(passenger);
                            Console.WriteLine("Passenger registered.");
                        }
                        else
                        {
                            Console.WriteLine("Flight not found.");
                        }
                        break;
                    case "3":
                        Console.Write("Enter Staff Name: ");
                        string staffName = Console.ReadLine();
                        Console.Write("Enter Flight Number: ");
                        string flightNumberForStaff = Console.ReadLine();
                        var staff = new Staff(staffName);
                        Flight staffFlight = flights.Find(f => f.Name == flightNumberForStaff);
                        if (staffFlight != null)
                        {
                            staffFlight.AddStaff(staff);
                            Console.WriteLine("Staff registered.");
                        }
                        else
                        {
                            Console.WriteLine("Flight not found.");
                        }
                        break;
                    case "4":
                        Console.Write("Enter Flight Number: ");
                        string flightNumberForStatus = Console.ReadLine();
                        Flight statusFlight = flights.Find(f => f.Name == flightNumberForStatus);

                        if (statusFlight != null)
                        {
                            ChangeStatus(statusFlight, 0, flightNumberForStatus);
                            Console.WriteLine("Continue monitoring? (y/n): ");
                            continueMonitoring = Console.ReadLine().ToLower() == "y";
                        }
                        else
                        {
                            Console.WriteLine("Flight not found.");
                        }
                        break;
                    case "5":
                        continueMonitoring = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }
    }
}
