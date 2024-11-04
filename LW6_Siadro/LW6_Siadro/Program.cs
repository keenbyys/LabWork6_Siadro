using System;
using System.Collections;
using System.Diagnostics;
using System.Threading;
using System.Xml.Linq;

namespace LW6_Siadro
{
    class Program
    {
        private static FlightMonitoring flightMonitor = new FlightMonitoring();

        public static void MainMenu()
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
                        AddNewFlight();
                        break;
                    case "2":
                        RegisterNewPassenger();
                        break;
                    case "3":
                        RegisterNewStaff();
                        break;
                    case "4":
                        ChangeFlightStatusMenu();
                        Console.WriteLine("Continue monitoring? (y [1]/n [2]): ");
                        continueMonitoring = Console.ReadLine().ToLower() == "1";
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

        public static void AddNewFlight()
        {
            Console.Write("Enter Flight Number: ");
            string flightName = Console.ReadLine();
            Flight flight = new Flight(flightName);
            flightMonitor.AddFlight(flight);
            Console.WriteLine("Flight added.");
        }

        public static void RegisterNewPassenger()
        {
            Console.Write("Enter Passenger Name: ");
            string passengerName = Console.ReadLine();
            Console.Write("Is this passenger VIP? (y [1]/n [2]): ");
            bool isVip = Console.ReadLine().ToLower() == "1";
            Console.Write("Enter Flight Name: ");
            string flightNameForPassenger = Console.ReadLine();
            var passengerFlight = flightMonitor.GetFlight(flightNameForPassenger);

            if (passengerFlight != null)
            {
                Passenger passenger = isVip ? new PassengerVIP(passengerName) : new Passenger(passengerName);
                passengerFlight.RegisterPassenger(passenger);
                Console.WriteLine(isVip ? "VIP Passenger registered." : "Passenger registered.");
            }
            else
            {
                Console.WriteLine("Flight not found.");
            }
        }

        public static void RegisterNewStaff()
        {
            Console.Write("Enter Staff Name: ");
            string staffName = Console.ReadLine();
            Console.Write("Enter Flight Number: ");
            string flightNameForStaff = Console.ReadLine();
            var staffFlight = flightMonitor.GetFlight(flightNameForStaff);
            if (staffFlight != null)
            {
                var staff = new Staff(staffName);
                staffFlight.RegisterStaff(staff);
                Console.WriteLine("Staff registered.");
            }
            else
            {
                Console.WriteLine("Flight not found.");
            }
        }

        public static void ChangeFlightStatusMenu()
        {
            Console.Write("Enter Flight Number: ");
            string flightNameForStatus = Console.ReadLine();
            var statusFlight = flightMonitor.GetFlight(flightNameForStatus);
            if (statusFlight != null)
            {
                flightMonitor.ChangeFlightStatus(statusFlight);
            }
            else
            {
                Console.WriteLine("Flight not found.");
            }
        }

        static void Main(string[] args)
        {
            MainMenu();
        }
    }
}