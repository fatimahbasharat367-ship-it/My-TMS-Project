using System.Collections.Generic;

namespace TourismManagementSystem.Bookings;
public class PackageRepository
{
    public List<Package> GetAll()
    {
        List<Package> packages = new List<Package>();
        packages.Add(new Package("Chitral", 15000, "4days", 5, "Hunting"));
        packages.Add(new Package("Hunza", 20000, "5days", 4, "Boating"));
        packages.Add(new Package("Kartarpur", 12000, "2days", 3, "History_walk"));
        packages.Add(new Package("Sawat", 10000, "3days", 4, "Hiking"));
        packages.Add(new Package("Kashmir", 17000, "7days", 5, "Sightseeing"));
        return packages;
    }
}

