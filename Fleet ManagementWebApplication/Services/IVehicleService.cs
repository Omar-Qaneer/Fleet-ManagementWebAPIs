using Fleet_ManagementWebApplication.Models;

namespace Fleet_ManagementWebApplication.Services
{
    public interface IVehicleService
    {
        Task<bool> CreateVehicle(Vehicles vehicle);
        Task<IEnumerable<Vehicles>> GetVehiclesList();
        Task<Vehicles> GetVehicle(int key);
        Task<Vehicles> UpdateVehicle(Vehicles vehicle);
        Task<bool> DeleteVehicle(int key);
    }
}
