namespace Fleet_ManagementWebApplication.Models
{
    public class RouteHistory
    {
        int RouteHistoryID { get; set; }
        int VehicleID { get; set; }
        int VehicleDirection { get; set; }
        char Status { get; set; }
        string VehicleSpeed { get; set; }
        int Epoch { get; set; }
        string Address { get; set; }
        int Latitude { get; set; }
        int Longitude { get; set; }
    }
}
