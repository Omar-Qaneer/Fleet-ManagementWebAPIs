namespace Fleet_ManagementWebApplication.Models
{
    public class VehiclesDetails
    {
        int VehicleID { get; set; }
        int VehicleNumber { get; set; }
        string VehicleType { get; set; }
        int LastDirection { get; set; }
        string LastStatus { get; set; }
        string LastAddress { get; set; }
        float LastLatitude { get; set; }
        float LastLongitude { get; set; }
    }
}
