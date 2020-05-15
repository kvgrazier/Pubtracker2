using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.IO;
using System.Web.Http;
using Pubtracker2Json.Models;

namespace Pubtracker2Json.Controllers
{
    public class UsersController : ApiController
    {
        private string path = System.Web.HttpContext.Current.Server.MapPath("~/Json/") + "Users.json";
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
            var items = JsonConvert.DeserializeObject<List<ptUser>>(json);
            return JsonConvert.SerializeObject(items.Find(o => o.UserId == id));
        }

        // POST api/<controller>
        public void Post(HttpRequestMessage request)
        {
            string json = File.ReadAllText(path);
            var items = JsonConvert.DeserializeObject<List<ptUser>>(json);
            string body = request.Content.ReadAsStringAsync().Result;
            ptUser newPub = JsonConvert.DeserializeObject<ptUser>(body);
            items.Add(newPub);
            File.WriteAllText(path, JsonConvert.SerializeObject(items));
        }

        // PUT api/<controller>/5
        public void Put(string id, HttpRequestMessage request)
        {
            string json = File.ReadAllText(path);
            var items = JsonConvert.DeserializeObject<List<ptUser>>(json);
            string body = request.Content.ReadAsStringAsync().Result;
            ptUser updatedPub = JsonConvert.DeserializeObject<ptUser>(body);
            int index = items.IndexOf(items.Find(x => x.UserId == id));
            if (index != -1)
                items[index] = updatedPub;
            File.WriteAllText(path, JsonConvert.SerializeObject(items));
        }

        // DELETE api/<controller>/5nd)]
        public void Delete(string id)
        {
            string json = File.ReadAllText(path);
            var items = JsonConvert.DeserializeObject<List<ptUser>>(json);
            var itemToRemove = items.Find(x => x.UserId == id);
            items.Remove(itemToRemove);
            File.WriteAllText(path, JsonConvert.SerializeObject(items));
        }
    }
}