using Fleet_ManagementWebApplication.Models;

namespace Fleet_ManagementWebApplication.Services
{
    public interface IRouteHistoryService
    {
        Task<int> CreateRouteHistory(RouteHistory routeHistory);
        Task<RouteHistoryDetails> GetRouteHistory(int vehicleId, long Epoch1, long Epoch2);
        Task<IEnumerable<RouteHistory>> GetRoutesHistory();
        Task<IEnumerable<RouteHistory>> GetRouteHistoryById(int id);
    }
}
