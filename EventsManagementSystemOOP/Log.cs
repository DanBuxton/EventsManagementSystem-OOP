using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsManagementSystemOOP
{
    internal sealed class Log
    {
        public static int _PrevID { private get; set; } = 0;
        public int Id { get; set; } = ++_PrevID;

        string Details { get; set; }
        public DateTime DateOfTransaction { get; set; } = DateTime.Now;

        public Log(TransactionDetails details)
        {
            Details = details.ToString();
        }

        internal sealed class TransactionDetails
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

            public TransactionDetails(Event ev, TransType type)
            {
                e = ev;
                this.type = type;
            }
            public TransactionDetails(Booking book, TransType type)
            {
                b = book;
                this.type = type;
            }

            public override string ToString()
            {
                string res = "Error";

                if (e != null || b != null)
                {
                    switch (type)
                    {
                        case TransType.Add:
                            res = "";
                            break;
                        case TransType.Update:
                            res = "";
                            break;
                        case TransType.Delete:
                            res = "";
                            break;
                        case TransType.Book:
                            res = "";
                            break;
                        case TransType.Cancel:
                            res = "";
                            break;
                        default:
                            res = "";
                            break;
                    }
                }

                return res;
            }
        }
    }
}
