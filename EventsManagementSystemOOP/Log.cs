using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsManagementSystemOOP
{
    public sealed class Log
    {
        public static List<Log> TransactionLog { get; set; } = new List<Log>();

        public static int _PrevID { get; set; } = 0;
        public int Id { get; set; } = ++_PrevID;

        public LogDetails Details { get; set; }
        public DateTime DateOfTransaction { get; set; } = DateTime.Now;

        public Log(LogDetails details)
        {
            Details = details;

            TransactionLog.Add(this);
        }

        /// <summary>
        /// Details of the operation
        /// </summary>
        public sealed class LogDetails
        {
            public readonly Event ev = null;
            public readonly Booking b = null;
            public readonly TransType type;

            public enum TransType
            {
                Add,
                Update,
                Delete,
                Book,
                Cancel
            }

            /// <summary>
            /// Details of the operation
            /// </summary>
            /// <param name="ob">An Event or Booking instance</param>
            /// <param name="type">The type of operation performed</param>
            public LogDetails(object ob, TransType type)
            {
                ev = ob as Event;
                b = ob as Booking;

                this.type = type;
            }
        }
    }
}
