using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LW6_Siadro
{
    public class Flight
    {
        public string Name { get; set; }
        public string Status { get; set; }

        public Flight(string name)
        {
            Name = name;
            Status = "Expected";
        }

        public delegate void StatusChangeHandler(Flight flight);
        public event StatusChangeHandler FlightStatusChange;

        private List<Passenger> regularPassengersList = new List<Passenger>();
        private List<PassengerVIP> vipPassengersList = new List<PassengerVIP>();
        private List<Staff> staffList = new List<Staff>();

        public bool NoRegisteredUsers()
        {
            return regularPassengersList.Count == 0 && vipPassengersList.Count == 0 && staffList.Count == 0;
        }

        public void RegisterPassenger(Passenger passenger)
        {
            if (passenger is PassengerVIP passengerVIP)
            {
                vipPassengersList.Add(passengerVIP);
            }
            else
            {
                regularPassengersList.Add(passenger);
            }

            FlightStatusChange += passenger.NotificationChangeStatus;
        }

        public void RegisterStaff(Staff staff)
        {
            staffList.Add(staff);
            FlightStatusChange += staff.NotificationChangeStatus;
        }

        public void UpdateStatus(string newStatus)
        {
            if (Status != newStatus)
            {
                Status = newStatus;
                Console.WriteLine("\n Flight {0} status updated to {1}", Name, Status);

                // Notify VIP passengers first
                foreach (PassengerVIP passengerVIP in vipPassengersList)
                {
                    passengerVIP.NotificationChangeStatus(this);
                }

                // Notify regular passengers
                foreach (Passenger passenger in regularPassengersList)
                {
                    passenger.NotificationChangeStatus(this);
                }

                // Notify staff
                foreach (Staff staff in staffList)
                {
                    staff.NotificationChangeStatus(this);
                }
            }
        }

        public void UnsubscribeAll()
        {
            // Clear all subscriptions
            foreach (PassengerVIP passengerVIP in vipPassengersList)
            {
                FlightStatusChange -= passengerVIP.NotificationChangeStatus;
            }
            foreach (Passenger passenger in regularPassengersList)
            {
                FlightStatusChange -= passenger.NotificationChangeStatus;
            }
            foreach (Staff staff in staffList)
            {
                FlightStatusChange -= staff.NotificationChangeStatus;
            }
        }
    }
}
