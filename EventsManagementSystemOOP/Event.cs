using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsManagementSystemOOP
{
    public sealed class Event
    {
        public static int _TotalNumberOfEvents { get; set; } = 0;

        public static int _PrevID { get; set; } = 0;
        public int Id { get; set; } = ++_PrevID;

        public string Name { get; set; }
        public int NumberOfTicketsOverall { get; set; }
        public int NumberOfTicketsLeft { get; set; }

        private double pricePerTicket = 5.99;
        public double PricePerTicket
        {
            get => pricePerTicket;
            set
            {
                pricePerTicket = (value >= 0 ? value : pricePerTicket);
            }
        }

        public DateTime DateAdded { get; set; } = DateTime.Now;

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

        public bool RemoveTickets(int noOfTickets)
        {
            bool result = Bookings.Count <= (NumberOfTicketsOverall - noOfTickets);

            if (result)
                AddTickets(-noOfTickets);

            return result;
        }

        public void AddTickets(int ticketsToAdd)
        {
            NumberOfTicketsOverall += ticketsToAdd;
        }

        public bool AddBooking(Booking b)
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

        public bool RemoveBooking(int id)
        {
            bool result = Bookings.Remove(id);

            if (result)
                NumberOfTicketsLeft++;

            return result;
        }
        public bool RemoveBooking(Booking b)
        {
            return RemoveBooking(b.Id);
        }
    }
}
