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
            var deleteVehicle = await _dbService.EditData("DELETE FROM vehicles WHERE VehicleNumber=@id", new { id });
            return deleteVehicle;
        }
    }
}
