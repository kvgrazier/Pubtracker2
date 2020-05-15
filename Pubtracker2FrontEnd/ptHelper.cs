using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

namespace Pubtracker2FrontEnd
{
    public static class ptHelper
    {
        private static string svcUrl = Pubtracker2FrontEnd.Properties.Settings.Default.RestServiceUrlLocal;
       // private static string svcUrl = PubtrackerMVC.Properties.Settings.Default.RestServiceUrlRemote;
        public static IEnumerable<T> GetAll<T>(string area)
        {
            IEnumerable<T> items = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(svcUrl);
                var responseTask = client.GetStringAsync(area);
                responseTask.Wait();
                string jsonResult = JsonConvert.DeserializeObject(responseTask.Result).ToString();
                string json = jsonResult;
                items = JsonConvert.DeserializeObject<IEnumerable<T>>(jsonResult);
            }//End Using
            return items;
        }//End GetAll

        public static T GetOne<T>(string area, string id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(svcUrl);
                var responseTask = client.GetAsync(area+"/"+id);
                responseTask.Wait();
                var result = responseTask.Result;
                var readTask = result.Content.ReadAsStringAsync();
                readTask.Wait();
                string json = readTask.Result;
                T item = JsonConvert.DeserializeObject<T>(json);
                return item;
            }//End Using
        }//End GetOne

        public static Boolean DeleteOne<T>(string area, string id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(svcUrl);
                var responseTask = client.DeleteAsync(area+"/"+id);
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return true;
                }
                return false;
            }//End Using
        }//End Delete

        public static Boolean Create<T>(string area, T item)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(svcUrl);
                var stringPayload = JsonConvert.SerializeObject(item);
                var httpContent = new StringContent(stringPayload, Encoding.UTF8, "application/json");
                var responseTask = client.PostAsync(area, httpContent);
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                { return true;}
                return false;
            }//End Using
        }//End Create

        public static Boolean Edit<T>(string id, string area, T item)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(svcUrl);
                var stringPayload = JsonConvert.SerializeObject(item);
                var httpContent = new StringContent(stringPayload, Encoding.UTF8, "application/json");
                var responseTask = client.PutAsync(area+"/"+id, httpContent);
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                { return true; }
                return false;
            }//End Using
        }//End Edit

    }//End Class ptHelper
}//End Namespace