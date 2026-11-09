using System.Collections.Generic;
using TourismManagementSystem.Bookings;
using TourismManagementSystem.Tourists;

namespace TourismManagementSystem.Admin;
public class AdminService
{
    private readonly AdminRepository _adminRepository;
    private readonly TouristRepository _touristRepository;
    private readonly PackageRepository _packageRepository;

    public AdminService()
    {
        _adminRepository = new AdminRepository();
        _touristRepository = new TouristRepository();
        _packageRepository = new PackageRepository();
    }
    public bool AdminLogin(string username, string password)
    {
        AdminAccount admin = _adminRepository.GetAdmin();
        return admin.checkLogin(username, password);
    }
    public List<Tourist> GetTourists()
    {
        return _touristRepository.GetAll();
    }
    public List<Package> GetPackages()
    {
        return _packageRepository.GetAll();
    }
    public Tourist SearchTourist(string name)
    {
        List<Tourist> tourists = _touristRepository.GetAll();
        return FindTourist(tourists, name);
    }
    public string UpdateTourist(string oldName, string newName, int newAge, string newSpot, int newPrice, string newDuration)
    {
        List<Tourist> tourists = _touristRepository.GetAll();
        Tourist tourist = FindTourist(tourists, oldName);
        if (tourist == null)
        {
            return "Record not found.";
        }

        Tourist check = new Tourist();
        if (!check.setName(newName))
        {
            return "The name must have 1 to 30 characters and must not contain '|'.";
        }
        if (!check.setAge(newAge))
        {
            return "The age must be between 1 and 120.";
        }
        if (!check.setSpot(newSpot))
        {
            return "The spot must have 1 to 30 characters and must not contain '|'.";
        }
        if (!check.setPrice(newPrice))
        {
            return "The price cannot be negative.";
        }
        if (!check.setDuration(newDuration))
        {
            return "The duration must have 1 to 30 characters and must not contain '|'.";
        }

        tourist.setName(newName);
        tourist.setAge(newAge);
        tourist.setSpot(newSpot);
        tourist.setPrice(newPrice);
        tourist.setDuration(newDuration);
        _touristRepository.SaveAll(tourists);
        return "";
    }
    public bool DeleteTourist(string name)
    {
        List<Tourist> tourists = _touristRepository.GetAll();
        Tourist tourist = FindTourist(tourists, name);
        if (tourist == null)
        {
            return false;
        }
        tourists.Remove(tourist);
        _touristRepository.SaveAll(tourists);
        return true;
    }
    public List<Tourist> SortByRating()
    {
        List<Tourist> tourists = _touristRepository.GetAll();
        for (int i = 0; i < tourists.Count - 1; i++)
        {
            for (int j = 0; j < tourists.Count - i - 1; j++)
            {
                if (tourists[j].getRating() < tourists[j + 1].getRating())
                {
                    Tourist temp = tourists[j];
                    tourists[j] = tourists[j + 1];
                    tourists[j + 1] = temp;
                }
            }
        }
        _touristRepository.SaveAll(tourists);
        return tourists;
    }

    public List<Tourist> SortByPrice()
    {
        List<Tourist> tourists = _touristRepository.GetAll();
        for (int i = 0; i < tourists.Count - 1; i++)
        {
            for (int j = 0; j < tourists.Count - i - 1; j++)
            {
                if (tourists[j].getPrice() < tourists[j + 1].getPrice())
                {
                    Tourist temp = tourists[j];
                    tourists[j] = tourists[j + 1];
                    tourists[j + 1] = temp;
                }
            }
        }
        _touristRepository.SaveAll(tourists);
        return tourists;
    }

    public List<Tourist> GetTouristsBySpot(string spot)
    {
        List<Tourist> tourists = _touristRepository.GetAll();
        List<Tourist> found = new List<Tourist>();

        foreach (Tourist tourist in tourists)
        {
            if (tourist.getSpot().ToLower() == spot.ToLower())
            {
                found.Add(tourist);
            }
        }

        return found;
    }

    public List<Tourist> FilterTourists(int minAge, int maxAge, string nameKeyword, string spotFilter)
    {
        List<Tourist> tourists = _touristRepository.GetAll();
        List<Tourist> filteredList = new List<Tourist>();

        foreach (Tourist tourist in tourists)
        {
    
            bool isAgeValid = (tourist.getAge() >= minAge && tourist.getAge() <= maxAge);

            bool isNameValid = tourist.getName().ToLower().Contains(nameKeyword.ToLower());

            bool isSpotValid = tourist.getSpot().ToLower() == spotFilter.ToLower();

            if (isAgeValid && isNameValid && isSpotValid)
            {
                filteredList.Add(tourist);
            }
        }

        return filteredList;
    }

    public int TotalRevenue()
    {
        List<Tourist> touriosts = _touristRepository.GetAll();
        int total = 0;
        foreach (Tourist tourist in touriosts)
        {
            total = total + tourist.getPrice();
        }
        return total;
    }

    private Tourist FindTourist(List<Tourist> tourists, string name)
    {
        for (int i = 0; i < tourists.Count; i++)
        {
            if (tourists[i].getName().ToLower() == name.ToLower())
            {
                return tourists[i];
            }
        }
        return null;
    }
}

