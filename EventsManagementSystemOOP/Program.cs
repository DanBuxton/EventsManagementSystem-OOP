using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsManagementSystemOOP
{
    class Program
    {
        public static List<Event> Events { get; set; } = new List<Event>();
        public static List<Log> TransactionLog { get; set; } = new List<Log>();

        private const int ADD_EVENT = 1;
        private const int UPDATE_EVENT = 2;
        private const int DELETE_EVENT = 3;
        private const int BOOK_TICKETS = 4;
        private const int CANCEL_BOOKING = 5;

        private const int VIEW_EVENTS = 6;
        private const int VIEW_TRANSACTIONS = 7;
        
        private const int EXIT = 8;

        static void Main(string[] args)
        {
            int num;

            do
            {
                Console.Clear();

                Console.ForegroundColor = ConsoleColor.Gray;
                num = MenuResponse();

                Console.WriteLine($"Number > {num}");
                Console.ReadKey();

                switch (num)
                {
                    case ADD_EVENT:
                        AddAnEvent();
                        break;
                    case UPDATE_EVENT:
                        UpdateAnEvent();
                        break;
                    case DELETE_EVENT:
                        DeleteAnEvent();
                        break;
                    case BOOK_TICKETS:
                        BookTickets();
                        break;
                    case CANCEL_BOOKING:
                        CancelBooking();
                        break;
                    case VIEW_EVENTS:
                        ViewAllEvents();
                        break;
                    case VIEW_TRANSACTIONS:
                        ViewAllTransactions();
                        break;
                    case EXIT:

                        break;
                }
            } while (num != EXIT);
        }

        private static void AddAnEvent()
        {

        }

        private static void UpdateAnEvent()
        {

        }

        private static void DeleteAnEvent()
        {

        }

        private static void BookTickets()
        {

        }

        private static void CancelBooking()
        {

        }

        private static void ViewAllEvents()
        {

        }
        
        private static void ViewAllTransactions()
        {

        }

        private static void DisplayError(string msg, ConsoleColor colorAfter = ConsoleColor.Gray)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"ERROR > {msg}");
            Console.ForegroundColor = colorAfter;
        }

        private static void DisplayMenu()
        {
            Console.WriteLine("1  >  Add an event");
            Console.WriteLine("2  >  Update an event");
            Console.WriteLine("3  >  Delete an event");

            Console.WriteLine("4  >  Book tickets");
            Console.WriteLine("5  >  Remove a booking");

            Console.WriteLine("6  >  View all events");
            Console.WriteLine("7  >  View transaction log");

            Console.WriteLine();
        }

        private static int MenuResponse()
        {
            int? res = null;

            DisplayMenu();

            while (!res.HasValue)
            {
                Console.Write("Choice > ");

                try
                {
                    int num = int.Parse(Console.ReadLine());

                    if ((num <= EXIT) && (num >= ADD_EVENT))
                    {
                        res = num;
                    }
                    else { DisplayError(msg: "Please enter a number between 1 and 7"); }
                }
                catch (OverflowException) { DisplayError(msg: "Too many characters", colorAfter: ConsoleColor.Gray); }
                catch (FormatException) { DisplayError(msg: "Please enter a number character", colorAfter: ConsoleColor.Gray); }
                catch (Exception) { DisplayError(msg: "Please enter a number", colorAfter: ConsoleColor.Gray); }
            }

            return res.Value;
        }
    }
}
