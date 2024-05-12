using Fleet_ManagementWebApplication.Models;

namespace Fleet_ManagementWebApplication.Services
{
    public class VehicleInformation : IVehicleInformation
    {
        private readonly IDbService _dbService;

        public VehicleInformation(IDbService dbService)
        {
            _dbService = dbService;
        }
        public async Task<bool> CreateVehicleInformation(VehiclesInformations vehicleInformation)
        {
            var result =
                await _dbService.EditData(
                    "INSERT INTO vehiclesinformations (vehicleid, driverid, vehiclemake, vehiclemodel, purchasedate) VALUES (@VehicleID, @DriverID, @VehicleMake, @VehicleModel, @PurchaseDate)",
                    vehicleInformation);
            return true;
        }

        public async Task<bool> DeleteVehicleInformation(int id)
        {
            var deleteVehicle = await _dbService.EditData("DELETE FROM vehiclesinformations WHERE vehicleid=@id", new { id });
            return true;
        }

        public async Task<VehiclesInformations> GetVehicleInformation(int id)
        {
            var vehicleList = await _dbService.GetAsync<VehiclesInformations>("SELECT * FROM Vehicles where vehicleid=@id", new { id });
            return vehicleList;
        }

        public async Task<VehicleDetail> GetVehicleInfo(int id)
        {
            var vehicleInfo = await _dbService.GetAsync<VehicleDetail>("SELECT VehicleNumber,VehicleType,DriverName,PhoneNumber," +
                "CAST(Latitude AS TEXT) || ', ' || CAST(Longitude AS TEXT) AS LastPosition,VehicleMake,VehicleModel,epoch AS LastGPSTime," +
                "vehiclespeed AS LastGPSSpeed,address AS LastAddress FROM vehiclesinformations AS vi " +
                "LEFT JOIN Driver AS d ON d.DriverID=vi.DriverID " +
                "INNER JOIN Vehicles AS v ON v.VehicleID=vi.VehicleID " +
                "INNER JOIN (SELECT CAST(Latitude AS TEXT) || ', ' || CAST(Longitude AS TEXT) AS LastPosition," +
                "epoch AS LastGPSTime,vehiclespeed AS LastGPSSpeed,address AS LastAddress " +
                "FROM routehistory " +
                "ORDER BY epoch Desc" +
                "LIMIT 1) AS r ON r.VehicleID=vi.VehicleID " +
                "AND VehicleID=@id", new { id });
            return vehicleInfo;
        }

        public async Task<IEnumerable<VehiclesDetails>> GetVehiclesInfo()
        {
            var vehicleInfo = await _dbService.GetAll<VehiclesDetails>("SELECT VehicleID,VehicleNumber,VehicleType," +
                "vehicledirection AS LastDirection,status AS LastStatus,address AS LastAddress,latitude AS LastLatitude" +
                "longitude AS LastLongitude FROM Vehicles AS v " +
                "INNER JOIN (SELECT vehicledirection AS LastDirection,status AS LastStatus," +
                "address AS LastAddress,latitude AS LastLatitude " +
                "FROM routehistory " +
                "ORDER BY epoch Desc" +
                "LIMIT 1) AS r ON r.VehicleID=v.VehicleID ");
            return vehicleInfo;
        }

        public async Task<IEnumerable<VehiclesInformations>> GetVehicleInformationList()
        {
            var vehicleInformationList = await _dbService.GetAll<VehiclesInformations>("SELECT * FROM vehiclesinformations");
            return vehicleInformationList;
        }

        public async Task<VehiclesInformations> UpdateVehicleInformation(VehiclesInformations vehicleInformation)
        {
            var updateVehicleInformation =
                await _dbService.EditData(
                    "Update vehicles SET vehiclemake=@VehicleMake, vehiclemodel=@VehicleModel, purchasedate=@PurchaseDate WHERE vehicleid=@VehicleID",
                    vehicleInformation);
            return vehicleInformation;
        }
    }
}
