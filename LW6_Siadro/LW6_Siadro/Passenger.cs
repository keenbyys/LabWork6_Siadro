using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LW6_Siadro
{
    public class  Passenger : Member
    {
        public Passenger(string name) : base(name) { }

        public override void NotificationChangeStatus(string status, bool IsVIP)
        {
            if (IsVIP)
                Console.WriteLine("(VIP) {Name} (passenger): Flight status updated to {status}", Name, status);
            else
                Console.WriteLine("{Name} (passenger): Flight status updated to {status}", Name, status);
        }
    }
}
