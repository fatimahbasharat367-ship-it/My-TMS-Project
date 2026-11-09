namespace TourismManagementSystem.Admin;
public class AdminAccount
{
    private string username;
    private string password;

    public AdminAccount(string username, string password)
    {
        this.username = username;
        this.password = password;
    }

    public string getUsername()
    {
        return username;
    }
    public bool checkLogin(string username, string password)
    {
        return this.username == username && this.password == password;
    }
}
