using Fleet_ManagementWebApplication.Models;

namespace Fleet_ManagementWebApplication.Services
{
    public interface IRouteHistoryService
    {
        Task<bool> CreateRouteHistory(RouteHistory routeHistory);
        Task<RouteHistoryDetails> GetRouteHistory(int Epoch1, int Epoch2);
    }
}
