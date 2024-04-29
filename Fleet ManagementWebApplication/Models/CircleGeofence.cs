namespace Fleet_ManagementWebApplication.Models
{
    public class CircleGeofence
    {
        int ID { get; set; }
        int GeofenceID { get; set; }
        int Radius { get; set; }
        int Latitude { get; set; }
        int Longitude { get; set; }
    }
}
