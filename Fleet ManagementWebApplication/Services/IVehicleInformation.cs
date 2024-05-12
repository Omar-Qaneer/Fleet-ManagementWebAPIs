using Fleet_ManagementWebApplication.Models;

namespace Fleet_ManagementWebApplication.Services
{
    public interface IVehicleInformation
    {
        Task<bool> CreateVehicleInformation(VehiclesInformations vehicleInformation);
        Task<IEnumerable<VehiclesInformations>> GetVehicleInformationList();
        Task<VehiclesInformations> GetVehicleInformation(int key);
        Task<VehicleDetail> GetVehicleInfo(int key);
        Task<IEnumerable<VehiclesDetails>> GetVehiclesInfo();
        Task<VehiclesInformations> UpdateVehicleInformation(VehiclesInformations vehicleInformation);
        Task<bool> DeleteVehicleInformation(int key);
    }
}
