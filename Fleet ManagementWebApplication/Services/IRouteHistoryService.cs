using Fleet_ManagementWebApplication.Models;

namespace Fleet_ManagementWebApplication.Services
{
    public interface IRouteHistoryService
    {
        Task<int> CreateRouteHistory(RouteHistory routeHistory);
        Task<RouteHistoryDetails> GetRouteHistory(int vehicleId, int Epoch1, int Epoch2);
    }
}
