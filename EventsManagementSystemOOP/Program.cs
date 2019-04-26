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

        private const int DISPLAY_EVENTS = 6;
        private const int DISPLAY_TRANSACTIONS = 7;

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
                        Console.WriteLine(Events[0]);
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
                    case DISPLAY_EVENTS:
                        DisplayAllEvents();
                        break;
                    case DISPLAY_TRANSACTIONS:
                        DisplayAllTransactions();
                        break;
                    case EXIT:
                        DisplayMessage("Are you sure you want to exit, changes will not be saved? (y/n) ", isWarning: true, hasNewLine: false);
                        char response = Console.ReadLine()[0];
                        if (response.ToString().ToLower() == "n") num = 0;
                        break;
                }
            } while (num != EXIT);

            Environment.Exit(0);
        }

        private static int GetNumber(int min = 1, int max = 9999)
        {
            int? result = null;

            do
            {
                try
                {
                    Console.Write($"Enter a number between {min} and {max}: ");
                    result = int.Parse(Console.ReadLine());
                }
                catch (Exception) { }
            }
            while (result < min && result > max);

            return result.Value;
        }

        public static string GetName(string str)
        {
            DisplayMessage($"{str} name: ", hasNewLine: false);

            return Console.ReadLine();
        }

        private static void AddAnEvent()
        {
            Event e = new Event(name: GetName("Event"), pricePerTicket: 5.99, numOfPlaces: GetNumber());

            Events.Add(e);

            TransactionLog.Add(new Log(new Log.LogDetails(ob: e, type: Log.LogDetails.TransType.Add)));
        }

        private static void UpdateAnEvent()
        {

        }

        private static void DeleteAnEvent()
        {

        }

        private static Event GetEvent(int code)
        {
            //return Events.Where(e => e.Code == code).ToArray()[0];

            /**/
            Event e = null;

            int min = 1;
            int max = Events.Count - 1;
            int mid = (min + max) / 2;

            while (1 <= Events.Count && e == null)
            {
                mid = (min + max) / 2;

                if (code == Events[mid].Id)
                {
                    e = Events[mid];
                }
                else if (code < Events[mid].Id)
                {
                    max = mid - 1;
                }
                else
                {
                    min = mid + 1;
                }
            }

            return e;/**/
        }

        private static void BookTickets()
        {
            int id = GetNumber();
        }

        private static void CancelBooking()
        {

        }

        private static void DisplayAllEvents()
        {
            Console.WriteLine("All Events");

            for (int i = 0; i < Event._TotalNumberOfEvents; i++)
            {
                Event e = Events[i];

                Console.WriteLine("\t");


                for (int j = 0; j < e.Bookings.Count; j++)
                {

                }
            }
        }

        private static void DisplayAllTransactions()
        {

        }

        /*
        public static void DisplayAllEvents()
        {
            if (Events.Count > 0)
            {
                Console.WriteLine("Event(s):");

                for (int i = 0; i < Events.Count; i++)
                {
                    Event e = Events[i];
                    Booking[] bookings = e.Bookings.Values.ToArray();

                    Console.WriteLine("\t" + e);

                    Console.WriteLine();

                    if ((bookings != null) && (bookings.Length > 0))
                    {
                        Console.WriteLine($"\t\tBookings: ({bookings.Length})");

                        for (int b = 0; b < bookings.Length; b++)
                        {
                            Console.WriteLine();

                            Console.Write("\t\t\tRef: " + bookings[b].Code + Environment.NewLine);
                            Console.Write("\t\t\tCustomer name: " + bookings[b].CustomerName + Environment.NewLine);
                            Console.Write("\t\t\tAddress: " + bookings[b].CustomerAddress + Environment.NewLine);
                            Console.Write("\t\t\tNumber of tickets: " + bookings[b].NumberOfTicketsToBuy + Environment.NewLine);
                            Console.Write("\t\t\tPrice: {0:c}" + Environment.NewLine, bookings[b].TotalPriceOfTickets);
                            if (b < bookings.Length - 1)
                            {
                                Console.WriteLine("");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("\t\tNo bookings");
                    }

                    Console.WriteLine("");
                }
            }
            else
            {
                Console.WriteLine("No events");
            }
        }
        /**/

        /**/
        public static void DisplayTransactions()
        {
            if (TransactionLog.Count > 0)
            {
                Console.WriteLine("Transactions ({0:d})", TransactionLog.Count);

                for (int i = 0; i < TransactionLog.Count; i++)
                {
                    Log t = TransactionLog[i];

                    Console.WriteLine($"\tDate:\t{t.DateOfTransaction}");
                    Console.WriteLine($"\tType:\t{t.Details.type}");

                    switch (t.Details.type)
                    {
                        case Log.LogDetails.TransType.Add:
                            Console.WriteLine("\t" + t.Details + ";");
                            break;
                        case Log.LogDetails.TransType.Update:
                            Console.WriteLine("\t" + t.Details + ";");
                            break;
                        case Log.LogDetails.TransType.Delete:
                            Console.WriteLine("\t" + t.Details + ";");
                            break;
                        case Log.LogDetails.TransType.Book:
                            Console.WriteLine("\t" + t.Details + ";");
                            break;
                        case Log.LogDetails.TransType.Cancel:
                            Console.WriteLine("\t\t" + t.Details + ";");
                            break;
                    }
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("No transactions currently");
            }
        }
        /**/

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
