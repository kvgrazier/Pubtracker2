using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.IO;
using System.Web.Http;
using Pubtracker2Json.Models;

namespace Pubtracker2Json.Controllers
{
    public class StepsController : ApiController
    {
        private string path = System.Web.HttpContext.Current.Server.MapPath("~/Json/") + "Steps.json";
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
            var items = JsonConvert.DeserializeObject<List<ptStep>>(json);
            return JsonConvert.SerializeObject(items.Find(o => o.StepId == id));
        }

        // POST api/<controller>
        public void Post(HttpRequestMessage request)
        {
            string json = File.ReadAllText(path);
            var items = JsonConvert.DeserializeObject<List<ptStep>>(json);
            string body = request.Content.ReadAsStringAsync().Result;
            ptStep newPub = JsonConvert.DeserializeObject<ptStep>(body);
            items.Add(newPub);
            File.WriteAllText(path, JsonConvert.SerializeObject(items));
        }

        // PUT api/<controller>/5
        public void Put(string id, HttpRequestMessage request)
        {
            string json = File.ReadAllText(path);
            var items = JsonConvert.DeserializeObject<List<ptStep>>(json);
            string body = request.Content.ReadAsStringAsync().Result;
            ptStep updatedPub = JsonConvert.DeserializeObject<ptStep>(body);
            int index = items.IndexOf(items.Find(x => x.StepId == id));
            if (index != -1)
                items[index] = updatedPub;
            File.WriteAllText(path, JsonConvert.SerializeObject(items));
        }

        // DELETE api/<controller>/5
        public void Delete(string id)
        { 
            string json = File.ReadAllText(path);
            var items = JsonConvert.DeserializeObject<List<ptStep>>(json);
            var itemToRemove = items.Find(x => x.StepId == id);
            items.Remove(itemToRemove);
            File.WriteAllText(path, JsonConvert.SerializeObject(items));
        }
    }
}