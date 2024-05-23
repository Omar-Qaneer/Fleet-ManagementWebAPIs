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
    public class DriverController : ControllerBase
    {
        private readonly IDriver _driverService;


        public DriverController(IDriver driverService)
        {
            _driverService = driverService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _driverService.GetDriversList();

            var Gvar = new GVAR();

            DataTable dt = new DataTable();
            Gvar.DicOfDT.TryAdd("Drivers",dt);
            dt.Columns.Add("DriverID", typeof(int));
            dt.Columns.Add("DriverName", typeof(string));
            dt.Columns.Add("PhoneNumber", typeof(int));
            foreach (var item in result)
            {
                DataRow newRow = dt.NewRow();
                newRow["DriverID"] = item.DriverID;
                newRow["DriverName"] = item.DriverName;
                newRow["PhoneNumber"] = item.PhoneNumber;
                dt.Rows.Add(newRow);
            }
            var sz = JsonConvert.SerializeObject(Gvar);


            return Ok(sz);

        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetDriver(int id)
        {
            var result = await _driverService.GetDriver(id);
            var Gvar = new GVAR();

            DataTable dt = new DataTable();
            Gvar.DicOfDT.TryAdd("Drivers", dt);
            dt.Columns.Add("DriverID", typeof(int));
            dt.Columns.Add("DriverName", typeof(string));
            dt.Columns.Add("PhoneNumber", typeof(int));

            if (result != null)
            {
                ConcurrentDictionary<string, string> dic = new ConcurrentDictionary<string, string>();
                dic.TryAdd("STS", "1");
                Gvar.DicOfDic.TryAdd("Tags", dic);
                DataRow newRow = dt.NewRow();
                newRow["DriverID"] = result.DriverID;
                newRow["DriverName"] = result.DriverName;
                newRow["PhoneNumber"] = result.PhoneNumber;
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

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddDriver([FromBody] GVAR gvar)
        {


            Driver driver = new Driver();
            driver.DriverName = gvar.DicOfDic["Tags"]["DriverName"];
            driver.PhoneNumber =  int.Parse(gvar.DicOfDic["Tags"]["PhoneNumber"]);
            int result = await _driverService.CreateDriver(driver);

            var Gvar = new GVAR();
            if (result != 0)
            {
                var sz = "{\"DicOfDic\": {\"Tags\": {\"STS\":\"1\"}},\"DicOfDT\": { }}";
                Gvar = JsonConvert.DeserializeObject<GVAR>(sz);
            }
            else
            {
                var sz = "{\"DicOfDic\": {\"Tags\": {\"STS\":\"0\"}},\"DicOfDT\": { }}";
                Gvar = JsonConvert.DeserializeObject<GVAR>(sz);
            }

            return Ok(Gvar);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateDriver([FromBody] GVAR gvar)
        {
            Driver driver = new Driver();
            driver.DriverID = int.Parse(gvar.DicOfDic["Tags"]["DriverID"]);
            driver.DriverName = gvar.DicOfDic["Tags"]["DriverName"];
            driver.PhoneNumber = int.Parse(gvar.DicOfDic["Tags"]["PhoneNumber"]);
            int result = await _driverService.UpdateDriver(driver);

            var Gvar = new GVAR();
            if (result != 0)
            {
                var sz = "{\"DicOfDic\": {\"Tags\": {\"STS\":\"1\"}},\"DicOfDT\": { }}";
                Gvar = JsonConvert.DeserializeObject<GVAR>(sz);
            }
            else
            {
                var sz = "{\"DicOfDic\": {\"Tags\": {\"STS\":\"0\"}},\"DicOfDT\": { }}";
                Gvar = JsonConvert.DeserializeObject<GVAR>(sz);
            }

            return Ok(Gvar);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteDriver(int id)
        {
            var result = await _driverService.DeleteDriver(id);

            var Gvar = new GVAR();
            if (result != 0)
            {
                var sz = "{\"DicOfDic\": {\"Tags\": {\"STS\":\"1\"}},\"DicOfDT\": { }}";
                Gvar = JsonConvert.DeserializeObject<GVAR>(sz);
            }
            else
            {
                var sz = "{\"DicOfDic\": {\"Tags\": {\"STS\":\"0\"}},\"DicOfDT\": { }}";
                Gvar = JsonConvert.DeserializeObject<GVAR>(sz);
            }

            return Ok(Gvar);
        }
    }
}

