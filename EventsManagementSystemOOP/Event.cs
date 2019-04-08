using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsManagementSystemOOP
{
    class Event
    {
        public static int _PrevID { private get; set; } = 0;
        public int Id { get; set; } = ++_PrevID;

        public string Name { get; set; }
        public int NumberOfTicketsTotal { get; set; }
        public int NumberOfTicketsLeft { get; set; }

        private double pricePerTicket = 5.99;
        public double PricePerTicket
        {
            get => pricePerTicket;
            set
            {
                pricePerTicket = (value > 0 ? value : pricePerTicket);
            }
        }

        public DateTime DateAdded { get; set; } = DateTime.Now;

        public Dictionary<int, Booking> Bookings { get; set; } = new Dictionary<int, Booking>();

        public Event(string name)
        {
            Name = name;
        }
    }
}
