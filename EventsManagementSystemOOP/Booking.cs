using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsManagementSystemOOP
{
    public sealed class Booking
    {
        public static int _PrevCode { get; set; } = 0;
        public int Code { get; set; } = ++_PrevCode;

        public Event E { get; set; }

        public Booking(Event e)
        {
            E = e;
        }
    }
}
