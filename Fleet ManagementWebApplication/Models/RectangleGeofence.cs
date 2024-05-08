namespace Fleet_ManagementWebApplication.Models
{
    public class RectangleGeofence
    {
        public int ID { get; set; }
        public int GeofenceID { get; set; }
        public int North { get; set; }
        public int East { get; set; }
        public int West { get; set; }
        public int South { get; set; }
    }
}
