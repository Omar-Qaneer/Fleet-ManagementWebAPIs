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
    public class GeofencesController : ControllerBase
    {
        private readonly IGeofencesService _geofencesService;


        public GeofencesController(IGeofencesService geofencesService)
        {
            _geofencesService = geofencesService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllGeofences()
        {
            var result = await _geofencesService.GetGeofences();
            var Gvar = new GVAR();

            DataTable dt = new DataTable();
            Gvar.DicOfDT.TryAdd("Geofences", dt);
            dt.Columns.Add("GeofenceID", typeof(int));
            dt.Columns.Add("GeofenceType", typeof(string));
            dt.Columns.Add("AddedDate", typeof(long));
            dt.Columns.Add("StrockColor", typeof(string));
            dt.Columns.Add("StrockOpacity", typeof(int));
            dt.Columns.Add("StrockWeight", typeof(int));
            dt.Columns.Add("FillColor", typeof(string));
            dt.Columns.Add("FillOpacity", typeof(int));

            if (result != null)
            {
                ConcurrentDictionary<string, string> dic = new ConcurrentDictionary<string, string>();
                dic.TryAdd("STS", "1");
                Gvar.DicOfDic.TryAdd("Tags", dic);
                foreach (var item in result)
                {
                    DataRow newRow = dt.NewRow();
                    newRow["GeofenceID"] = item.GeofenceID;
                    newRow["GeofenceType"] = item.GeofenceType;
                    newRow["AddedDate"] = item.AddedDate;
                    newRow["StrockColor"] = item.StrockColor;
                    newRow["StrockOpacity"] = item.StrockOpacity;
                    newRow["StrockWeight"] = item.StrockWeight;
                    newRow["FillColor"] = item.FillColor;
                    newRow["FillOpacity"] = item.FillOpacity;
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
    }
}
