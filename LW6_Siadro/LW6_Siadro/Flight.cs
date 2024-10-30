using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LW6_Siadro
{
    public class Flight
    {
        public string Name { get; set; }
        public string Status {  get; set; }

        public Flight(string name, string status)
        {
            Name = name;
            Status = status;
        }

        public string PrintName() { return Name; }

        public string PrintStatus() { return Status; }

        public delegate void FlightStatusChangeHandler(Flight flight);
        public event FlightStatusChangeHandler FlightStatusChanged;

        private List<Member> passengers = new List<Member>();
        private List<Member> _staff = new List<Member>();
        private List<Flight> flights = new List<Flight>();


        public void AddPassenger(Passenger passenger)
        {
            passengers.Add(passenger);
            Subscribe(passenger);
        }
            
        public void AddStaff(Staff staff)
        {
            _staff.Add(staff);
            Subscribe(staff);
        }

        public void AddFlight(Flight flight)
        {
            flights.Add(flight);
        }


        public void Subscribe(Member member)
        {
            switch (member)
            {
                case null: break;

                default:
                    FlightStatusChanged += member.NotificationChangeStatus;
                    break;
            }
        }

        public void Unsubscribe(Member member)
        {
            switch (member)
            {
                case null: break;

                default:
                    FlightStatusChanged -= member.NotificationChangeStatus;
                    break;
            }
        }


        public void ChangeStatus(Flight flight, int randomNumber, string nameFlight)
        {
            var passengerFlight = flights.Find(f => f.Name == nameFlight);
            switch (flight.Status)
            {
                case "Expected":
                    
                    switch (randomNumber)
                    {
                        case 0:
                            Status = "Boarding";
                            break;
                    }


                    Status = "Boarding";
                    Console.WriteLine();
                    FlightStatusChanged?.Invoke(this);
                    break;

                case "":
                    break;
            }
        }

    }
}
