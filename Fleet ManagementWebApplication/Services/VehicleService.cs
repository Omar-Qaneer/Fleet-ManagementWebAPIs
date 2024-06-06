using Dapper;
using Fleet_ManagementWebApplication.Models;
using Npgsql;

namespace Fleet_ManagementWebApplication.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly IDbService _dbService;

        public VehicleService(IDbService dbService)
        {
            _dbService = dbService;
        }

        public async Task<int> CreateVehicle(Vehicles vehicle)
        {
            int result =
                await _dbService.EditData(
                    "INSERT INTO Vehicles (VehicleNumber,VehicleType) VALUES (@VehicleNumber, @VehicleType)",
                    vehicle);
            return result;
        }

        public async Task<IEnumerable<Vehicles>> GetVehiclesList()
        {
            var vehicleList = await _dbService.GetAll<Vehicles>("SELECT * FROM Vehicles");
            return vehicleList;
        }

        public async Task<IEnumerable<VehiclesDetails>> GetVehiclesInfo()
        {
            var vehicleInfo = await _dbService.GetAll<VehiclesDetails>("SELECT v.VehicleID, v.VehicleNumber, v.VehicleType," +
                "r.vehicledirection as LastDirection,r.status as LastStatus, r.address as LastAddress," +
                "r.Latitude AS LastLatitude, r.Longitude AS LastLongitude FROM Vehicles as v " +
                "RIGHT JOIN(SELECT *, ROW_NUMBER() OVER (PARTITION BY VehicleID ORDER BY Epoch DESC) AS RowNum  FROM routehistory) as r" +
                "  ON r.VehicleID=v.VehicleID" +
                " WHERE r.RowNum = 1;");
            return vehicleInfo;
        }


        public async Task<Vehicles> GetVehicle(int id)
        {
            var vehicleList = await _dbService.GetAsync<Vehicles>("SELECT * FROM Vehicles where VehicleNumber=@id", new { id });
            return vehicleList;
        }

        public async Task<int> UpdateVehicle(Vehicles vehicle)
        {
            int updateVehicle =
                await _dbService.EditData(
                    "Update vehicles SET vehiclenumber=@VehicleNumber, vehicletype=@VehicleType WHERE vehicleid=@VehicleID",
                    vehicle);
            return updateVehicle;
        }

        public async Task<int> DeleteVehicle(int id)
        {
            var vehicleData = await _dbService.GetAsync<Vehicles>("SELECT * FROM vehiclesinformations where vehicleid=@id", new { id });
            var deleteVehicle  = 0;
            if (vehicleData != null)
            {
                var deleteVehicleInfo = await _dbService.EditData("DELETE FROM vehiclesinformations WHERE vehicleid=@id", new { id });
                if (deleteVehicleInfo != 0)
                {
                    deleteVehicle = await _dbService.EditData("DELETE FROM vehicles WHERE vehicleid=@id", new { id });
                }
            }
            else
            {
                deleteVehicle = await _dbService.EditData("DELETE FROM vehicles WHERE vehicleid=@id", new { id });
            }
            return deleteVehicle;
            
        }
    }
}
