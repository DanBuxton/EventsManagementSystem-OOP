# Submission for Application Modelling module (2018/19)
Module code | When | Module total
-- | - | -
COSE40574 | Semester 1, Year 1 | 81.625%

## Future Development
1. Store data in a **database** instead of multiple files
1. Create **seperate applications** for the admin and user instead of a single application
1. Implement **Software Engineering Principles** because the code stinks!

## Scenario
A company wants a computer system for managing events. Events can be added, updated and deleted. Users can book tickets for an event and cancel the bookings.
Each operation is recorded in a transaction log.
The computer system is to provide the following operations:
Operation | Information
-- | -
Add event | Read event code, name, number of tickets available, price per ticket, and date added. Store the data in an appropriate datastructure and make an entry into the transaction log.
Update event | Read event code, new name, new number of tickets available, new price per ticket, and date of update. If the event exists, modify the details and make an entry into the transaction log.
Delete event | Read event code. If the event exists, delete the event from the data structure and make an entry in the transaction log.
Book tickets | Read the event code, customer name and address, number of tickets to buy. If the event exists and there are enough tickets available, update the number of available tickets for the event; Add the booking details to a bookings data structure; Output the booking code, and total price of the booked tickets and make an entry in the transaction log.
Cancel booking | Read the booking code. If the booking exists, update the number of available tickets for the event; Delete the booking and make an entry in the transaction log.
Display list of events | Output the details of all events, including all bookings for each event.
Display transaction log | Output the list of all transaction log entries. Each record should show: Date of transaction; Type of transaction; Add (show event details); Update (show updated event details); Delete (show event code); Book (show event code, booking code, num. tickets); Cancel (show booking code, num. tickets)

## Assignment 1 (Procedural)
[View details](http://github.com/DanBuxton/EventsManagementSystem)

## Assignment 2 (Object-oriented)
### The Task
#### Part 1
Using MS Visio, follow the USDP to develop an object-oriented model (using UML) for the computerised system described above.

#### Part 2
Implement your model using the C# programming language. Ensure that your implementation is object-oriented.

### Mark Scheme
#### Part 2
Criterion | Mark
-- | -
Test plan (20%) | 13
Add event (10%) | 10
Update event (10%) | 6.5
Delete event (10%) | 6.5
Book tickets (15%) | 9.75
Cancel booking (10%) | 10
Display all events (10%) | 10
Display transaction log (15%) | 15
**Total** | **80.75**
