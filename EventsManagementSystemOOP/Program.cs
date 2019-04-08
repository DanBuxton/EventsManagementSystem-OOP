using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsManagementSystemOOP
{
    class Program
    {
        public List<Event> Events { get; set; } = new List<Event>();
        public List<Log> Logs { get; set; } = new List<Log>();

        static void Main(string[] args)
        {
            Booking b = new Booking();
            new Event("").Bookings.Add(b.Id, b);
        }
    }
}
