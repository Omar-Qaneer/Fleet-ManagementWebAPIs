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
            var geofencesList = await _dbService.GetAll<Geofences>("SELECT * FROM Geofences");
            return geofencesList;
        }

        public async Task<IEnumerable<CircleGeofence>> GetCircleGeofence()
        {
            var circleGeofenceList = await _dbService.GetAll<CircleGeofence>("SELECT * FROM CircleGeofence");
            return circleGeofenceList;
        }

        public async Task<IEnumerable<RectangleGeofence>> GetRectangleGeofence()
        {
            var rectangleGeofenceList = await _dbService.GetAll<RectangleGeofence>("SELECT * FROM RectangleGeofence");
            return rectangleGeofenceList;
        }

        public async Task<IEnumerable<PolygonGeofence>> GetPolygonGeofence()
        {
            var polygonGeofenceList = await _dbService.GetAll<PolygonGeofence>("SELECT * FROM PolygonGeofence");
            return polygonGeofenceList; 
        }
    }
}
