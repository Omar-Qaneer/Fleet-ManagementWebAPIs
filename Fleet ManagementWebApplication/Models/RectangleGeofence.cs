namespace Fleet_ManagementWebApplication.Models
{
    public class RectangleGeofence
    {
        public int ID { get; set; }
        public int GeofenceID { get; set; }
        public float North { get; set; }
        public float East { get; set; }
        public float West { get; set; }
        public float South { get; set; }
    }
}
