using Fleet_ManagementWebApplication.Models;

namespace Fleet_ManagementWebApplication.Services
{
    public interface IGeofencesService
    {
        Task<IEnumerable<Geofences>> GetGeofences();
    }
}
