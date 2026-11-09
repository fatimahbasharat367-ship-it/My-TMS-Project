using System.Collections.Generic;
using System.IO;

namespace TourismManagementSystem.Tourists;
public class TouristRepository
{

    private readonly string _filePath = "data.txt";
    public void SaveAll(List<Tourist> tourists)
    {
        using (StreamWriter writer = new StreamWriter(_filePath, false))
        {
            foreach (Tourist tourist in tourists)
            {
                writer.WriteLine(tourist.ToString());
            }
        }
    }
    public List<Tourist> GetAll()
    {
        if (!File.Exists(_filePath))
        {
            return TouristRepository.getDefaultTourists();
        }

        List<Tourist> tourists = new List<Tourist>();
        string[] lines = File.ReadAllLines(_filePath);
        foreach (string line in lines)
        {
            if (line.Trim().Length == 0)
            {
                continue;
            }
            string[] parts = line.Split('|');
            if (parts.Length != 8)
            {
                continue;
            }
            Tourist tourist = new Tourist(parts[0], int.Parse(parts[1]), parts[2], int.Parse(parts[3]),
                int.Parse(parts[4]), parts[5], int.Parse(parts[6]), parts[7]);
            tourists.Add(tourist);
        }
        return tourists;
    }

    public static List<Tourist> getDefaultTourists()
    {
        List<Tourist> list = new List<Tourist>();
        list.Add(new Tourist("Ayesha", 25, "Chitral", 15000, 3, "4days", 5, "03436577865"));
        list.Add(new Tourist("Fatimah", 27, "Hunza", 20000, 5, "5days", 4, "09876598765"));
        list.Add(new Tourist("Dua", 19, "Kartarpur", 12000, 2, "2days", 3, "098765439876"));
        list.Add(new Tourist("Alishba", 23, "Sawat", 10000, 1, "3days", 4, "9876543234567"));
        list.Add(new Tourist("Zainab", 32, "Kashmir", 17000, 4, "7days", 5, "0987654876543"));
        return list;
    }
}
