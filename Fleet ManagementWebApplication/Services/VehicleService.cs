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

        public async Task<bool> CreateVehicle(Vehicles vehicle)
        {
            var result =
                await _dbService.EditData(
                    "INSERT INTO Vehicles (VehicleNumber,VehicleType) VALUES (@VehicleNumber, @VehicleType)",
                    vehicle);
            return true;
        }

        public async Task<IEnumerable<Vehicles>> GetVehiclesList()
        {
            var vehicleList = await _dbService.GetAll<Vehicles>("SELECT * FROM Vehicles");
            return vehicleList;
        }


        public async Task<Vehicles> GetVehicle(int id)
        {
            var vehicleList = await _dbService.GetAsync<Vehicles>("SELECT * FROM Vehicles where vehicleid=@id", new { id });
            Console.WriteLine("hhhhhhhhhh");

            Console.WriteLine(vehicleList);
            return vehicleList;
        }

        public async Task<Vehicles> UpdateVehicle(Vehicles vehicle)
        {
            var updateVehicle =
                await _dbService.EditData(
                    "Update vehicles SET vehiclenumber=@VehicleNumber, vehicletype=@VehicleType WHERE vehicleid=@VehicleID",
                    vehicle);
            return vehicle;
        }

        public async Task<bool> DeleteVehicle(int id)
        {
            var deleteVehicle = await _dbService.EditData("DELETE FROM vehicles WHERE vehicleid=@VehicleID", new { id });
            return true;
        }
    }
}
