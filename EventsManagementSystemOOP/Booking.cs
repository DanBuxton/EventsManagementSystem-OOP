using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsManagementSystemOOP
{
    internal sealed class Booking
    {
        internal static int _PrevID { private get; set; } = 0;
        internal int Id { get; set; } = ++_PrevID;

        private Event _event;

        public Booking(Event e)
        {
            _event = e;
        }

        internal void RemoveEvent()
        {
            _event = null;
        }
    }
}
