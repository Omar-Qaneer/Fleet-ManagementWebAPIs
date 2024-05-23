using Fleet_ManagementWebApplication.Models;

namespace Fleet_ManagementWebApplication.Services
{
    public interface IDriver
    {
        Task<int> CreateDriver(Driver driver);
        Task<IEnumerable<Driver>> GetDriversList();
        Task<Driver> GetDriver(int key);
        Task<int> UpdateDriver(Driver driver);
        Task<int> DeleteDriver(int key);
    }
}
