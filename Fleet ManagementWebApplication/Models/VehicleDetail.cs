namespace Fleet_ManagementWebApplication.Models
{
    public class VehicleDetail
    {
        public int VehicleNumber { get; set; }
        public string VehicleType { get; set; }
        public string[] DriverName { get; set; }
        public int[] PhoneNumber { get; set; }
        public string LastPosition { get; set; }
        public string VehicleMake { get; set; }
        public string VehicleModel { get; set; }
        public int LastGPSTime { get; set; }
        public string LastGPSSpeed { get; set; }
        public string LastAddress { get; set; }
    }
}
