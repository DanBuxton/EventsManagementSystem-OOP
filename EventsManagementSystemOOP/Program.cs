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
                        DisplayMessage(msg: "Are you sure you want to exit, changes will not be saved? (y/n) ", isWarning: true, hasNewLine: false);
                        char response = Console.ReadLine()[0];


                        break;
                }
            } while (num != EXIT);

            Environment.Exit(0);
        }

        private static int GetNumber(int min = 1, int max = 9999)
        {
            int? result = null;

            Console.WriteLine("Enter a number between {min} and {max}");

            while (!result.HasValue || (result < min && result > max))
            {
                try
                {
                    result = int.Parse(Console.ReadLine());
                }
                catch (Exception) { }
            }

            return result.Value;
        }

        private static void AddAnEvent()
        {
            Console.WriteLine($"number: {GetNumber()}");
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

        private static void DisplayMenu()
        {
            Console.WriteLine($"1  >  Add an event");
            Console.WriteLine($"2  >  Update an event");
            Console.WriteLine($"3  >  Delete an event");
            Console.WriteLine();
            Console.WriteLine($"4  >  Book tickets");
            Console.WriteLine($"5  >  Remove a booking");
            Console.WriteLine();
            Console.WriteLine($"6  >  View all events");
            Console.WriteLine($"7  >  View transaction log");
            Console.WriteLine();
            Console.WriteLine($"8  >  Exit");

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
                    else { DisplayMessage(msg: "Please enter a number between 1 and 7"); }
                }
                catch (OverflowException) { DisplayMessage(msg: "Too many characters", isError: true, colorAfter: ConsoleColor.Gray); }
                catch (FormatException) { DisplayMessage(msg: "Please enter a number", isError: true, colorAfter: ConsoleColor.Gray); }
                catch (Exception) { DisplayMessage(msg: "Please enter a number", isError: true, colorAfter: ConsoleColor.Gray); }
            }

            return res.Value;
        }
        
        private static void DisplayMessage(string msg, ConsoleColor colorAfter = ConsoleColor.Gray, 
            bool isError = false, bool isWarning = false, bool hasNewLine = true)
        {
            ConsoleColor color;
            string message;

            if (isError)
            {
                color = ConsoleColor.Red;
                message = $"ERROR: {msg}";
            }
            else if (isWarning)
            {
                color = ConsoleColor.DarkYellow;
                message = $"Warning! {msg}";
            }
            else
            {
                color = ConsoleColor.Gray;
                message = msg;
            }

            Console.ForegroundColor = color;
            Console.Write(message + (hasNewLine ? Environment.NewLine : null));
            Console.ForegroundColor = colorAfter;
        }
    }
}
