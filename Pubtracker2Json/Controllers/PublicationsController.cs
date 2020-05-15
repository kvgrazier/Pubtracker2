using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using Pubtracker2Json.Models;
using System.IO;
using System.Net.Http;

namespace Pubtracker2Json.Controllers
{
    public class PublicationsController : ApiController
    {
        private string path = System.Web.HttpContext.Current.Server.MapPath("~/Json/") + "Publications.json";
        // GET: api/Publications
        public string Get()
        {
            string rtnjson = File.ReadAllText(path);
            return rtnjson;
        }

        // GET: api/Publications/5
        public string Get(string id)
        {
            string json = File.ReadAllText(path);
            var items = JsonConvert.DeserializeObject<List<ptPublication>>(json);
            string rtnjson = JsonConvert.SerializeObject(items.Find(x=>x.PublicationId==id));
            return  rtnjson ;
        }

        // POST: api/Publications
        public void Post(HttpRequestMessage request)
        {
            string json = File.ReadAllText(path);
            var items = JsonConvert.DeserializeObject<List<ptPublication>>(json);
            string body = request.Content.ReadAsStringAsync().Result;
            ptPublication newPub = JsonConvert.DeserializeObject<ptPublication>(body);
            items.Add(newPub);
            File.WriteAllText(path, JsonConvert.SerializeObject(items));
        }

        // PUT: api/Publications/5
        public void Put(string id, HttpRequestMessage request)
        {
            string json = File.ReadAllText(path);
            var items = JsonConvert.DeserializeObject<List<ptPublication>>(json);
            string body = request.Content.ReadAsStringAsync().Result;
            ptPublication updatedPub = JsonConvert.DeserializeObject<ptPublication>(body);
            int index = items.IndexOf(items.Find(x => x.PublicationId == id));
            if (index != -1)
                items[index] = updatedPub;
            File.WriteAllText(path, JsonConvert.SerializeObject(items));
        }

        // DELETE: api/Publications/5
        public void Delete(string id)
        {
            string json = File.ReadAllText(path);
            var items = JsonConvert.DeserializeObject<List<ptPublication>>(json);
            var itemToRemove = items.Find(x => x.PublicationId == id);
            items.Remove(itemToRemove);
            File.WriteAllText(path, JsonConvert.SerializeObject(items));
        }
    }
}
