﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LW6_Siadro
{
    public class PassengerVIP : Passenger
    {
        public PassengerVIP(string name) : base(name) { }

        public override void NotificationChangeStatus(Flight flight)
        {
            Console.WriteLine("\n {0} (passenger — VIP): Flight [{1}] status updated to {2}", Name, flight.Name, flight.Status);
        }
    }
}