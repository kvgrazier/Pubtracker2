using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using Pubtracker2Sql.Models;
using System.IO;
using System.Net.Http;
using System.Linq;

namespace Pubtracker2Sql.Controllers
{
    public class PublicationsController : ApiController
    {

        public string Get()
        {
            return ptsHelper.GetAllPublicationsAsJson();
        }

        // GET: api/Publications/5
        public string Get(string id)
        {
            return ptsHelper.GetOnePublicationAsJson(id);
        }

        // POST: api/Publications
        public void Post(HttpRequestMessage request)
        {
            string body = request.Content.ReadAsStringAsync().Result;
            ptPublication newPub = JsonConvert.DeserializeObject<ptPublication>(body);
            ptsHelper.CreatePublication(newPub);
        }

        // PUT: api/Publications/5
        public void Put(string id, HttpRequestMessage request)
        {
            string body = request.Content.ReadAsStringAsync().Result;
            ptPublication newPub = JsonConvert.DeserializeObject<ptPublication>(body);
            ptsHelper.UpdatePublication(newPub);
        }

        // DELETE: api/Publications/5
        public void Delete(string id)
        {
            ptsHelper.DeletePublication(id);
        }
    }
}
