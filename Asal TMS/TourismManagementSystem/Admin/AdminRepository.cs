namespace TourismManagementSystem.Admin;
public class AdminRepository
{
    public AdminAccount GetAdmin()
    {
        return new AdminAccount("Fama", "2578");
    }
}
