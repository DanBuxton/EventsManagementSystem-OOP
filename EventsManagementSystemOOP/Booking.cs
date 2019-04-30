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


        public Customer CustomerDetails { get; private set; }
        public int NumberOfTickets { get; private set; }
        public double Price { get => NumberOfTickets * Event.PricePerTicket; }

        public Event Event { get; set; }

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

        ~Booking() {
            _TotalNumberOfBookings--;
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
