using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.IO;
using System.Web.Http;
using Pubtracker2Json.Models;

namespace Pubtracker2Json.Controllers
{
    public class RolesController : ApiController
    {
        private string path = System.Web.HttpContext.Current.Server.MapPath("~/Json/") + "Roles.json";
        // GET api/<controller>
        public string Get()
        {
            string json = File.ReadAllText(path);
            return json;
        }

        // GET api/<controller>/5
        public string Get(string id)
        {
            string json = File.ReadAllText(path);
            var items = JsonConvert.DeserializeObject<List<ptRole>>(json);
            return JsonConvert.SerializeObject(items.Find(o => o.RoleId == id));
        }

        // POST api/<controller>
        public void Post(HttpRequestMessage request)
        {
            string json = File.ReadAllText(path);
            var items = JsonConvert.DeserializeObject<List<ptRole>>(json);
            string body = request.Content.ReadAsStringAsync().Result;
            ptRole newPub = JsonConvert.DeserializeObject<ptRole>(body);
            items.Add(newPub);
            File.WriteAllText(path, JsonConvert.SerializeObject(items));
        }

        // PUT api/<controller>/5
        public void Put(string id, HttpRequestMessage request)
        {
            string json = File.ReadAllText(path);
            var items = JsonConvert.DeserializeObject<List<ptRole>>(json);
            string body = request.Content.ReadAsStringAsync().Result;
            ptRole updatedPub = JsonConvert.DeserializeObject<ptRole>(body);
            int index = items.IndexOf(items.Find(x => x.RoleId == id));
            if (index != -1)
                items[index] = updatedPub;
            File.WriteAllText(path, JsonConvert.SerializeObject(items));
        }

        // DELETE api/<controller>/5
        public void Delete(string id)
        {
            string json = File.ReadAllText(path);
            var items = JsonConvert.DeserializeObject<List<ptRole>>(json);
            var itemToRemove = items.Find(x => x.RoleId == id);
            items.Remove(itemToRemove);
            File.WriteAllText(path, JsonConvert.SerializeObject(items));
        }
    }
}