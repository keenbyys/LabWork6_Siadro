using System;
using System.Collections;
using System.Diagnostics;
using System.Threading;
using System.Xml.Linq;

namespace LW6_Siadro
{
    class Program
    {
        private static bool isInputCorrect = true;
        private static FlightMonitoring flightMonitor = new FlightMonitoring();
        private static int choice;
        private static string passengerName;
        private static bool isVIP;
        private static int passengerStatus;
        private static string flightNameForPassenger;

        public static void MainMenu()
        {
            Console.WriteLine("\n Select an action: " +
                "\n [1] Add flight " +
                "\n [2] Register passenger " +
                "\n [3] Register staff " +
                "\n [4] Change flight status " +
                "\n [5] Exit");
            
            while (isInputCorrect)
            {
                try
                {
                    Console.Write("\n Enter a number: ");
                    choice = Convert.ToInt32(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            Console.Clear();
                            ConfirmationSelect(1);
                            isInputCorrect = false;
                            break;
                        
                        case 2:
                            Console.Clear();
                            ConfirmationSelect(2);
                            isInputCorrect = false;
                            break;
                        
                        case 3:
                            Console.Clear();
                            RegisterNewStaff();
                            isInputCorrect = false;
                            break;
                        
                        case 4:
                            Console.Clear();
                            ChangeFlightStatusMenu();
                            Console.WriteLine("\n Continue monitoring?" +
                                "\n [1] Yes" +
                                "\n [2] No");
                            isInputCorrect = Console.ReadLine().ToLower() == "1";
                            break;
                        
                        case 5:
                            Console.Clear();
                            Exit();
                            isInputCorrect = false;
                            break;
                        
                        default:
                            Console.Clear();
                            Console.WriteLine("\n Non-numeric data were entered. " +
                                "\n Try entering numbers: 1 or 2 or 3 or 4 or 5! :3");
                            MainMenu();
                            isInputCorrect = false;
                            break;
                    }
                }
                catch
                {
                    Console.Clear();
                    Console.WriteLine("\n Non-numeric data were entered. " +
                        "\n Try entering numbers: 1 or 2 or 3 or 4 or 5! :3");
                    MainMenu();
                    isInputCorrect = false;
                }
            }
        }

        public static void ConfirmationSelect(int choiceNum)
        {
            while (isInputCorrect)
            {
                try
                {
                    Console.WriteLine("\n Are you sure you want to make that choice?" +
                        "\n [1] Yes" +
                        "\n [2] Nah, I want to go back to the main menu.");

                    Console.Write("\n Your choice (number): ");
                    choice = Convert.ToInt32(Console.ReadLine());

                    if (choice == 1)
                    {
                        switch(choiceNum)
                        {
                            case 1:
                                Console.Clear();
                                AddNewFlight();
                                isInputCorrect = false;
                                break;

                            case 2:
                                Console.Clear();
                                AddNamePassenger();
                                isInputCorrect = false;
                                break;
                        }

                        Console.Clear();
                        AddStatusPassanger(passengerName);
                        isInputCorrect = false;
                    }
                    else if (choice == 2)
                    {
                        Console.Clear();
                        MainMenu();
                        isInputCorrect = false;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("\n It seems that you have entered a number that is not on this list. " +
                            "\n Try entering it again: 1 or 2! :D");
                        ConfirmationSelect(choiceNum);
                        isInputCorrect = false;
                    }
                }
                catch
                {
                    Console.Clear();
                    Console.WriteLine("\n It seems that you have entered a number that is not on this list. " +
                        "\n Try entering it again: 1 or 2! :D");
                    ConfirmationSelect(choiceNum);
                    isInputCorrect = false;
                }
            }
        }

        public static void AddNewFlight()
        {
            while (isInputCorrect)
            {
                Console.WriteLine("\n Enter the data for the new flight.");
                Console.Write("\n Enter name (flight): ");
                string flightName = Console.ReadLine();

                switch (flightName)
                {
                    case "":
                        Console.Clear();
                        Console.WriteLine("\n You haven't entered anything. Please try again!");
                        AddNewFlight();
                        isInputCorrect = false;
                        break;

                    default:
                        Flight flight = new Flight(flightName);
                        flightMonitor.AddFlight(flight);
                        Console.WriteLine(" Flight added.");
                        MainMenu();
                        isInputCorrect = false;
                        break;
                }  
            }
        }

