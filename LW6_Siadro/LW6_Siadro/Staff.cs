﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LW6_Siadro
{
    public class Staff : Member
    {
        public Staff (string name) : base(name) { }

        public override void NotificationChangeStatus(Flight flight)
        {
            Console.WriteLine("\n {0} (staff): Flight [{1}] status updated to {2}", Name, flight.Name, flight.Status);
        }
    }
}
