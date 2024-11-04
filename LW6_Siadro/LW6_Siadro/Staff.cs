using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LW6_Siadro
{
    public class Staff : Member
    {
        public Staff(string name) : base(name) { }

        public override void NotificationChangeStatus(string status, bool IsVIP)
        {
                Console.WriteLine("{Name} (staff): Flight status updated to {status}", Name, status);
        }
    }
}
