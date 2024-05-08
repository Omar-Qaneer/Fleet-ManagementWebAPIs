namespace Fleet_ManagementWebApplication.Models
{
    public class RouteHistory
    {
        public int RouteHistoryID { get; set; }
        public int VehicleID { get; set; }
        public int VehicleDirection { get; set; }
        public char Status { get; set; }
        public string VehicleSpeed { get; set; }
        public int Epoch { get; set; }
        public string Address { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
    }
}
