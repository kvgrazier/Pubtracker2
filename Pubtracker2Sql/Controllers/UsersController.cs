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
    public class UsersController : ApiController
    {
        public string Get()
        {
            List<ptUser> items = ptsHelper.GetAllUsers();
            return JsonConvert.SerializeObject(items);
        }

        // GET: api/User/5
        public string Get(string id)
        {
            ptUser item = ptsHelper.GetAllUsers().Find(x => x.UserId == id);
            return JsonConvert.SerializeObject(item);
        }

        // POST: api/User
        public void Post(HttpRequestMessage request)
        {
            string body = request.Content.ReadAsStringAsync().Result;
            ptUser d = JsonConvert.DeserializeObject<ptUser>(body);
            string sql = "INSERT INTO [pubtrack].[tblUsers]([UserId],[FirstName],[LastName],[Active]) VALUES ('" +
            d.UserId + "','" + d.FirstName + "','" + d.LastName + "','" + d.Active.ToString() + "');";
            ptsHelper.ExcecuteSql(sql);
        }

        // PUT: api/User/5
        public void Put(string id, HttpRequestMessage request)
        {
            string body = request.Content.ReadAsStringAsync().Result;
            ptUser d = JsonConvert.DeserializeObject<ptUser>(body);
            string sql = "UPDATE [pubtrack].[tblUsers] SET [FirstName] = '" +
            d.FirstName + "', [LastName] = '" + d.LastName+ "',[Active] = '" + d.Active.ToString() +
            "' WHERE UserId = '" + d.UserId + "';";
            ptsHelper.ExcecuteSql(sql);
        }

        public void Delete(string id)
        {
            string sql = "Delete From pubtrack.tblUsers where UserId = '" + id + "';";
            ptsHelper.ExcecuteSql(sql);
        }
    } // End Class
}// End Namespace