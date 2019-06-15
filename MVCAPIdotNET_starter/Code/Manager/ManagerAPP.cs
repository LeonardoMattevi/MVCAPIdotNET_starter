using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Controllers;

namespace MVCAPIdotNET_starter.Code.Manager
{
    public class OrganizationAPP
    {
        public Guid InstanceGuid { get; set; }
        public string InstanceName { get; set; }
	    public string InstanceCode { get; set; }
        public string InstanceUrl { get; set; }
        public string InstanceUrlAPI { get; set; }
    }
    public static class ManagerAPP
    {
        private static List<OrganizationAPP> _APP_organizations = null;
        private static List<OrganizationAPP> OrganizationsAPP
        {
            get
            {
                if (_APP_organizations != null)
                    return _APP_organizations;

                try
                {
                    string json = "";
                    string _CurrentPath = HttpContext.Current.ApplicationInstance.Server.MapPath("~/App_Data/Instances.config.json");
                    using (StreamReader r = new StreamReader(_CurrentPath))
                    {
                        json = r.ReadToEnd();
                    }

                    _APP_organizations = JsonConvert.DeserializeObject<List<OrganizationAPP>>(json);
                }
                catch (Exception) { }

                if (_APP_organizations == null)
                    _APP_organizations = new List<OrganizationAPP>();

                return _APP_organizations;
            }
        }
        public static OrganizationAPP GetAPP_organization(string requestUrlElaborated)
        {
            OrganizationAPP organization = OrganizationsAPP.FirstOrDefault(r => r.InstanceUrlAPI.Contains(requestUrlElaborated));
            if (organization == null)
            {
                organization = OrganizationsAPP.FirstOrDefault();
            }
            return organization;
        }    
    }
    /*
    public static class ContextHelperAPP
    {
        public const string QueryStringToken = "Token";
        public const string QueryStringClientId = "ClientId";
        public const string QueryStringOrganizationId = "OrganizationId";

        public static string GetToken(HttpActionContext actionContext)
        {
            string token = "";

            try
            {
                IEnumerable<string> headerValues = actionContext.Request.Headers.GetValues(QueryStringToken);
                token = headerValues.FirstOrDefault();
            }
            catch {}


            //ToDo: Togliere x SOLO HEADER
            if (string.IsNullOrEmpty(token))
            {
                try
                {
                    var queryStringCollection = HttpUtility.ParseQueryString(actionContext.Request.RequestUri.Query);
                    token = queryStringCollection[QueryStringToken];
                }
                catch {}
            }


            if (String.IsNullOrEmpty(token))
            {
                try
                {

                    CookieHeaderValue headerValues = actionContext.Request.Headers.GetCookies(QueryStringToken).FirstOrDefault();
                    if (headerValues != null)
                        token = headerValues[QueryStringToken].Value;
                }
                catch {}
            }

            return token;
        }

        public static string GetClientId(HttpActionContext actionContext)
        {
            string clientId = "";

            try
            {
                IEnumerable<string> headerValues = actionContext.Request.Headers.GetValues(QueryStringClientId);
                clientId = headerValues.FirstOrDefault();
            }
            catch {}

            //ToDo: Togliere x SOLO HEADER
            if (string.IsNullOrEmpty(clientId))
            {
                try
                {
                    var queryStringCollection = HttpUtility.ParseQueryString(actionContext.Request.RequestUri.Query);
                    clientId = queryStringCollection[QueryStringClientId];
                }
                catch {}
            }

            if (string.IsNullOrEmpty(clientId))
            {
                try
                {
                    CookieHeaderValue headerValues =
                        actionContext.Request.Headers.GetCookies(QueryStringClientId).FirstOrDefault();
                    if (headerValues != null)
                        clientId = headerValues[QueryStringClientId].Value;
                }
                catch {}
            }

            return clientId;
        }
    }*/
}