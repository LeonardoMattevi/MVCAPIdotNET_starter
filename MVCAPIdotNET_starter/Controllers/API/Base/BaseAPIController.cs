using MVCAPIdotNET_starter.Code.Manager;
using System;
using System.Web;
using System.Web.Http;

namespace MVCAPIdotNET_starter.Controllers.API.Base
{
    public class BaseAPIController : ApiController
    {
        private static OrganizationAPP _ContextualOrganization = null;
        public static OrganizationAPP ContextualOrganization
        {
            get
            {
                if (_ContextualOrganization == null)
                    _ContextualOrganization = ManagerAPP.GetAPP_organization(HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority));
                return _ContextualOrganization;
            }
        }
    }
}
