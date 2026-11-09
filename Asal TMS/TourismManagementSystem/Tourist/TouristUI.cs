using System;

namespace TourismManagementSystem.Tourists;
public class TouristUI
{
    private readonly TouristService _touristService;

    public TouristUI()
    {
        _touristService = new TouristService();
    }
    public Tourist ReadTourist()
    {
        Console.Clear();
        Console.WriteLine("Welcome to Tourist Portal");

        Console.Write("Enter your name: ");
        string name = ConsoleHelper.ReadText();
        int age = ConsoleHelper.ReadNumber("Enter your age: ");
        Console.WriteLine();

        Console.Write("Enter your phone number: ");
        string phone = ConsoleHelper.ReadText();

        Tourist tourist = _touristService.CreateTourist(name, age, phone);
        if (tourist == null)
        {
            Console.WriteLine("Booking failed: " + _touristService.getLastError());
            ConsoleHelper.WaitForKey();
        }
        return tourist;
    }
}
