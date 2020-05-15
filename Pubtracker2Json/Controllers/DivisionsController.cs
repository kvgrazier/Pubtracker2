using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.IO;
using System.Web.Http;
using Pubtracker2Json.Models;

namespace Pubtracker2Json.Controllers
{
    public class DivisionsController : ApiController
    {
        private string path = System.Web.HttpContext.Current.Server.MapPath("~/Json/") + "Divisions.json";
        // GET: api/Divisions
        public string Get()
        {
            string json = File.ReadAllText(path);
            //var items = JsonConvert.DeserializeObject<List<ptDivision>>(json);
            //string rtnjson = JsonConvert.SerializeObject(items.FindAll(x => x.Active == true));
            return json ;
        }

        // GET: api/Divisions/5
        public string Get(string id)
        {
            string json = File.ReadAllText(path);
            var items = JsonConvert.DeserializeObject<List<ptDivision>>(json);
            return JsonConvert.SerializeObject(items.Find(o => o.DivisionId==id));
        }

        // POST: api/Divisions
        public void Post(HttpRequestMessage request)
        {
            string json = File.ReadAllText(path);
            var items = JsonConvert.DeserializeObject<List<ptDivision>>(json);
            string body = request.Content.ReadAsStringAsync().Result;
            ptDivision newPub = JsonConvert.DeserializeObject<ptDivision>(body);
            items.Add(newPub);
            File.WriteAllText(path, JsonConvert.SerializeObject(items));
        }

        // PUT: api/Divisions/5
        public void Put(string id, HttpRequestMessage request)
        {
            string json = File.ReadAllText(path);
            var items = JsonConvert.DeserializeObject<List<ptDivision>>(json);
            string body = request.Content.ReadAsStringAsync().Result;
            ptDivision updatedPub = JsonConvert.DeserializeObject<ptDivision>(body);
            int index = items.IndexOf(items.Find(x => x.DivisionId == id));
            if (index != -1)
                items[index] = updatedPub;
            File.WriteAllText(path, JsonConvert.SerializeObject(items));
        }

        public void Delete(string id)
        {
            string json = File.ReadAllText(path);
            var items = JsonConvert.DeserializeObject<List<ptDivision>>(json);
            var itemToRemove = items.Find(x => x.DivisionId == id);
            items.Remove(itemToRemove);
            File.WriteAllText(path, JsonConvert.SerializeObject(items));
        }
    }
}
