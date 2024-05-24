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
        }
}
