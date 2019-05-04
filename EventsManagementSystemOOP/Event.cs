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
        public static Dictionary<int, Event> Events { get; private set; } = new Dictionary<int, Event>();

        public static int _TotalNumberOfEvents { get; set; } = 0;

        public static int _PrevId { get; set; } = 0;
        public int Id { get; set; } = ++_PrevId;

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
        public DateTime DateUpdated { get; set; }

        public Dictionary<int, Booking> Bookings { get; set; } = new Dictionary<int, Booking>();

        public Event(string name, int numOfPlaces, double pricePerTicket)
        {
            Name = name;
            PricePerTicket = pricePerTicket;

            Bookings = new Dictionary<int, Booking>();
            NumberOfTicketsLeft = numOfPlaces;
            NumberOfTicketsOverall = numOfPlaces;

            Events.Add(Id, this);

            _TotalNumberOfEvents++;
        }
        ~Event()
        {
            _TotalNumberOfEvents--;
        }

        public static Event GetEvent(int code)
        {
            Event e = null;

            int min = 1;
            int max = Events.Count - 1;
            int mid = (min + max) / 2;

            while (1 <= Events.Count && e == null)
            {
                mid = (min + max) / 2;

                if (code == Events[mid].Id)
                {
                    e = Events[mid];
                }
                else if (code < Events[mid].Id)
                {
                    max = mid - 1;
                }
                else
                {
                    min = mid + 1;
                }
            }

            return e;
        }

        public static bool DeleteEvent(int id)
        {
            return Events.Remove(id);
        }

        public void AddTickets(int amount)
        {
            NumberOfTicketsOverall += amount;
        }

        public bool RemoveTickets(int amount)
        {
            bool result = Bookings.Count <= (NumberOfTicketsOverall - amount);

            if (result)
                AddTickets(-amount);

            return result;
        }

        public bool AddBooking(Booking b)
        {
            bool result = false;

            try
            {
                if (NumberOfTicketsOverall <= (NumberOfTicketsLeft - 1))
                {
                    b.Event = this;

                    Bookings.Add(b.Id, b);

                    result = true;
                }
            }
            catch (Exception) { }

            return result;
        }

        private bool RemoveBooking(int id)
        {
            bool result = false;

            try
            {
                if (Bookings.ContainsKey(id))
                {
                    result = Bookings.Remove(id);
                }
            }
            catch (ArgumentNullException) { }

            return result;
        }
        public bool RemoveBooking(Booking b)
        {
            NumberOfTicketsLeft += b.NumberOfTickets;
            return RemoveBooking(b.Id);
        }
    }
}
