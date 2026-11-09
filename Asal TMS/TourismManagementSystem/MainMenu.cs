using System;
using TourismManagementSystem.Admin;
using TourismManagementSystem.Bookings;
using TourismManagementSystem.Tourists;

namespace TourismManagementSystem;
public class MainMenu
{
    private readonly AdminUI _adminUI;
    private readonly TouristUI _touristUI;
    private readonly BookingUI _bookingUI;

    public MainMenu()
    {
        _adminUI = new AdminUI();
        _touristUI = new TouristUI();
        _bookingUI = new BookingUI();
    }

    public void Show()
    {  

        bool keepRunning = true;
        while (keepRunning)
        {
            Header();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("~ User Menu ~");
            Console.WriteLine("1- Admin");
            Console.WriteLine("2- Tourist");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("3- Exit");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Choose option: ");
            string userOption = ConsoleHelper.ReadText();

            if (userOption == "1")
            {
                _adminUI.ShowAdminLogin();
            }
            else if (userOption == "2")
            {
                Tourist tourist = _touristUI.ReadTourist();
                if (tourist != null)
                {
                    _bookingUI.ShowBooking(tourist);
                }
            }
            else if (userOption == "3")
            {
                keepRunning = false;
            }
            else
            {
                Console.WriteLine("Wrong Option.");
                ConsoleHelper.WaitForKey();
            }
        }
        Console.WriteLine("Thanks for visiting TMS");
    }

    private void Header()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine();
        Console.WriteLine("================================================================");
        Console.WriteLine("||                THE ADVENTURER'S COMPASS                    ||");
        Console.WriteLine("||          - Life is  all  about  the adventures -           ||");
        Console.WriteLine("================================================================");
    }
}
