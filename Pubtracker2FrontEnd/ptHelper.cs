using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using Pubtracker2FrontEnd.Models;

namespace Pubtracker2FrontEnd
{
    public static class ptHelper
    {
       // private static string svcUrl = Pubtracker2FrontEnd.Properties.Settings.Default.RestServiceUrlLocal;
        private static string svcUrl = Pubtracker2FrontEnd.Properties.Settings.Default.RestServiceUrlRemote;
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
                var responseTask = client.GetStringAsync(area+"/"+id);
                responseTask.Wait();
                string jsonResult = JsonConvert.DeserializeObject(responseTask.Result).ToString();
                string json = jsonResult;
                //var result = responseTask.Result;
                //var readTask = result.Content.ReadAsStringAsync();
                //readTask.Wait();
                //string json = readTask.Result;
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

        public static PublicationViewModel BlankPubVM()
        {
            PublicationViewModel pm = new PublicationViewModel();
            pm.vmPublication = new ptPublication();
            pm.slDivision = slDivisions();
            pm.slRole = slRoles();
            pm.slStep = slSteps();
            pm.slType = slTypes();
            pm.slUser = slUsers();
            List<ptPublication> p = GetAll<ptPublication>("publications").ToList<ptPublication>();
            var maxID = (from max in p
                            where !String.IsNullOrEmpty(max.PublicationId)
                            select Convert.ToInt32(max.PublicationId)).Max();
            int ipubid = maxID + 1;
            pm.vmPublication.PublicationId = ipubid.ToString();
            return pm;
        }//End BlankPubVM

        public static PublicationViewModel EditPubVM(string pubid )
        {
            PublicationViewModel pm = new PublicationViewModel();
            pm.vmPublication = GetOne<ptPublication>("publications", pubid);
            pm.SelectedDivisionId = pm.vmPublication.Division.DivisionId;
            pm.slDivision = slDivisions();
            pm.slRole = slRoles();
            pm.slStep = slSteps();
            pm.SelectedTypeId = pm.vmPublication.Type.TypeId;
            pm.slType = slTypes();
            pm.slUser = slUsers();
            pm.NowTime = DateTime.Now.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss");
            return pm;
        }//End Edit PubVM
        private static IEnumerable<SelectListItem> slDivisions()
        {
            List<ptDivision> div = Pubtracker2FrontEnd.ptHelper.GetAll<ptDivision>("divisions").ToList<ptDivision>();
            var items = div.FindAll(d=>d.Active==true).Select(x =>
                        new SelectListItem
                        {
                            Value = x.DivisionId,
                            Text = x.DivisionName
                        });
            return new SelectList(items, "Value", "Text");
        }//end slDivisions

        private static IEnumerable<SelectListItem> slRoles()
        {
            List<ptRole> div = Pubtracker2FrontEnd.ptHelper.GetAll<ptRole>("roles").ToList<ptRole>();
            var items = div.FindAll(d => d.Active == true).Select(x =>
                            new SelectListItem
                            {
                                Value = x.RoleId,
                                Text = x.RoleName
                            });
            return new SelectList(items, "Value", "Text");
        }

        private static IEnumerable<SelectListItem> slSteps()
        {
            List<ptStep> div = Pubtracker2FrontEnd.ptHelper.GetAll<ptStep>("Steps").ToList<ptStep>();
            var items = div.FindAll(d => d.Active == true).Select(x =>
                            new SelectListItem
                            {
                                Value = x.StepId,
                                Text = x.StepName
                            });
            return new SelectList(items, "Value", "Text");
        }

        private static IEnumerable<SelectListItem> slTypes()
        {
            List<ptType> div = Pubtracker2FrontEnd.ptHelper.GetAll<ptType>("Types").ToList<ptType>();
            var items = div.FindAll(d => d.Active == true).Select(x =>
                            new SelectListItem
                            {
                                Value = x.TypeId,
                                Text = x.TypeName
                            });
            return new SelectList(items, "Value", "Text");
        }

        private static IEnumerable<SelectListItem> slUsers()
        {
            List<ptUser> div = Pubtracker2FrontEnd.ptHelper.GetAll<ptUser>("Users").ToList<ptUser>();
            var items = div.FindAll(d => d.Active == true).Select(x =>
                            new SelectListItem
                            {
                                Value = x.UserId,
                                Text = x.UserId
                            });
            return new SelectList(items, "Value", "Text");
        }

    }//End Class ptHelper
}//End Namespace