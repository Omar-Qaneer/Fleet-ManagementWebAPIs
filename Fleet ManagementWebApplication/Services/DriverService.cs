
using Fleet_ManagementWebApplication.Models;

namespace Fleet_ManagementWebApplication.Services
{
    public class DriverService : IDriver
    {
        private readonly IDbService _dbService;

        public DriverService(IDbService dbService)
        {
            _dbService = dbService;
        }
        public async Task<bool> CreateDriver(Driver driver)
        {
            var result =
                await _dbService.EditData(
                    "INSERT INTO driver (drivername,phonenumber) VALUES (@DriverName, @PhoneNumber)",
                    driver);
            return true;
        }

        public async Task<bool> DeleteDriver(int id)
        {
            var deleteDriver = await _dbService.EditData("DELETE FROM driver WHERE driverid=@id", new { id });
            return true;
        }

        public async Task<Driver> GetDriver(int id)
        {
            var driver = await _dbService.GetAsync<Driver>("SELECT * FROM driver where driverid=@id", new { id });
            return driver;
        }

        public async Task<IEnumerable<Driver>> GetDriversList()
        {
            var driverList = await _dbService.GetAll<Driver>("SELECT * FROM driver");
            return driverList;
        }

        public async Task<Driver> UpdateDriver(Driver driver)
        {
            var updateDriver =
                await _dbService.EditData(
                    "Update driver SET drivername=@DriverName, phonenumber=@PhoneNumber WHERE driverid=@DriverID",
                    driver);
            return driver;
        }
    }
}
