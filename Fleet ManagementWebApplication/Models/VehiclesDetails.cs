namespace Fleet_ManagementWebApplication.Models
{
    public class VehiclesDetails
    {
        public int VehicleID { get; set; }
        public int VehicleNumber { get; set; }
        public string VehicleType { get; set; }
        public int LastDirection { get; set; }
        public string LastStatus { get; set; }
        public string LastAddress { get; set; }
        public string LastPosition { get; set; }
    }
}
