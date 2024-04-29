namespace Fleet_ManagementWebApplication.Models
{
    public class Geofences
    {
        int GeofenceID { get; set; }
        string GeofenceType { get; set; }
        int AddedDate { get; set; }
        string StrockColor { get; set; }
        int StrockOpacity { get; set; }
        int StrockWeight { get; set; }
        string FillColor { get; set; }
        int FillOpacity { get; set; }
    }
}
