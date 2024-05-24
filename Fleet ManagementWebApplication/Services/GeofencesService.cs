using Fleet_ManagementWebApplication.Models;

namespace Fleet_ManagementWebApplication.Services
{
    public class GeofencesService : IGeofencesService
    {
        private readonly IDbService _dbService;

        public GeofencesService(IDbService dbService)
        {
            _dbService = dbService;
        }

        public async Task<IEnumerable<Geofences>> GetGeofences()
        {
            var geofencesList = await _dbService.GetAll<Geofences>("SELECT * FROM Vehicles");
            return geofencesList;
        }
    }
}
