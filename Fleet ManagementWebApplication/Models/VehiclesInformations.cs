namespace Fleet_ManagementWebApplication.Models
{
    public class VehiclesInformations
    {
        int ID { get; set; }
        int VehicleID { get; set; }
        int DriverID { get; set; }
        string VehicleMake { get; set; }
        string VehicleModel { get; set; }
        int PurchaseDate { get; set; }
    }
}
