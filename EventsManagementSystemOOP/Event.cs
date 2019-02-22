using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsManagementSystemOOP
{
    class Event
    {
        public static int _TotalNumberOfEvents { get; set; } = 0;

        public static int _PrevID { private get; set; } = 0;
        public int Id { get; set; } = ++_PrevID;

        public string Name { get; set; }
        public int NumberOfTicketsTotal { get { return Bookings.Length; } }
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

        internal Booking[] Bookings { get; set; }

        public Event(string name, int numOfPlaces, double pricePerTicket)
        {
            Name = name;
            NumberOfTicketsLeft = numOfPlaces;
            PricePerTicket = pricePerTicket;

            Bookings = new Booking[numOfPlaces];

            _TotalNumberOfEvents++;
        }

        public bool AddTickets(int ticketsToAdd)
        {
            try
            {
                Booking[] bArray = new Booking[Bookings.Length + ticketsToAdd];

                for (int i = 0; i < Bookings.Length; i++)
                {
                    bArray[i] = Bookings[i];
                }

                Bookings = bArray;

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
