using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using Pubtracker2Sql.Models;
using System.IO;
using System.Net.Http;
using System.Linq;
using System;

namespace Pubtracker2Sql.Controllers
{
    public class PublicationsController : ApiController
    {

        public string Get()
        {
            List<ptPublication> items = ptsHelper.GetAllPublications();
            return JsonConvert.SerializeObject(items.OrderByDescending(x => x.SortId).Take(10));
        }

        // GET: api/Publications/5
        public string Get(string id)
        {
            List<ptPublication> items = ptsHelper.GetAllPublications();
            ptPublication item = items.Find(x => x.PublicationId == id);
            return JsonConvert.SerializeObject(item);
        }

        // POST: api/Publications
        public void Post(HttpRequestMessage request)
        {
            string body = request.Content.ReadAsStringAsync().Result;
            ptPublication p = JsonConvert.DeserializeObject<ptPublication>(body);
            string sql = "INSERT INTO [pubtrack].[Publication]([PublicationId],[SortId],[Title],[Type],[Series],[Division],[Roles],[Statuses],[Remarks]) VALUES('" +
            p.PublicationId + "'," + 
            Convert.ToInt32(p.SortId) + ",'" + 
            p.Title + "','" +
            JsonConvert.SerializeObject(p.Type) + "','" +
            p.Series + "','" +
            JsonConvert.SerializeObject(p.Division) + "','" +
            JsonConvert.SerializeObject(p.Roles) + "','" +
            JsonConvert.SerializeObject(p.Statuses) + "','" +
            p.Remarks + "');";
            ptsHelper.ExcecuteSql(sql);
        }

        // PUT: api/Publications/5
        public void Put(string id, HttpRequestMessage request)
        {
            string body = request.Content.ReadAsStringAsync().Result;
            ptPublication p = JsonConvert.DeserializeObject<ptPublication>(body);
            string sql = "UPDATE [pubtrack].[Publication] SET " +
            "[SortId] = " + Convert.ToInt32(p.SortId) +
            ",[Title] = '" + p.Title +
            "',[Type] = '" + JsonConvert.SerializeObject(p.Type) +
            "',[Series] = '" + p.Series +
            "',[Division] = '" + JsonConvert.SerializeObject(p.Division) +
            "',[Roles] = '" + JsonConvert.SerializeObject(p.Roles) +
            "',[Statuses] = '" + JsonConvert.SerializeObject(p.Statuses) +
            "',[Remarks] = '" + p.Remarks+
            "' WHERE [PublicationId] = '" + p.PublicationId + 
            "';";
            ptsHelper.ExcecuteSql(sql);
        }

        // DELETE: api/Publications/5
        public void Delete(string id)
        {
            string sql = "Delete From pubtrack.Publication where PublicationId = '" + id + "';";
            ptsHelper.ExcecuteSql(sql);
        }
    }
}
