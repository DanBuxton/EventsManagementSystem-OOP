using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsManagementSystemOOP
{
    internal sealed class Event
    {
        public static int _TotalNumberOfEvents { get; set; } = 0;

        public static int _PrevID { get; set; } = 0;
        public int Id { get; set; } = ++_PrevID;

        internal string Name { get; set; }
        internal int NumberOfTicketsOverall { get; set; }
        internal int NumberOfTicketsLeft { get; set; }

        private double pricePerTicket = 5.99;
        internal double PricePerTicket
        {
            get => pricePerTicket;
            set
            {
                pricePerTicket = (value >= 0 ? value : pricePerTicket);
            }
        }

        internal DateTime DateAdded { get; set; } = DateTime.Now;

        public Dictionary<int, Booking> Bookings { get; set; } = new Dictionary<int, Booking>();

        public Event(string name, int numOfPlaces, double pricePerTicket)
        {
            Name = name;
            PricePerTicket = pricePerTicket;

            Bookings = new Dictionary<int, Booking>();
            NumberOfTicketsLeft = numOfPlaces;
            NumberOfTicketsOverall = numOfPlaces;

            _TotalNumberOfEvents++;
        }

        internal bool RemoveAmountOfTickets(int noOfTickets)
        {
            bool result = Bookings.Count <= (NumberOfTicketsOverall - noOfTickets);

            if (result)
                AddTickets(-noOfTickets);

            return result;
        }

        internal void AddTickets(int ticketsToAdd)
        {
            NumberOfTicketsOverall += ticketsToAdd;
        }

        internal bool AddBooking(Booking b)
        {
            bool result = false;

            try
            {
                if (NumberOfTicketsOverall <= (NumberOfTicketsLeft - 1))
                {
                    Bookings.Add(b.Id, b);

                    NumberOfTicketsLeft--;

                    result = true;
                }
            }
            catch (Exception) { }

            return result;
        }

        internal bool RemoveBooking(int id)
        {
            bool result = Bookings.Remove(id);

            if (result)
                NumberOfTicketsLeft++;

            return result;
        }
        internal bool RemoveBooking(Booking b)
        {
            return RemoveBooking(b.Id);
        }
    }
}
