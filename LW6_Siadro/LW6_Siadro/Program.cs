using System;
using System.Collections;
using System.Xml.Linq;

namespace LW6_Siadro
{
    class Program
    {
        static void Main(string[] args)
        {
            MonitoringFlight monitoringFlight = new MonitoringFlight();

            monitoringFlight.StartMonitoring();
        }
    }
}