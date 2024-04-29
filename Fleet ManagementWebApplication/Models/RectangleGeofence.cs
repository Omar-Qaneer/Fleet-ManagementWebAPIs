namespace Fleet_ManagementWebApplication.Models
{
    public class RectangleGeofence
    {
        int ID { get; set; }
        int GeofenceID { get; set; }
        int North { get; set; }
        int East { get; set; }
        int West { get; set; }
        int South { get; set; }
    }
}
