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
