using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsManagementSystemOOP
{
    class Log
    {
        public static int _PrevID { private get; set; } = 0;
        public int Id { get; set; } = ++_PrevID;

        public string Details { get; set; }
        public DateTime DateOfTransaction { get; set; } = DateTime.Now;

        public Log(string details)
        {
            Details = details;
        }
    }
}
