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
    public class TypesController : ApiController
    {
        public string Get()
        {
            List<ptType> items = ptsHelper.GetAllTypes();
            return JsonConvert.SerializeObject(items);
        }

        // GET: api/Types/5
        public string Get(string id)
        {
            ptType item = ptsHelper.GetAllTypes().Find(x => x.TypeId == id);
            return JsonConvert.SerializeObject(item);
        }

        // POST: api/Types
        public void Post(HttpRequestMessage request)
        {
            string body = request.Content.ReadAsStringAsync().Result;
            ptType d = JsonConvert.DeserializeObject<ptType>(body);
            string sql = "INSERT INTO [pubtrack].[tblTypes]([TypeId],[TypeName],[Active]) VALUES ('" +
            d.TypeId + "','" + d.TypeName + "','" + d.Active.ToString() + "');";
            ptsHelper.ExcecuteSql(sql);
        }

        // PUT: api/Types/5
        public void Put(string id, HttpRequestMessage request)
        {
            string body = request.Content.ReadAsStringAsync().Result;
            ptType d = JsonConvert.DeserializeObject<ptType>(body);
            string sql = "UPDATE [pubtrack].[tblTypes] SET [TypeName] = '" +
            d.TypeName + "',[Active] = '" + d.Active.ToString() +
            "' WHERE TypeId = '" + d.TypeId + "';";
            ptsHelper.ExcecuteSql(sql);
        }

        public void Delete(string id)
        {
            string sql = "Delete From pubtrack.tblTypes where TypeId = '" + id + "';";
            ptsHelper.ExcecuteSql(sql);
        }
    } // End Class
}// End Namespace