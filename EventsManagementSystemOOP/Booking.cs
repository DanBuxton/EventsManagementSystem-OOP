using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsManagementSystemOOP
{
    class Booking
    {
        public static int _PrevID { private get; set; } = 0;
        public int Id { get; set; } = ++_PrevID;

        public Booking()
        {

        }
    }
}
