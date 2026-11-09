using System.Collections.Generic;

namespace TourismManagementSystem.Tourists;

public class TouristService
{
    private readonly TouristRepository _touristRepository;
    private string _lastError;  

    public TouristService()
    {
        _touristRepository = new TouristRepository();
        _lastError = "";
    }

    public string getLastError()
    {
        return _lastError;
    }
    public Tourist CreateTourist(string name, int age, string phone)
    {
        _lastError = "";
        Tourist tourist = new Tourist();
        if (!tourist.setName(name))
        {
            _lastError = "The name must have 1 to 30 characters and must not contain '|'.";
            return null;
        }
        if (!tourist.setAge(age))
        {
            _lastError = "The age must be between 1 and 120.";
            return null;
        }
        if (!tourist.setPhone(phone))
        {
            _lastError = "The number must have 1 t0 15 characters. ";
            return null;
        }
        return tourist;
    }

    public bool BookingExists(string name, string spot)
    {
        List<Tourist> tourists = _touristRepository.GetAll();

        foreach (Tourist t in tourists)
        {
            if (t.getName().ToLower() == name.ToLower() && t.getSpot().ToLower() == spot.ToLower())
            {
                return true;
            }
        }

        return false;
    }

    public void AddTourist(Tourist tourist)
    {
        List<Tourist> tourists = _touristRepository.GetAll();
        tourists.Add(tourist);
        _touristRepository.SaveAll(tourists);
    }
}
