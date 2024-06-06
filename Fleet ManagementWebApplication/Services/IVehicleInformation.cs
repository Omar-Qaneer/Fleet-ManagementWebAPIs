using Fleet_ManagementWebApplication.Models;

namespace Fleet_ManagementWebApplication.Services
{
    public interface IVehicleInformation
    {
        Task<int> CreateVehicleInformation(VehiclesInformations vehicleInformation);
        Task<IEnumerable<VehiclesInformations>> GetVehicleInformationList();
        Task<VehiclesInformations> GetVehicleInformation(int key);
        Task<VehicleDetail> GetVehicleInfo(int key);
        Task<VehiclesInformations> UpdateVehicleInformation(VehiclesInformations vehicleInformation);
        Task<bool> DeleteVehicleInformation(int key);
    }
}
