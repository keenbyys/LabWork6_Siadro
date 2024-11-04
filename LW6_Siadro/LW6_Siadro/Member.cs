using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LW6_Siadro
{
    public abstract class Member
    {
        public string Name { get; set; }

        public Member(string name) => Name = name;

        public abstract void NotificationChangeStatus(string status, bool IsVIP);

        //public abstract string PrintInfo();
    }
}
