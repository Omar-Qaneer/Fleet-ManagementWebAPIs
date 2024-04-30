using Fleet_ManagementWebApplication.Models;

namespace Fleet_ManagementWebApplication.Services
{
    public class VehicleService
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
                    "INSERT INTO vehicles (vehiclenumber,vehicletype) VALUES (@VehicleNumber, @VehicleType)",
                    vehicle);
            return true;
        }

        public async Task<List<Vehicles>> GetVehicleList()
        {
            var vehicleList = await _dbService.GetAll<Vehicles>("SELECT * FROM vehicles", new { });
            return vehicleList;
        }


        public async Task<Vehicles> GetVehicle(int id)
        {
            var vehicleList = await _dbService.GetAsync<Vehicles>("SELECT * FROM vehicles where vehicleid=@id", new { id });
            return vehicleList;
        }

        public async Task<Vehicles> UpdateEmployee(Vehicles vehicle)
        {
            var updateEmployee =
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
