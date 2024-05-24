using Fleet_ManagementWebApplication.Services;
using FPro;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Concurrent;
using System.Data;

namespace Fleet_ManagementWebApplication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RouteHistoryController : ControllerBase
    {
        private readonly IRouteHistoryService _routeHistoryService;


    public RouteHistoryController(IRouteHistoryService routeHistoryService)
    {
            _routeHistoryService = routeHistoryService;
    }    
}
}
