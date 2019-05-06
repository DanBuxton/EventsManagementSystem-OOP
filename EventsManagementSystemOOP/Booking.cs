using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsManagementSystemOOP
{
    public sealed class Booking
    {
        public static int _TotalNumberOfBookings { get; set; } = 0;
        public static int _PrevId { get; set; } = 0;
        public int Id { get; set; } = ++_PrevId;


        public Customer CustomerDetails { get; private set; }
        public int NumberOfTickets { get; private set; }

        private double price = 5.99;
        public double Price { get => NumberOfTickets * price; internal set => price = value; }

        public Event Event { get; internal set; }

        /// <summary>
        /// Must use Event.AddBooking()
        /// </summary>
        /// <param name="c">Customer details</param>
        /// <param name="numberOfTicketsToBuy">The amount of tickets to bbuy</param>
        public Booking(Customer c, int numberOfTicketsToBuy)
        {
            _TotalNumberOfBookings++;
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
