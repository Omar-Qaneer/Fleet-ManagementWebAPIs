namespace Fleet_ManagementWebApplication.Models
{
    public class Geofences
    {
        public int GeofenceID { get; set; }
        public string GeofenceType { get; set; }
        public long AddedDate { get; set; }
        public string StrockColor { get; set; }
        public int StrockOpacity { get; set; }
        public int StrockWeight { get; set; }
        public string FillColor { get; set; }
        public int FillOpacity { get; set; }
    }
}
