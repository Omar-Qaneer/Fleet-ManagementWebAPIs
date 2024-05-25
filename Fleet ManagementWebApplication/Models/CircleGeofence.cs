namespace Fleet_ManagementWebApplication.Models
{
    public class CircleGeofence
    {
        public int ID { get; set; }
        public int GeofenceID { get; set; }
        public int Radius { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
    }
}
