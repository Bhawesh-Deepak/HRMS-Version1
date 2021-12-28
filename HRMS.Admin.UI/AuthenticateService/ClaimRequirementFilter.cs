using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace HRMS.Admin.UI.AuthenticateService
{
    public  class ClaimRequirementFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var url = context.HttpContext.Request.GetDisplayUrl();

            if (context.HttpContext.Session.GetString("StoreId") == null)
            {
                context.Result = new RedirectToActionResult("StoreSelectionView", "Account", null);
            }

            if (context.HttpContext.Session.GetString("userRights") == null)
            {
                context.Result = new RedirectToActionResult("GetLoginPopUp", "Account", new
                {
                    returnUrl = url
                });
            }
            else
            {
                RemoveSessionForNonDispensingPage(url, context);
            }
            //}
        }

        public void RemoveSessionForNonDispensingPage(string url, AuthorizationFilterContext context)
        {
            string[] urlParts = url.Split('/');

            if (urlParts[3] != "Dispensing" && !string.IsNullOrEmpty(context.HttpContext.Session.GetString("PatientId")))
            {
                //Comment By Manvendra Singh
                //context.HttpContext.Session.Remove("PatientId");
            }
        }
    }
}