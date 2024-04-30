using Fleet_ManagementWebApplication.Models;

namespace Fleet_ManagementWebApplication.Services
{
    public interface IVehicleService
    {
        Task<bool> CreateVehicle(Vehicles vehicle);
        Task<List<Vehicles>> GetVehiclesList();
        Task<Vehicles> UpdateVehicle(Vehicles vehicle);
        Task<bool> DeleteVehicle(int key);
    }
}
