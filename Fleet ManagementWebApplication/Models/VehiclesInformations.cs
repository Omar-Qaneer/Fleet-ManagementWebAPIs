namespace Fleet_ManagementWebApplication.Models
{
    public class VehiclesInformations
    {
        public int ID { get; set; }
        public int VehicleID { get; set; }
        public int DriverID { get; set; }
        public string VehicleMake { get; set; }
        public string VehicleModel { get; set; }
        public long PurchaseDate { get; set; }
    }
}
