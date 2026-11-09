namespace TourismManagementSystem.Bookings;
public class Package
{
    private string spot;
    private int price;
    private string duration;
    private int rating;
    private string activity;
    public Package(string spot, int price, string duration, int rating, string activity)
    {
        this.spot = spot;
        this.price = price;
        this.duration = duration;
        this.rating = rating;
        this.activity = activity;
    }

    public string getSpot()
    {
        return spot;
    }
    public int getPrice()
    {
        return price;
    }

    public string getDuration()
    {
        return duration;
    }

    public int getRating()
    {
        return rating;
    }

    public string getActivity()
    {
        return activity;
    }
}