        public static void AddNamePassenger()
        {
            Console.Write("\n Enter name (passenger): ");

            while (isInputCorrect)
            {
                passengerName = Console.ReadLine();
                if (passengerName == "")
                {
                    Console.Clear();
                    Console.WriteLine("\n You haven't entered anything. Please try again!");
                    AddNamePassenger();
                    isInputCorrect = false;
                }
                else
                {
                    Console.Clear();
                    ConfirmationSelectName(passengerName);
                    isInputCorrect = false;
                }
            }
        }

        public static void ConfirmationSelectName(string passengerName)
        {
            while (isInputCorrect)
            {
                try 
                {
                    Console.WriteLine("\n Are you happy with the name you've given the passenger?" +
                        "\n [1] Yes" +
                        "\n [2] Nah, I want to change the passenger name.");

                    Console.Write("\n Your choice (number): ");
                    choice = Convert.ToInt32(Console.ReadLine());

                    if (choice == 1)
                    {
                        Console.Clear();
                        AddStatusPassanger(passengerName);
                        isInputCorrect = false;
                    }
                    else if (choice == 2)
                    {
                        Console.Clear();
                        AddNamePassenger();
                        isInputCorrect = false;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("\n It seems that you have entered a number that is not on this list. " +
                            "\n Try entering it again: 1 or 2! :D");
                        ConfirmationSelectName(passengerName);
                        isInputCorrect = false;
                    }
                }
                catch
                {
                    Console.Clear();
                    Console.WriteLine("\n It seems that you have entered a number that is not on this list. " +
                        "\n Try entering it again: 1 or 2! :D");
                    ConfirmationSelectName(passengerName);
                    isInputCorrect = false;
                }
            }
        }

        public static void AddStatusPassanger(string passengerName)
        {
            while (isInputCorrect) 
            {
                try
                {
                    Console.WriteLine("\n Is this passenger VIP? " +
                        "\n [1] Yep" +
                        "\n [2] Nope");

                    Console.Write("\n Your choice (number): ");
                    choice = Convert.ToInt32(Console.ReadLine());

                    if (choice == 1)
                    {
                        Console.Clear();
                        isVIP = true;
                        ConfirmationSelectVIP(passengerName, isVIP);
                    }
                    else if (choice == 2)
                    {
                        Console.Clear();
                        isVIP = false;
                        ConfirmationSelectVIP(passengerName, isVIP);
                    }
                    else 
                    {
                        Console.Clear();
                        Console.WriteLine("\n It seems that you have entered a number that is not on this list. " +
                            "\n Try entering it again: 1 or 2! :D");
                        AddStatusPassanger(passengerName);
                        isInputCorrect = false;
                    }
                }
                catch
                {
                    Console.Clear();
                    Console.WriteLine("\n It seems that you have entered a number that is not on this list. " +
                        "\n Try entering it again: 1 or 2! :D");
                    AddStatusPassanger(passengerName);
                    isInputCorrect = false;
                }
            }
        }

        public static void ConfirmationSelectVIP(string passengerName, bool isVIP)
        {
            while (isInputCorrect)
            {
                try
                {
                    Console.WriteLine("\n Are you sure you have chosen the right status?" +
                        "\n [1] Yes" +
                        "\n [2] Nah, I want to change the passenger status.");

                    Console.Write("\n Your choice (number): ");
                    choice = Convert.ToInt32(Console.ReadLine());

                    if (choice == 1)
                    {
                        Console.Clear();
                        AddPassengerToFlight(passengerName, isVIP);
                        isInputCorrect = false;
                    }
                    else if (choice == 2)
                    {
                        Console.Clear();
                        AddStatusPassanger(passengerName);
                        isInputCorrect = false;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("\n It seems that you have entered a number that is not on this list. " +
                            "\n Try entering it again: 1 or 2! :D");
                        ConfirmationSelectVIP(passengerName, isVIP);
                        isInputCorrect = false;
                    }
                }
                catch
                {
                    Console.Clear();
                    Console.WriteLine("\n It seems that you have entered a number that is not on this list. " +
                        "\n Try entering it again: 1 or 2! :D");
                    ConfirmationSelectVIP(passengerName, isVIP);
                    isInputCorrect = false;
                }
            }
        }

