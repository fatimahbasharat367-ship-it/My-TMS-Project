using System;
using System.Collections.Generic;
using TourismManagementSystem.Tourists;

namespace TourismManagementSystem.Bookings;
public class BookingUI
{
    private readonly BookingService _bookingService;

    public BookingUI()
    {
        _bookingService = new BookingService();
    }
    public void ShowBooking(Tourist tourist)
    {
        Console.WriteLine("------ Available Spots ------");
        List<Package> packages = _bookingService.GetPackages();
        for (int i = 0; i < packages.Count; i++)
        {
            Console.WriteLine((i + 1) + ". " + packages[i].getSpot() + " (Rs." + packages[i].getPrice()
                + ") Rating: " + packages[i].getRating() + "/5");
        }

        Console.Write("Enter spot name from list: ");
        string spot = ConsoleHelper.ReadText();

        Package package = _bookingService.FindPackage(spot);
        if (package == null)
        {
            Console.WriteLine("Spot not available.");
        }
        else
        {
            int persons = ConsoleHelper.ReadNumber("How many individuals are joining you in this trip ? ");

            if (!_bookingService.BookTrip(tourist, spot, persons))
            {
                Console.WriteLine("Booking failed: " + _bookingService.getLastError());
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Booking Successful!");
                Console.WriteLine("------------ Receipt ------------");
                Console.WriteLine("Name: " + tourist.getName());
                Console.WriteLine("Destination: " + tourist.getSpot());
                Console.WriteLine("Persons: " + tourist.getPersons());
                Console.WriteLine("Duration: " + tourist.getDuration());
                Console.WriteLine("Total Bill: Rs." + tourist.getPrice());
                if (_bookingService.GetsDiscount(tourist.getPersons()))
                {
                    Console.WriteLine("Group Discount : 10% Applied ");
                }
                Console.WriteLine("Activity: " + package.getActivity());
                Console.WriteLine("---------------------------------");
            }
        }
        ConsoleHelper.WaitForKey();
    }
}
