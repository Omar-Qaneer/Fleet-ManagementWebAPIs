namespace Fleet_ManagementWebApplication.Models
{
    public class VehicleDetail
    {
        int VehicleNumber { get; set; }
        string VehicleType { get; set; }
        string DriverName { get; set; }
        int PhoneNumber { get; set; }
        int LastPosition { get; set; }
        string VehicleMake { get; set; }
        string VehicleModel { get; set; }
        int LastGPSTime { get; set; }
        string LastGPSSpeed { get; set; }
        string LastAddress { get; set; }
    }
}
