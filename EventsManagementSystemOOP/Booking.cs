using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsManagementSystemOOP
{
    public sealed class Booking
    {
        public static int _TotalNumberOfBookings = 0;
        public static int _PrevCode { get; set; } = 0;
        public int Code { get; set; } = ++_PrevCode;
        
        public Customer CustomerDetails { get; set; }
        public int NumberOfTickets { get; set; }

        public Event Event { get; set; }

        public Booking(Event e, Customer c, int numberOfTicketsToBuy)
        {
            _TotalNumberOfBookings++;
            Event = e;
            CustomerDetails = c;
            NumberOfTickets = numberOfTicketsToBuy;
        }

        public class Customer
        {
            public string Name { get; set; }
            public string Address { get; set; }

            public Customer(string name, string address)
            {
                Name = name;
                Address = address;
            }
        }
    }
}