        public static void AddPassengerToFlight(string passengerName, bool isVIP) 
        {
            while (isInputCorrect)
            {
                flightMonitor.PrintFlights();
                Console.Write("\n Enter name (flight): ");
                flightNameForPassenger = Console.ReadLine();

                if (flightNameForPassenger == "")
                {
                    Console.Clear();
                    Console.WriteLine("\n You haven't entered anything. Please try again!");
                    AddPassengerToFlight(passengerName, isVIP);
                    isInputCorrect = false;
                }
                else
                {
                    Console.Clear();
                    ConfirmationSelectNameFlight(passengerName, isVIP, flightNameForPassenger);
                    isInputCorrect = false;
                }
            }
        }

        public static void ConfirmationSelectNameFlight(string passengerName, bool isVIP, string flightNameForPassenger)
        {
            while (isInputCorrect)
            {
                try
                {
                    Console.WriteLine("\n Are you sure you have chosen the right flight?" +
                        "\n [1] Yes" +
                        "\n [2] Nah, I want to change the flight.");

                    Console.Write("\n Your choice (number): ");
                    choice = Convert.ToInt32(Console.ReadLine());

                    if (choice == 1)
                    {
                        Console.Clear();
                        var passengerFlight = flightMonitor.GetFlight(flightNameForPassenger);

                        if (passengerFlight != null)
                        {
                            Passenger passenger = isVIP ? new PassengerVIP(passengerName) : new Passenger(passengerName);
                            passengerFlight.RegisterPassenger(passenger);
                            Console.WriteLine(isVIP ? "\n VIP Passenger registered." : "\n Passenger registered.");
                            MainMenu();
                            isInputCorrect = false;
                        }
                        else
                        {
                            Console.WriteLine("\n Flight not found.");
                            AddPassengerToFlight(passengerName, isVIP);
                            isInputCorrect = false;
                        }
                    }
                    else if (choice == 2)
                    {
                        Console.Clear();
                        AddPassengerToFlight(passengerName, isVIP);
                        isInputCorrect = false;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("\n It seems that you have entered a number that is not on this list. " +
                            "\n Try entering it again: 1 or 2! :D");
                        ConfirmationSelectNameFlight(passengerName, isVIP, flightNameForPassenger);
                        isInputCorrect = false;
                    }
                }
                catch
                {
                    Console.Clear();
                    Console.WriteLine("\n It seems that you have entered a number that is not on this list. " +
                        "\n Try entering it again: 1 or 2! :D");
                    ConfirmationSelectNameFlight(passengerName, isVIP, flightNameForPassenger);
                    isInputCorrect = false;
                }
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
            flightMonitor.PrintFlights();
            Console.Write("Enter Flight Number: ");
            string flightNameForStatus = Console.ReadLine();
            var statusFlight = flightMonitor.GetFlight(flightNameForStatus);


            if (statusFlight != null)
            {
                if (statusFlight.NoRegisteredUsers())
                {
                    Console.WriteLine("Flight {0} has no registered passengers or staff.", statusFlight.Name);
                    MainMenu();
                }

                if (statusFlight.Status == "Dispatched" || statusFlight.Status == "Canceled")
                {
                    Console.WriteLine("Users have already been unsubscribed from Flight {0} " +
                        "as it has reached a final status: {1}.", statusFlight.Name, statusFlight.Status);
                }
                else
                {
                    flightMonitor.ChangeFlightStatus(statusFlight);
                }
            }
            else
            {
                Console.WriteLine("Flight not found.");
            }
        }

        static void Exit()
        {
            Console.WriteLine("\n Oh, are you sure about that? (Т_Т)" +
                "\n [1] Yes" +
                "\n [2] No, can I go back in?");

            while (isInputCorrect)
            {
                try
                {
                    Console.Write("\n Your choice (number): ");
                    int choice = Convert.ToInt32(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("\n The application is now complete.\n");
                            isInputCorrect = false;
                            break;
                        
                        case 2:
                            Console.Clear();
                            MainMenu();
                            isInputCorrect = false;
                            break;
                        
                        default:
                            Console.Clear();
                            Console.WriteLine("\n It seems that you have entered a number that is not on this list. " +
                                "\n Try entering it again: 1 or 2! :D");
                            Exit();
                            isInputCorrect = false;
                            break;
                    }
                }
                catch
                {
                    Console.Clear();
                    Console.WriteLine("\n It seems that you have entered a number that is not on this list. " +
                        "\n Try entering it again: 1 or 2! :D");
                    Exit();
                    isInputCorrect = false;
                }
            }
        }

        static void Main(string[] args)
        {
            MainMenu();
        }
    }
}