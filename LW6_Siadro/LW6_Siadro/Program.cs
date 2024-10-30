using System;
using System.Collections;
using System.Xml.Linq;

namespace LW6_Siadro
{
    class Program
    {
        static void Main(string[] args)
        {
            string namePassenger = "Nona";
            string nameFlight = "001";
            string statusFligt = "Expected";

            Passenger passenger = new Passenger(namePassenger);
            Flight flight = new Flight(nameFlight, statusFligt);

            Random random = new Random();

            flight.AddPassenger(passenger);
            flight.AddFlight(flight);

            Console.WriteLine(" {0}", passenger, flight);

            flight.ChangeStatus(flight, 0, statusFligt);
        }
    }
}