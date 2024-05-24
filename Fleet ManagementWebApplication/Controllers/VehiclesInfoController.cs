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
        public class VehiclesInfoController : ControllerBase
        {
            private readonly IVehicleInformation _vehicleInfoService;


            public VehiclesInfoController(IVehicleInformation vehicleInfoService)
            {
                _vehicleInfoService = vehicleInfoService;
            }

            [HttpGet]
            public async Task<IActionResult> Get()
            {
                var result = await _vehicleInfoService.GetVehicleInformationList();
                var Gvar = new GVAR();

                DataTable dt = new DataTable();
                Gvar.DicOfDT.TryAdd("Vehicles", dt);
                dt.Columns.Add("ID", typeof(int));
                dt.Columns.Add("VehicleID", typeof(int));
                dt.Columns.Add("DriverID", typeof(int));
                dt.Columns.Add("VehicleMake", typeof(string));
                dt.Columns.Add("VehicleModel", typeof(string));
                dt.Columns.Add("PurchaseDate", typeof(int));

                foreach (var item in result)
                {
                    DataRow newRow = dt.NewRow();
                    newRow["ID"] = item.VehicleID;
                    newRow["VehicleID"] = item.VehicleID;
                    newRow["DriverID"] = item.DriverID;
                    newRow["VehicleMake"] = item.VehicleMake;
                    newRow["VehicleModel"] = item.VehicleModel;
                    newRow["PurchaseDate"] = item.PurchaseDate;

                    dt.Rows.Add(newRow);
                }
                var sz = JsonConvert.SerializeObject(Gvar);


                return Ok(sz);
            }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetVehicleInfo(int id)
        {
            var result = await _vehicleInfoService.GetVehicleInfo(id);
            var Gvar = new GVAR();

            DataTable dt = new DataTable();
            Gvar.DicOfDT.TryAdd("VehicleInformation", dt);
            dt.Columns.Add("VehicleNumber", typeof(int));
            dt.Columns.Add("VehicleType", typeof(string));
            dt.Columns.Add("DriverName", typeof(string));
            dt.Columns.Add("PhoneNumber", typeof(int));
            dt.Columns.Add("LastPosition", typeof(string));
            dt.Columns.Add("VehicleMake", typeof(string));
            dt.Columns.Add("VehicleModel", typeof(string));
            dt.Columns.Add("LastGPSTime", typeof(int));
            dt.Columns.Add("LastGPSSpeed", typeof(string));
            dt.Columns.Add("LastAddress", typeof(string));



            if (result != null)
            {
                ConcurrentDictionary<string, string> dic = new ConcurrentDictionary<string, string>();
                dic.TryAdd("STS", "1");
                Gvar.DicOfDic.TryAdd("Tags", dic);
                DataRow newRow = dt.NewRow();
                newRow["VehicleNumber"] = result.VehicleNumber;
                newRow["VehicleType"] = result.VehicleType;
                newRow["DriverName"] = result.DriverName;
                newRow["PhoneNumber"] = result.PhoneNumber;
                newRow["LastPosition"] = result.LastPosition;
                newRow["VehicleMake"] = result.VehicleMake;
                newRow["VehicleModel"] = result.VehicleModel;
                newRow["LastGPSTime"] = result.LastGPSTime;
                newRow["LastGPSSpeed"] = result.LastGPSSpeed;
                newRow["LastAddress"] = result.LastAddress;

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
