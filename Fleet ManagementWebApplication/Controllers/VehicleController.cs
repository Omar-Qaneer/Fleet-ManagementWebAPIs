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
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleService _vehicleService;


        public VehicleController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        [HttpGet]
        public async Task<IActionResult> Get() 
        {
            var result = await _vehicleService.GetVehiclesList();
            var Gvar = new GVAR(); 

            DataTable dt = new DataTable();
            Gvar.DicOfDT.TryAdd("Vehicles",dt);
            dt.Columns.Add("VehicleID", typeof(int));
            dt.Columns.Add("VehicleNumber", typeof(int));
            dt.Columns.Add("VehicleType", typeof(string));
            foreach (var item in result)
            {
                DataRow newRow = dt.NewRow();
                newRow["VehicleID"] = item.VehicleID; 
                newRow["VehicleNumber"] = item.VehicleNumber; 
                newRow["VehicleType"] = item.VehicleType;
                dt.Rows.Add(newRow);
            }
            var sz = JsonConvert.SerializeObject(Gvar);


            return Ok(sz);
        }

        [HttpGet("VehiclesInfo")]
        public async Task<IActionResult> GetVehiclesInfo()
        {
            var result = await _vehicleService.GetVehiclesInfo();
            var Gvar = new GVAR();

            DataTable dt = new DataTable();
            Gvar.DicOfDT.TryAdd("Vehicles", dt);
            dt.Columns.Add("VehicleID", typeof(int));
            dt.Columns.Add("VehicleNumber", typeof(int));
            dt.Columns.Add("VehicleType", typeof(string));
            dt.Columns.Add("LastDirection", typeof(int));
            dt.Columns.Add("LastStatus", typeof(string));
            dt.Columns.Add("LastAddress", typeof(string));
            dt.Columns.Add("LastLatitude", typeof(float));
            dt.Columns.Add("LastLongitude", typeof(float));

            foreach (var item in result)
            {
                DataRow newRow = dt.NewRow();
                newRow["VehicleID"] = item.VehicleID;
                newRow["VehicleNumber"] = item.VehicleNumber;
                newRow["VehicleType"] = item.VehicleType;
                newRow["LastDirection"] = item.LastDirection;
                newRow["LastStatus"] = item.LastStatus;
                newRow["LastAddress"] = item.LastAddress;
                newRow["LastLatitude"] = item.LastLatitude;
                newRow["LastLongitude"] = item.LastLongitude;


                dt.Rows.Add(newRow);
            }
            var sz = JsonConvert.SerializeObject(Gvar);


            return Ok(sz);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetVehicle(int id)
        {
            var result = await _vehicleService.GetVehicle(id);
            var Gvar = new GVAR();
            DataTable dt = new DataTable();
            Gvar.DicOfDT.TryAdd("Vehicles", dt);
            dt.Columns.Add("VehicleID", typeof(int));
            dt.Columns.Add("VehicleNumber", typeof(int));
            dt.Columns.Add("VehicleType", typeof(string));
            if (result != null)
            {
                ConcurrentDictionary<string,string> dic = new ConcurrentDictionary<string,string>();
                dic.TryAdd("STS","1");
                Gvar.DicOfDic.TryAdd("Tags",dic);
                DataRow newRow = dt.NewRow();
                newRow["VehicleID"] = result.VehicleID;
                newRow["VehicleNumber"] = result.VehicleNumber;
                newRow["VehicleType"] = result.VehicleType;
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

        [HttpPost]
        public async Task<IActionResult> AddVehicle([FromBody] GVAR gvar)
        {
            Vehicles vehicle = new Vehicles();
            vehicle.VehicleNumber = int.Parse(gvar.DicOfDic["Tags"]["VehicleNumber"]);
            vehicle.VehicleType = gvar.DicOfDic["Tags"]["VehicleType"];
            int result = await _vehicleService.CreateVehicle(vehicle);
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

        }

        [HttpPut]
        public async Task<IActionResult> UpdateVehicle([FromBody] GVAR gvar)
        {
            Vehicles vehicle = new Vehicles();
            vehicle.VehicleID = int.Parse(gvar.DicOfDic["Tags"]["VehicleID"]);
            vehicle.VehicleNumber = int.Parse(gvar.DicOfDic["Tags"]["VehicleNumber"]);
            vehicle.VehicleType = gvar.DicOfDic["Tags"]["VehicleType"];
            int result = await _vehicleService.UpdateVehicle(vehicle);
            var Gvar = new GVAR();
            if(result != 0)
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

        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteVehicle(int id)
        {
            var result = await _vehicleService.DeleteVehicle(id);
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

        }
    }
}

