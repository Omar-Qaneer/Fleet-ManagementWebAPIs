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

        [HttpGet("CircleGeofences")]
        public async Task<IActionResult> GetAllCircleGeofence()
        {
            var result = await _geofencesService.GetCircleGeofence();
            var Gvar = new GVAR();

            DataTable dt = new DataTable();
            Gvar.DicOfDT.TryAdd("CircleGeofences", dt);
            dt.Columns.Add("GeofenceID", typeof(int));
            dt.Columns.Add("Radius", typeof(int));
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
                    newRow["GeofenceID"] = item.GeofenceID;
                    newRow["Radius"] = item.Radius;
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

        [HttpGet("PolygonGeofences")]
        public async Task<IActionResult> GetAllPolygonGeofence()
        {
            var result = await _geofencesService.GetPolygonGeofence();
            var Gvar = new GVAR();

            DataTable dt = new DataTable();
            Gvar.DicOfDT.TryAdd("PolygonGeofences", dt);
            dt.Columns.Add("GeofenceID", typeof(int));
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
                    newRow["GeofenceID"] = item.GeofenceID;
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

        [HttpGet("RectangleGeofences")]
        public async Task<IActionResult> GetAllRectangleGeofence()
        {
            var result = await _geofencesService.GetRectangleGeofence();
            var Gvar = new GVAR();

            DataTable dt = new DataTable();
            Gvar.DicOfDT.TryAdd("RectangleGeofences", dt);
            dt.Columns.Add("GeofenceID", typeof(int));
            dt.Columns.Add("North", typeof(float));
            dt.Columns.Add("East", typeof(float));
            dt.Columns.Add("West", typeof(float));
            dt.Columns.Add("South", typeof(float));

            if (result != null)
            {
                ConcurrentDictionary<string, string> dic = new ConcurrentDictionary<string, string>();
                dic.TryAdd("STS", "1");
                Gvar.DicOfDic.TryAdd("Tags", dic);
                foreach (var item in result)
                {
                    DataRow newRow = dt.NewRow();
                    newRow["GeofenceID"] = item.GeofenceID;
                    newRow["North"] = item.North;
                    newRow["East"] = item.East;
                    newRow["West"] = item.West;
                    newRow["South"] = item.South;

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
