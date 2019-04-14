using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsManagementSystemOOP
{
    public sealed class Log
    {
        public static int _PrevID { private get; set; } = 0;
        public int Id { get; set; } = ++_PrevID;

        public string Details { get; set; }
        public DateTime DateOfTransaction { get; set; } = DateTime.Now;

        public Log(LogDetails details)
        {
            Details = details.ToString();
        }

        public sealed class LogDetails
        {
            private readonly Event e = null;
            private readonly Booking b = null;
            private readonly TransType type;

            public enum TransType
            {
                Add,
                Update,
                Delete,
                Book,
                Cancel
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="ob">An Event or Booking instance</param>
            /// <param name="type"></param>
            public LogDetails(object ob, TransType type)
            {
                e = ob as Event;
                b = ob as Booking;

                this.type = type;
            }
        }
    }
}
