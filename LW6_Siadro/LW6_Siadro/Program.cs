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

        private static bool isVIP;
        private static bool isInputCorrect = true;

        private static int passengerStatus;
        private static int choice;
        
        private static string passengerName;
        private static string flightNameForPassenger;
        private static string staffName;
        private static string flightNameForStatus;

        public static void MainMenu()
        {
            while (isInputCorrect)
            {
                try
                {
                    Console.WriteLine("\n Select an action: " +
                        "\n [1] Add flight " +
                        "\n [2] Register passenger " +
                        "\n [3] Register staff " +
                        "\n [4] Change flight status " +
                        "\n [5] Exit");

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
                            ConfirmationSelect(3);
                            isInputCorrect = false;
                            break;
                        
                        case 4:
                            Console.Clear();
                            ConfirmationSelect(4);
                            isInputCorrect = false;
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

                    switch (choice)
                    {
                        case 1:
                            switch (choiceNum)
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

                                case 3:
                                    Console.Clear();
                                    AddNameStaff();
                                    isInputCorrect = false;
                                    break;

                                case 4:
                                    Console.Clear();
                                    ChangeFlightStatus();
                                    isInputCorrect = false;
                                    break;
                            }
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
                            ConfirmationSelect(choiceNum);
                            isInputCorrect = false;
                            break;
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

                switch (passengerName)
                {
                    case "":
                        Console.Clear();
                        Console.WriteLine("\n You haven't entered anything. Please try again!");
                        AddNamePassenger();
                        isInputCorrect = false;
                        break;

                    default:
                        Console.Clear();
                        ConfirmationSelectNamePassenger(passengerName);
                        isInputCorrect = false;
                        break;
                }
            }
        }

        public static void ConfirmationSelectNamePassenger(string passengerName)
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

                    switch (choice)
                    {
                        case 1:
                            Console.Clear();
                            AddStatusPassanger(passengerName);
                            isInputCorrect = false;
                            break;

                        case 2:
                            Console.Clear();
                            AddNamePassenger();
                            isInputCorrect = false;
                            break;

                        default:
                            Console.Clear();
                            Console.WriteLine("\n It seems that you have entered a number that is not on this list. " +
                                "\n Try entering it again: 1 or 2! :D");
                            ConfirmationSelectNamePassenger(passengerName);
                            isInputCorrect = false;
                            break;
                    }
                }
                catch
                {
                    Console.Clear();
                    Console.WriteLine("\n It seems that you have entered a number that is not on this list. " +
                        "\n Try entering it again: 1 or 2! :D");
                    ConfirmationSelectNamePassenger(passengerName);
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

                    switch (choice)
                    {
                        case 1:
                            Console.Clear();
                            isVIP = true;
                            ConfirmationSelectVIP(passengerName, isVIP);
                            break;

                        case 2:
                            Console.Clear();
                            isVIP = false;
                            ConfirmationSelectVIP(passengerName, isVIP);
                            break;

                        default:
                            Console.Clear();
                            Console.WriteLine("\n It seems that you have entered a number that is not on this list. " +
                                "\n Try entering it again: 1 or 2! :D");
                            AddStatusPassanger(passengerName);
                            isInputCorrect = false;
                            break;
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

                    switch (choice)
                    {
                        case 1:
                            Console.Clear();
                            AddPassengerToFlight(passengerName, isVIP);
                            isInputCorrect = false;
                            break;

                        case 2:
                            Console.Clear();
                            AddStatusPassanger(passengerName);
                            isInputCorrect = false;
                            break;

                        default:
                            Console.Clear();
                            Console.WriteLine("\n It seems that you have entered a number that is not on this list. " +
                                "\n Try entering it again: 1 or 2! :D");
                            ConfirmationSelectVIP(passengerName, isVIP);
                            isInputCorrect = false;
                            break;
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
            flightMonitor.PrintFlights();

            while (isInputCorrect)
            {
                Console.Write("\n Enter name (flight): ");
                flightNameForPassenger = Console.ReadLine();

                switch (flightNameForPassenger)
                {
                    case "":
                        Console.Clear();
                        Console.WriteLine("\n You haven't entered anything. Please try again!");
                        AddPassengerToFlight(passengerName, isVIP);
                        isInputCorrect = false;
                        break;

                    default:
                        Console.Clear();
                        ConfirmationSelectNameFlight(passengerName, isVIP, flightNameForPassenger);
                        isInputCorrect = false;
                        break;
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

                    switch (choice)
                    {
                        case 1:
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
                                ConfirmationAddNewFlight();
                                isInputCorrect = false;
                            }
                            break;

                        case 2:
                            Console.Clear();
                            AddPassengerToFlight(passengerName, isVIP);
                            isInputCorrect = false;
                            break;

                        default:
                            Console.Clear();
                            Console.WriteLine("\n It seems that you have entered a number that is not on this list. " +
                                "\n Try entering it again: 1 or 2! :D");
                            ConfirmationSelectNameFlight(passengerName, isVIP, flightNameForPassenger);
                            isInputCorrect = false;
                            break;
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

        public static void AddNameStaff()
        {
            Console.Write("\n Enter name (staff): ");
            
            while (isInputCorrect)
            {
                staffName = Console.ReadLine();

                switch (staffName)
                {
                    case "":
                        Console.Clear();
                        Console.WriteLine("\n You haven't entered anything. Please try again!");
                        AddNameStaff();
                        isInputCorrect = false;
                        break;

                    default:
                        Console.Clear();
                        ConfirmationSelectNameStaff(staffName);
                        isInputCorrect = false;
                        break;
                }
            }
        }

        public static void ConfirmationSelectNameStaff(string staffName)
        {
            while (isInputCorrect) 
            {
                try 
                {
                    Console.WriteLine("\n Are you happy with the name you've given the staff?" +
                        "\n [1] Yes" +
                        "\n [2] Nah, I want to change the staff name.");

                    Console.Write("\n Your choice (number): ");
                    choice = Convert.ToInt32(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            Console.Clear();
                            AddStaffToFlight(staffName);
                            isInputCorrect = false;
                            break;

                        case 2:
                            Console.Clear();
                            AddNameStaff();
                            isInputCorrect = false;
                            break;

                        default:
                            Console.Clear();
                            Console.WriteLine("\n It seems that you have entered a number that is not on this list. " +
                                "\n Try entering it again: 1 or 2! :D");
                            ConfirmationSelectNameStaff(staffName);
                            isInputCorrect = false;
                            break;
                    }
                }
                catch
                {
                    Console.Clear();
                    Console.WriteLine("\n It seems that you have entered a number that is not on this list. " +
                        "\n Try entering it again: 1 or 2! :D");
                    ConfirmationSelectNameStaff(staffName);
                    isInputCorrect = false;
                }
            } 
        }

        public static void AddStaffToFlight(string staffName)
        {
            flightMonitor.PrintFlights();
            
            while (isInputCorrect)
            {
                Console.Write("\n Enter name (flight): ");
                string flightNameForStaff = Console.ReadLine();

                switch (flightNameForPassenger)
                {
                    case "":
                        Console.Clear();
                        Console.WriteLine("\n You haven't entered anything. Please try again!");
                        AddStaffToFlight(staffName);
                        isInputCorrect = false;
                        break;

                    default:
                        Console.Clear();
                        ConfirmationSelectNameFlight(staffName, flightNameForStaff);
                        isInputCorrect = false;
                        break;
                }
            }
        }

        public static void ConfirmationSelectNameFlight(string staffName, string flightNameForStaff)
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

                    switch (choice)
                    {
                        case 1:
                            Console.Clear();
                            var staffFlight = flightMonitor.GetFlight(flightNameForStaff);

                            if (staffFlight != null)
                            {
                                var staff = new Staff(staffName);
                                staffFlight.RegisterStaff(staff);
                                Console.WriteLine("\n Staff registered.");
                                MainMenu();
                                isInputCorrect = false;
                            }
                            else
                            {
                                Console.WriteLine("\n Flight not found.");
                                ConfirmationAddNewFlight();
                                isInputCorrect = false;
                            }
                            break;

                        case 2:
                            Console.Clear();
                            AddStaffToFlight(staffName);
                            isInputCorrect = false;
                            break;

                        default:
                            Console.Clear();
                            Console.WriteLine("\n It seems that you have entered a number that is not on this list. " +
                                "\n Try entering it again: 1 or 2! :D");
                            ConfirmationSelectNameFlight(staffName, flightNameForStaff);
                            isInputCorrect = false;
                            break;
                    }
                }
                catch
                {
                    Console.Clear();
                    Console.WriteLine("\n It seems that you have entered a number that is not on this list. " +
                        "\n Try entering it again: 1 or 2! :D");
                    ConfirmationSelectNameFlight(staffName, flightNameForStaff);
                    isInputCorrect = false;
                }
            }
        }

        public static void ConfirmationAddNewFlight()
        {
            while (isInputCorrect)
            {
                try
                {
                    Console.WriteLine("\n Would you like to create a flight or select another existing flight?" +
                        "\n [1] Yes, to create a new flight." +
                        "\n [2] Yep, to select another existing flight." +
                        "\n [3] Nope, I want to go back to the main menu.");

                    Console.Write("\n Your choice (number): ");
                    choice = Convert.ToInt32(Console.ReadLine());

                    switch (choice) 
                    {
                        case 1:
                            Console.Clear();
                            AddNewFlight();
                            isInputCorrect = false;
                            break;

                        case 2:
                            Console.Clear();
                            AddStaffToFlight(staffName);
                            isInputCorrect = false;
                            break;

                        case 3:
                            Console.Clear();
                            MainMenu();
                            isInputCorrect = false;
                            break;

                        default:
                            Console.Clear();
                            Console.WriteLine("\n It seems that you have entered a number that is not on this list. " +
                                "\n Try entering it again: 1 or 2! :D");
                            ConfirmationAddNewFlight();
                            isInputCorrect = false;
                            break;
                    }
                }
                catch
                {
                    Console.Clear();
                    Console.WriteLine("\n It seems that you have entered a number that is not on this list. " +
                        "\n Try entering it again: 1 or 2! :D");
                    ConfirmationAddNewFlight();
                    isInputCorrect = false;
                }
            }
        }

        public static void ChangeFlightStatus()
        {
            flightMonitor.PrintFlights();

            while (isInputCorrect)
            {
                Console.Write("\n Enter name (flight): ");
                flightNameForStatus = Console.ReadLine();

                switch (flightNameForStatus)
                {
                    case "":
                        Console.Clear();
                        Console.WriteLine("\n You haven't entered anything. Please try again!");
                        ChangeFlightStatus();
                        isInputCorrect = false;
                        break;

                    default:
                        Console.Clear();
                        ConfirmationChangeFlightStatus(flightNameForStatus);
                        isInputCorrect = false;
                        break;
                }
            }
        }

        public static void ConfirmationChangeFlightStatus(string flightNameForStatus)
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

                    switch (choice)
                    {
                        case 1:
                            Console.Clear();
                            var statusFlight = flightMonitor.GetFlight(flightNameForStatus);

                            if (statusFlight != null)
                            {
                                if (statusFlight.NoRegisteredUsers())
                                {
                                    Console.Clear();
                                    Console.WriteLine("\n Flight {0} has no registered passengers or staff.", statusFlight.Name);
                                    MainMenu();
                                    isInputCorrect = false;
                                }
                                else
                                {
                                    Console.Clear();
                                    flightMonitor.ChangeFlightStatus(statusFlight);
                                    MainMenu();
                                    isInputCorrect = false;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Flight not found.");
                                ConfirmationAddNewFlight();
                                isInputCorrect = false;
                            }
                            break;

                        case 2:
                            Console.Clear();
                            ChangeFlightStatus();
                            isInputCorrect = false;
                            break;

                        default:
                            Console.Clear();
                            Console.WriteLine("\n It seems that you have entered a number that is not on this list. " +
                                "\n Try entering it again: 1 or 2! :D");
                            ConfirmationChangeFlightStatus(flightNameForStatus);
                            isInputCorrect = false;
                            break;
                    }
                }
                catch
                {
                    Console.Clear();
                    Console.WriteLine("\n It seems that you have entered a number that is not on this list. " +
                        "\n Try entering it again: 1 or 2! :D");
                    ConfirmationChangeFlightStatus(flightNameForStatus);
                    isInputCorrect = false;
                }
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