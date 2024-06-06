using Fleet_ManagementWebApplication.Models;
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
    public async Task<IActionResult> GetRouteHistory(int vehicleId, long epoch1, long epoch2)
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
        dt.Columns.Add("GPSSTime", typeof(long));

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

        [HttpGet]
        public async Task<IActionResult> GetRoutesHistory()
        {
            var result = await _routeHistoryService.GetRoutesHistory();
            var Gvar = new GVAR();

            DataTable dt = new DataTable();
            Gvar.DicOfDT.TryAdd("RouteHistory", dt);
            dt.Columns.Add("RouteHistoryID", typeof(int));
            dt.Columns.Add("VehicleID", typeof(int));
            dt.Columns.Add("VehicleDirection", typeof(int));
            dt.Columns.Add("Status", typeof(string));
            dt.Columns.Add("VehicleSpeed", typeof(string));
            dt.Columns.Add("Epoch", typeof(long));
            dt.Columns.Add("Address", typeof(string));
            dt.Columns.Add("Latitude", typeof(float));
            dt.Columns.Add("Longitude", typeof(float));

            if (result != null)
            {
                ConcurrentDictionary<string, string> dic = new ConcurrentDictionary<string, string>();
                dic.TryAdd("STS", "1");
                Gvar.DicOfDic.TryAdd("Tags", dic);
                foreach (var item in result)
                {
                    DataRow newRow = dt.NewRow();
                    newRow["RouteHistoryID"] = item.RouteHistoryID;
                    newRow["VehicleID"] = item.VehicleID;
                    newRow["VehicleDirection"] = item.VehicleDirection;
                    newRow["Status"] = item.Status.ToString();
                    newRow["VehicleSpeed"] = item.VehicleSpeed;
                    newRow["Epoch"] = item.Epoch;
                    newRow["Address"] = item.Address;
                    newRow["Latitude"] = item.Latitude;
                    newRow["Longitude"] = item.Longitude;
                    dt.Rows.Add(newRow);
                }
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

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetRouteHistory(int id)
        {
            var result = await _routeHistoryService.GetRouteHistoryById(id);
            var Gvar = new GVAR();
         
            DataTable dt = new DataTable();
            Gvar.DicOfDT.TryAdd("RouteHistory", dt);
            dt.Columns.Add("RouteHistoryID", typeof(int));
            dt.Columns.Add("VehicleID", typeof(int));
            dt.Columns.Add("VehicleDirection", typeof(int));
            dt.Columns.Add("Status", typeof(string));
            dt.Columns.Add("VehicleSpeed", typeof(string));
            dt.Columns.Add("Epoch", typeof(long));
            dt.Columns.Add("Address", typeof(string));
            dt.Columns.Add("Latitude", typeof(float));
            dt.Columns.Add("Longitude", typeof(float));

            if (result != null)
            {
                ConcurrentDictionary<string, string> dic = new ConcurrentDictionary<string, string>();
                dic.TryAdd("STS", "1");
                Gvar.DicOfDic.TryAdd("Tags", dic);
                foreach (var item in result)
                {
                    DataRow newRow = dt.NewRow();
                    newRow["RouteHistoryID"] = item.RouteHistoryID;
                    newRow["VehicleID"] = item.VehicleID;
                    newRow["VehicleDirection"] = item.VehicleDirection;
                    newRow["Status"] = item.Status.ToString();
                    newRow["VehicleSpeed"] = item.VehicleSpeed;
                    newRow["Epoch"] = item.Epoch;
                    newRow["Address"] = item.Address;
                    newRow["Latitude"] = item.Latitude;
                    newRow["Longitude"] = item.Longitude;
                    dt.Rows.Add(newRow);
                }
           
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

        [HttpPost]
        public async Task<IActionResult> AddVehicle([FromBody] GVAR gvar)
        {
            RouteHistory routeHistory = new RouteHistory();
            routeHistory.VehicleID = int.Parse(gvar.DicOfDic["Tags"]["VehicleID"]);
            routeHistory.VehicleDirection = int.Parse(gvar.DicOfDic["Tags"]["VehicleDirection"]);
            routeHistory.Status = char.Parse(gvar.DicOfDic["Tags"]["Status"]);
            routeHistory.VehicleSpeed = gvar.DicOfDic["Tags"]["VehicleSpeed"];
            routeHistory.Epoch = long.Parse(gvar.DicOfDic["Tags"]["Epoch"]);
            routeHistory.Address = gvar.DicOfDic["Tags"]["Address"];
            routeHistory.Latitude = float.Parse(gvar.DicOfDic["Tags"]["Latitude"]);
            routeHistory.Longitude = float.Parse(gvar.DicOfDic["Tags"]["Longitude"]);



            int result = await _routeHistoryService.CreateRouteHistory(routeHistory);
            var Gvar = new GVAR();
            if (result != 0)
            {
                ConcurrentDictionary<string, string> dic = new ConcurrentDictionary<string, string>();
                dic.TryAdd("STS", "1");
                Gvar.DicOfDic.TryAdd("Tags", dic);
                var sz = JsonConvert.SerializeObject(Gvar);
                return Ok(sz);
            }
            else
            {
                ConcurrentDictionary<string, string> dic = new ConcurrentDictionary<string, string>();
                dic.TryAdd("STS", "0");
                Gvar.DicOfDic.TryAdd("Tags", dic);
                var sz = JsonConvert.SerializeObject(Gvar);
                return Ok(sz);
            }

            return Ok(Gvar);
        }
    }
}
