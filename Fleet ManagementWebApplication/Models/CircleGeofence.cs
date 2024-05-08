namespace Fleet_ManagementWebApplication.Models
{
    public class CircleGeofence
    {
        public int ID { get; set; }
        public int GeofenceID { get; set; }
        public int Radius { get; set; }
        public int Latitude { get; set; }
        public int Longitude { get; set; }
    }
}
