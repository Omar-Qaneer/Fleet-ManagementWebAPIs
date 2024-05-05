using Fleet_ManagementWebApplication.Models;

namespace Fleet_ManagementWebApplication.Services
{
    public interface IDriver
    {
        Task<bool> CreateDriver(Driver driver);
        Task<IEnumerable<Driver>> GetDriversList();
        Task<Driver> GetDriver(int key);
        Task<Driver> UpdateDriver(Driver driver);
        Task<bool> DeleteDriver(int key);
    }
}
