using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.IO;
using System.Web.Http;
using Pubtracker2Sql.Models;
using Newtonsoft.Json;

namespace Pubtracker2Sql.Controllers
{
    public class DivisionsController : ApiController
    {
        public string Get()
        {
            List<ptDivision> items = ptsHelper.GetAllDivisions();
            return JsonConvert.SerializeObject(items);
        }

    // GET: api/Divisions/5
    public string Get(string id)
        { 
          ptDivision item = ptsHelper.GetAllDivisions().Find(x => x.DivisionId == id);
          return JsonConvert.SerializeObject(item);
        }

    // POST: api/Divisions
    public void Post(HttpRequestMessage request)
    {
            string body = request.Content.ReadAsStringAsync().Result;
            ptDivision d = JsonConvert.DeserializeObject<ptDivision>(body);
            string sql = "INSERT INTO [pubtrack].[tblDivisions]([DivisionId],[DivisionName],[Active]) VALUES ('" +
            d.DivisionId + "','" + d.DivisionName + "','" + d.Active.ToString() + "');";
            ptsHelper.ExcecuteSql(sql);
    }

    // PUT: api/Divisions/5
    public void Put(string id, HttpRequestMessage request)
    {
            string body = request.Content.ReadAsStringAsync().Result;
            ptDivision d = JsonConvert.DeserializeObject<ptDivision>(body);
            string sql = "UPDATE [pubtrack].[tblDivisions] SET [DivisionName] = '" +
            d.DivisionName + "',[Active] = '" + d.Active.ToString() +
            "' WHERE DivisionId = '" + d.DivisionId + "';";
            ptsHelper.ExcecuteSql(sql);
    }

    public void Delete(string id)
    {
            string sql = "Delete From pubtrack.tblDivisions where DivisionId = '" + id + "';";
            ptsHelper.ExcecuteSql(sql);
    }
} // End Class
}// End Namespace