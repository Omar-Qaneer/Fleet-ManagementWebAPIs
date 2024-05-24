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

    [HttpGet("{vehicleId}/routeHistory")]
    public async Task<IActionResult> GetRouteHistory(int vehicleId, int epoch1, int epoch2)
    {
        var result = await _routeHistoryService.GetRouteHistory(vehicleId, epoch1, epoch2);
        var Gvar = new GVAR();

        DataTable dt = new DataTable();
        Gvar.DicOfDT.TryAdd("RouteHistory", dt);
        dt.Columns.Add("VehicleID", typeof(int));
        dt.Columns.Add("VehicleNumber", typeof(int));
        dt.Columns.Add("Address", typeof(string));
        dt.Columns.Add("Status", typeof(char));
        dt.Columns.Add("Latitude", typeof(float));
        dt.Columns.Add("Longitude", typeof(float));
        dt.Columns.Add("VehicleDirection", typeof(int));
        dt.Columns.Add("GPSSpeed", typeof(string));
        dt.Columns.Add("GPSSTime", typeof(int));

            if(result != null)
            {
                ConcurrentDictionary<string, string> dic = new ConcurrentDictionary<string, string>();
                dic.TryAdd("STS", "1");
                Gvar.DicOfDic.TryAdd("Tags", dic);
                DataRow newRow = dt.NewRow();
                newRow["VehicleID"] = result.VehicleID;
                newRow["VehicleNumber"] = result.VehicleNumber;
                newRow["Address"] = result.Address;
                newRow["Status"] = result.Status;
                newRow["Latitude"] = result.Latitude;
                newRow["Longitude"] = result.Longitude;
                newRow["VehicleDirection"] = result.VehicleDirection;
                newRow["GPSSpeed"] = result.GPSSpeed;
                newRow["GPSSTime"] = result.GPSSTime;
                dt.Rows.Add(newRow);
                var sz = JsonConvert.SerializeObject(Gvar);
                return Ok(sz);
            }
            else
            {
                var sz = "{\"DicOfDic\": {\"Tags\": {\"STS\":\"0\"}},\"DicOfDT\": { }}";
                Gvar = JsonConvert.DeserializeObject<GVAR>(sz);
                return Ok(Gvar);
            }
    }
}
}
