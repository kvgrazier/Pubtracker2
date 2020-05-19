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
    public class RolesController : ApiController
    {
        public string Get()
        {
            List<ptRole> items = ptsHelper.GetAllRoles();
            return JsonConvert.SerializeObject(items);
        }

        // GET: api/Roles/5
        public string Get(string id)
        {
            ptRole item = ptsHelper.GetAllRoles().Find(x => x.RoleId == id);
            return JsonConvert.SerializeObject(item);
        }

        // POST: api/Roles
        public void Post(HttpRequestMessage request)
        {
            string body = request.Content.ReadAsStringAsync().Result;
            ptRole d = JsonConvert.DeserializeObject<ptRole>(body);
            string sql = "INSERT INTO [pubtrack].[tblRoles]([RoleId],[RoleName],[Active]) VALUES ('" +
            d.RoleId + "','" + d.RoleName + "','" + d.Active.ToString() + "');";
            ptsHelper.ExcecuteSql(sql);
        }

        // PUT: api/Roles/5
        public void Put(string id, HttpRequestMessage request)
        {
            string body = request.Content.ReadAsStringAsync().Result;
            ptRole d = JsonConvert.DeserializeObject<ptRole>(body);
            string sql = "UPDATE [pubtrack].[tblRoles] SET [RoleName] = '" +
            d.RoleName + "',[Active] = '" + d.Active.ToString() +
            "' WHERE RoleId = '" + d.RoleId + "';";
            ptsHelper.ExcecuteSql(sql);
        }

        public void Delete(string id)
        {
            string sql = "Delete From pubtrack.tblRoles where RoleId = '" + id + "';";
            ptsHelper.ExcecuteSql(sql);
        }
    } // End Class
}// End Namespace