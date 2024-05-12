using Fleet_ManagementWebApplication.Models;

namespace Fleet_ManagementWebApplication.Services
{
    public class RouteHistoryService
    {
        private readonly IDbService _dbService;

        public RouteHistoryService(IDbService dbService)
        {
            _dbService = dbService;
        }

        public async Task<bool> CreateRouteHistory(RouteHistory routeHistory)
        {
            var result =
                await _dbService.EditData(
                    "INSERT INTO routehistory (vehicleid, vehicledirection, status, vehiclespeed, epoch," +
                    " address, latitude, longitude) VALUES (@VehicleID, @VehicleDirection, @Status, @VehicleSpeed, @Epoch, @Address, @Latitude, @Longitude)",
                    routeHistory);
            return true;
        }

        public async Task<RouteHistoryDetails> GetRouteHistory(int Epoch1, int Epoch2)
        {
            var routeHistoryList = await _dbService.GetAsync<RouteHistoryDetails>("SELECT vehicleid,vehiclenumber,vehicletype,address," +
                "status,latitude,longitude,vehicledirection,vehiclespeed AS GPSSpeed,epoch AS GPSTime FROM routehistory AS t1" +
                " INNER JOIN Vehicles AS t2 ON t1.vehicleid = t2.vehicleid " +
                "AND epoch BETWEEN @Epoch1 AND @Epoch2 ", new { Epoch1, Epoch2 });
            return routeHistoryList;
        }       
    }
}
