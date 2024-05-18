using Fleet_ManagementWebApplication.Models;

namespace Fleet_ManagementWebApplication.Services
{
    public interface IVehicleService
    {
        Task<int> CreateVehicle(Vehicles vehicle);
        Task<IEnumerable<Vehicles>> GetVehiclesList();
        Task<Vehicles> GetVehicle(int key);
        Task<int> UpdateVehicle(Vehicles vehicle);
        Task<int> DeleteVehicle(int key);
    }
}
