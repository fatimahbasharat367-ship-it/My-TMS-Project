using System.Collections.Generic;
using TourismManagementSystem.Tourists;

namespace TourismManagementSystem.Bookings;
public class BookingService
{
    private readonly PackageRepository _packageRepository;
    private readonly TouristService _touristService;
    private string _lastError;  

    public BookingService()
    {
        _packageRepository = new PackageRepository();
        _touristService = new TouristService();
        _lastError = "";
    }

    public bool GetsDiscount(int persons)
    {
        return persons >= 5;
    }

    public string getLastError()
    {
        return _lastError;
    }


    public List<Package> GetPackages()
    {
        return _packageRepository.GetAll();
    }
    public Package FindPackage(string spot)
    {
        List<Package> packages = _packageRepository.GetAll();
        for (int i = 0; i < packages.Count; i++)
        {
            if (packages[i].getSpot() == spot)
            {
                return packages[i];
            }
        }
        return null;
    }


  public bool BookTrip(Tourist tourist, string spotName, int persons)
    {
        _lastError = "";
        Package package = FindPackage(spotName);
        if (package == null)
        {
            _lastError = "Spot not available.";
            return false;
        }
        if (_touristService.BookingExists(tourist.getName(), package.getSpot()))
        {
            _lastError = "This tourist has already booked this spot.";
            return false;
        }
        if (!tourist.setPersons(persons))
        {
            _lastError = "At least one person must join the trip.";
            return false;
        }
        tourist.setSpot(package.getSpot());
        tourist.setPrice(package.getPrice() * persons);
        int total = package.getPrice() * persons;

        if (GetsDiscount(persons))
        {
            total = total - total / 10;
        }

        tourist.setPrice(total);
        tourist.setDuration(package.getDuration());
        tourist.setRating(package.getRating());

        _touristService.AddTourist(tourist);
        return true;
    }
}
