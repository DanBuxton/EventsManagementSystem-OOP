using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsManagementSystemOOP
{
    internal sealed class Booking
    {
        public static int _PrevID { private get; set; } = 0;
        internal int Id { get; set; } = ++_PrevID;

        public Event E { get; set; }

        public Booking(Event e)
        {
            E = e;
        }
    }
}
