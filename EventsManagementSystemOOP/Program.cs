using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsManagementSystemOOP
{
    class Program
    {
        private const int ADD_EVENT = 1;
        private const int UPDATE_EVENT = 2;
        private const int DELETE_EVENT = 3;

        private const int BOOK_TICKETS = 4;
        private const int CANCEL_BOOKING = 5;

        private const int DISPLAY_EVENTS = 6;
        private const int DISPLAY_TRANSACTIONS = 7;

        private const int EXIT = 8;

        private static void Main(string[] args)
        {
            const char YES = 'y';
            const char NO = 'n';
            char choice = 'y';

            //Event e = new Event("Staffs Hackathon", 124, 12.98)
            //{
            //    DateAdded = new DateTime(2019, 5, 6, 15, 26, 30)
            //};
            //Log l = new Log(new Log.LogDetails(e, Log.LogDetails.TransType.Add))
            //{
            //    DateOfTransaction = e.DateAdded
            //};

            //Booking[] books = e.Bookings.Values.ToArray();

            //int placesToAdd = 124;

            //int placesLeft = e.NumberOfTicketsLeft;
            //int places = e.NumberOfTicketsOverall;
            //double oldPrice = e.PricePerTicket;

            //Event.DeleteEvent(e.Id);

            //e = new Event("Hackathon", placesToAdd + places, 13.98) { Id = e.Id, DateAdded = e.DateAdded, DateUpdated = DateTime.Now };
            ////e.NumberOfTicketsLeft -= placesLeft + placesToAdd;

            //foreach (Booking b in books)
            //{
            //    b.Price = oldPrice;

            //    e.AddBooking(b);

            //    e.NumberOfTicketsLeft -= b.NumberOfTickets;
            //}

            //Log l2 = (new Log(new Log.LogDetails(ob: e, type: Log.LogDetails.TransType.Update)));



            //e.AddBooking(new Booking(new Booking.Customer("Steve", "Staffs Uni, Stoke, ST4"), 124));
            //e.NumberOfTicketsLeft -= 124;
            //Log l3 = new Log(new Log.LogDetails(Event.GetEvent(1).Bookings[1], Log.LogDetails.TransType.Book))
            //{
            //    DateOfTransaction = e.DateAdded.AddSeconds(29)
            //};

            while (choice == YES)
            {
                Menu();

                Console.Clear();

                char response = ' ';

                while (response != 'n' && response != 'y')
                {
                    DisplayMessage("Are you sure you want to exit, changes will not be saved? (y/n) ", isWarning: true, hasNewLine: false);

                    try
                    {
                        response = char.Parse(Console.ReadLine().ToLower());
                        if (response == YES) choice = NO;
                    }
                    catch (Exception)
                    {
                        DisplayMessage("Please enter 'y' or 'n'", isError: true, hasNewLine: true);
                    }
                }
            }

            Environment.Exit(0);
        }

        private static int GetCode(string str)
        {
            int? result = null;

            do
            {
                try
                {
                    DisplayMessage(msg: str + " code: ", hasNewLine: false);
                    result = int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    DisplayMessage(msg: "Please enter a valid number", isError: true);
                }
            }
            while (!result.HasValue);

            return result.Value;
        }

        private static int GetNumber(string str, int min = 0)
        {
            int? result = null;

            bool dataOK = false;

            do
            {
                try
                {
                    bool exp;

                    do
                    {

                        DisplayMessage(msg: str, hasNewLine: false);
                        result = int.Parse(Console.ReadLine());

                        exp = result.Value < min;

                        if (exp)
                        {
                            DisplayMessage(msg: $"Please enter a valid number of {min}+", isError: true);
                        }
                    } while (exp);

                    dataOK = true;
                }
                catch (Exception)
                {
                    DisplayMessage(msg: "Please enter a valid number", isError: true);
                }
            }
            while (!dataOK);

            return result.Value;
        }

        private static double GetPrice()
        {
            double result = -.1;
            bool dataOK = false;

            do
            {
                try
                {
                    DisplayMessage(msg: "Enter a price: £", hasNewLine: false);
                    result = double.Parse(Console.ReadLine());

                    if (result < 0)
                    {
                        DisplayMessage(msg: "Please enter a valid positive number", isError: true);
                    }
                    else
                    { dataOK = true; }
                }
                catch (Exception)
                {
                    DisplayMessage(msg: "Please enter a valid number", isError: true);
                }
            } while (!dataOK);

            return result;
        }

        private static string GetName(string str)
        {
            string result = "";
            bool dataOK = false;

            while (!dataOK)
            {
                DisplayMessage($"{str} name: ", hasNewLine: false);
                result = Console.ReadLine();

                if (result == "")
                    DisplayMessage($"Name must not be empty", isError: true);
                else if (result.Length < 5 || result.Length > 50)
                {
                    DisplayMessage($"Name must be between 5 and 50 characters long", isError: true);
                }
                else { dataOK = true; }
            }

            return result;
        }

        private static void AddAnEvent()
        {
            string name = GetName("Event");
            int places = GetNumber(str: "Number of tickets: ", min: 1);
            double price = GetPrice();

            Event e = new Event(name: name, pricePerTicket: price, numOfPlaces: places);

            //Events.Add(e);

            Log log = new Log(new Log.LogDetails(ob: e, type: Log.LogDetails.TransType.Add));
        }

        private static void UpdateAnEvent()
        {
            Event e = Event.GetEvent(GetCode("Event"));

            if (e != null)
            {
                string name = GetName("Event");
                int placesToAdd = GetNumber(str: "Number of tickets to add: ", min: 0);
                double price = GetPrice();

                Booking[] books = e.Bookings.Values.ToArray();

                int placesLeft = e.NumberOfTicketsLeft;
                int places = e.NumberOfTicketsOverall;
                double oldPrice = e.PricePerTicket;

                Event.DeleteEvent(e.Id);

                e = new Event(name, placesToAdd + places, price) { Id = e.Id, DateAdded = e.DateAdded, DateUpdated = DateTime.Now };
                //e.NumberOfTicketsLeft = placesLeft + placesToAdd;

                foreach (Booking b in books)
                {
                    b.Price = oldPrice;
                    e.AddBooking(b);
                    e.NumberOfTicketsLeft -= b.NumberOfTickets;
                }

                Log l = (new Log(new Log.LogDetails(ob: e, type: Log.LogDetails.TransType.Update)));
            }
            else
            {
                DisplayMessage(msg: "An event doesn't exist with that event code", isError: true);
            }
        }

        private static void DeleteAnEvent()
        {
            int code = GetCode("Event");

            Event e = Event.GetEvent(code: code);

            if (Event.DeleteEvent(code))
            {
                Log l = (new Log(new Log.LogDetails(ob: e, type: Log.LogDetails.TransType.Delete)));
            }
            else
            {
                DisplayMessage(msg: "Event doesn't exist with that event code", isError: true);
            }
        }

        private static void BookTickets()
        {
            Event e = Event.GetEvent(GetCode("Event"));

            if (e != null)
            {
                string cName = GetName("Customer");

                string cAddress = "";

                while (cAddress.Length < 9)
                {
                    DisplayMessage(msg: "Customer Address: ", hasNewLine: false);
                    cAddress = Console.ReadLine();

                    if (cAddress.Length < 9)
                    {
                        DisplayMessage(msg: $"Address must be longer than {8}", isError: true);
                    }
                }


                int tickets = GetNumber(str: "Number of tickets: ", min: 1);

                if (e.NumberOfTicketsLeft - tickets >= 0)
                {
                    Booking b = new Booking(new Booking.Customer(cName, cAddress), tickets);

                    if (e.AddBooking(b))
                    {
                        DisplayMessage(msg: $"\tBooking code: {b.Id}\n\tPrice: {b.Price:c}");

                        e.NumberOfTicketsLeft -= tickets;

                        Log l = new Log(new Log.LogDetails(ob: b, type: Log.LogDetails.TransType.Book));
                    }
                    else
                    {
                        DisplayMessage(msg: "The event wasn't successfully processed", isError: true);
                    }
                }
                else
                {
                    DisplayMessage(msg: "The event doesn't have enough tickets available", isError: true);
                }
            }
            else
            {
                DisplayMessage(msg: "Event doesn't exist with that event code", isError: true);
            }
        }

        private static void CancelBooking()
        {
            int id = GetCode("Booking");
            Event e = null;

            foreach (Event ev in Event.Events.Values)
            {
                if (ev.Bookings.ContainsKey(id)) e = ev;
            }

            if (e != null)
            {
                e.Bookings.TryGetValue(id, out Booking b);

                if (e.RemoveBooking(b))
                {
                    e.NumberOfTicketsLeft += b.NumberOfTickets;

                    DisplayMessage(msg: "\tBooking successfully removed");

                    Log l = (new Log(new Log.LogDetails(ob: b, type: Log.LogDetails.TransType.Cancel)));
                }
                else
                {
                    DisplayMessage(msg: "Booking wasn't successfully removed", isError: true);
                }
            }
            else
            {
                DisplayMessage(msg: "No event was found to have a booking with that code", isError: true);
            }
        }

        private static void DisplayAllEvents()
        {
            Console.Clear();

            Console.WriteLine("Events (" + Event._TotalNumberOfEvents + ")");

            if (Event._TotalNumberOfEvents > 0)
                for (int i = 0; i < Event._TotalNumberOfEvents; i++)
                {
                    Event e = Event.Events.Values.ToArray()[i];

                    Console.WriteLine("\tId:      " + e.Id);
                    Console.WriteLine("\tName:    " + e.Name);
                    Console.WriteLine($"\tTickets: {e.NumberOfTicketsLeft}/{e.NumberOfTicketsOverall} left");
                    Console.WriteLine("\tPrice:   {0:c}", e.PricePerTicket);
                    Console.WriteLine("\tAdded:   " + e.DateAdded.ToString("dd/MM/yyyy (HH:mm)"));

                    Console.WriteLine();
                    if (e.Bookings.Count == 0)
                    {
                        Console.WriteLine("\tNo Bookings");
                        Console.WriteLine("\n");
                    }
                    else
                    {
                        Console.WriteLine("\tBookings: (" + e.Bookings.Count + ")");
                        for (int j = 0; j < e.Bookings.Count; j++)
                        {
                            Booking b = e.Bookings.Values.ToArray()[j];
                            Console.WriteLine("\t\tId:      " + b.Id);
                            Console.WriteLine("\t\tName:    " + b.CustomerDetails.Name);
                            Console.WriteLine("\t\tAddress: " + b.CustomerDetails.Address);
                            Console.WriteLine("\t\tTickets: " + b.NumberOfTickets);
                            Console.WriteLine("\t\tPrice:   {0:c}", b.Price);
                            Console.WriteLine("\n");
                        }
                    }
                }
            else
                Console.WriteLine("\tThere are no events");
        }

        private static void DisplayAllTransactions()
        {
            Console.Clear();

            List<Log> trans = new List<Log>(Log.TransactionLog);

            if (trans.Count > 0)
            {
                Console.WriteLine("Transactions ({0:d})", trans.Count);

                for (int i = 0; i < trans.Count; i++)
                {
                    Log t = trans[i];

                    Console.WriteLine($"\tDate:\t{t.DateOfTransaction}");
                    Console.WriteLine($"\tType:\t{t.Details.type}");

                    Log.LogDetails d = t.Details;

                    switch (t.Details.type)
                    {
                        case Log.LogDetails.TransType.Add:
                            Console.WriteLine($"\t\tCode:       " + d.ev.Id);
                            Console.WriteLine($"\t\tName:       " + d.ev.Name);
                            Console.WriteLine($"\t\tTickets:    {d.ev.NumberOfTicketsLeft} / {d.ev.NumberOfTicketsOverall} left");
                            Console.WriteLine("\t\tPrice:      {0:c}", d.ev.PricePerTicket);
                            Console.WriteLine($"\t\tDate added: " + d.ev.DateAdded.ToString("dd/mm/yyyy"));
                            break;
                        case Log.LogDetails.TransType.Update:
                            Console.WriteLine($"\t\tCode:         " + d.ev.Id);
                            Console.WriteLine($"\t\tName:         " + d.ev.Name);
                            Console.WriteLine($"\t\tTickets:      {d.ev.NumberOfTicketsLeft} / {d.ev.NumberOfTicketsOverall} left");
                            Console.WriteLine("\t\tPrice:        {0:c}", d.ev.PricePerTicket);
                            Console.WriteLine($"\t\tDate added:   " + d.ev.DateAdded.ToString("dd/MM/yyyy (HH:mm)"));
                            Console.WriteLine($"\t\tDate updated: " + d.ev.DateUpdated.ToString("dd/MM/yyyy (HH:mm)"));
                            break;
                        case Log.LogDetails.TransType.Delete:
                            Console.WriteLine("\t\tCode: " + d.ev.Id);
                            break;
                        case Log.LogDetails.TransType.Book:
                            Console.WriteLine("\t\tEvent Code: " + d.b.Event.Id);
                            Console.WriteLine("\t\tBooking Code: " + d.b.Id);
                            Console.WriteLine("\t\tNum tickets: " + d.b.NumberOfTickets);
                            break;
                        case Log.LogDetails.TransType.Cancel:
                            Console.WriteLine("\t\tBooking Code: " + d.b.Id);
                            Console.WriteLine("\t\tTickets:  " + d.b.NumberOfTickets);
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

        private static void Menu()
        {
            int num;

            do
            {
                Console.Clear();

                Console.ForegroundColor = ConsoleColor.Gray;
                num = MenuResponse();

                Console.WriteLine();

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
                    case DISPLAY_EVENTS:
                        DisplayAllEvents();
                        break;
                    case DISPLAY_TRANSACTIONS:
                        DisplayAllTransactions();
                        break;
                }

                if (num != EXIT)
                {
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                }
            } while (num != EXIT);
        }

        private static void DisplayMenu()
        {
            Console.WriteLine($"1\t- Add an event");
            Console.WriteLine($"2\t- Update an event");
            Console.WriteLine($"3\t- Delete an event");
            Console.WriteLine();
            Console.WriteLine($"4\t- Book tickets");
            Console.WriteLine($"5\t- Remove a booking");
            Console.WriteLine();
            Console.WriteLine($"6\t- View all events");
            Console.WriteLine($"7\t- View transaction log");
            Console.WriteLine();
            Console.WriteLine($"8\t- Exit");

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
                    else { DisplayMessage(msg: "Please enter a number between 1 and " + EXIT); }
                }
                catch (OverflowException) { DisplayMessage(msg: "Too many characters", isError: true, colorAfter: ConsoleColor.Gray); }
                catch (FormatException) { DisplayMessage(msg: "Please enter a number", isError: true, colorAfter: ConsoleColor.Gray); }
                catch (Exception) { DisplayMessage(msg: "Please enter a number", isError: true, colorAfter: ConsoleColor.Gray); }
            }

            return res.Value;
        }
    }
}
