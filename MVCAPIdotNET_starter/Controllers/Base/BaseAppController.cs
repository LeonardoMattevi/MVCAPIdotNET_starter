using MVCAPIdotNET_starter.Code.Manager;
using System;
using System.Web.Mvc;
namespace MVCAPIdotNET_starter.Controllers.Base
{
    public class BaseAppController : Controller
    {
        private static OrganizationAPP _ContextualOrganization = null;
        public static OrganizationAPP ContextualOrganization
        {
            get
            {
                if (_ContextualOrganization == null)
                    _ContextualOrganization = ManagerAPP.GetAPP_organization(System.Web.HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority));
                return _ContextualOrganization;
            }
        }
    }
}
