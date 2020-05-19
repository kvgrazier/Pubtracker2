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
    public class StepsController : ApiController
    {
        public string Get()
        {
            List<ptStep> items = ptsHelper.GetAllSteps();
            return JsonConvert.SerializeObject(items);
        }

        // GET: api/Steps/5
        public string Get(string id)
        {
            ptStep item = ptsHelper.GetAllSteps().Find(x => x.StepId == id);
            return JsonConvert.SerializeObject(item);
        }

        // POST: api/Steps
        public void Post(HttpRequestMessage request)
        {
            string body = request.Content.ReadAsStringAsync().Result;
            ptStep d = JsonConvert.DeserializeObject<ptStep>(body);
            string sql = "INSERT INTO [pubtrack].[tblSteps]([StepId],[StepName],[Active]) VALUES ('" +
            d.StepId + "','" + d.StepName + "','" + d.Active.ToString() + "');";
            ptsHelper.ExcecuteSql(sql);
        }

        // PUT: api/Steps/5
        public void Put(string id, HttpRequestMessage request)
        {
            string body = request.Content.ReadAsStringAsync().Result;
            ptStep d = JsonConvert.DeserializeObject<ptStep>(body);
            string sql = "UPDATE [pubtrack].[tblSteps] SET [StepName] = '" +
            d.StepName + "',[Active] = '" + d.Active.ToString() +
            "' WHERE StepId = '" + d.StepId + "';";
            ptsHelper.ExcecuteSql(sql);
        }

        public void Delete(string id)
        {
            string sql = "Delete From pubtrack.tblSteps where StepId = '" + id + "';";
            ptsHelper.ExcecuteSql(sql);
        }
    } // End Class
}// End Namespace