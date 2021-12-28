using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS.Admin.UI.AuthenticateService
{
    public class CustomAuthenticateAttribute: TypeFilterAttribute
    {
        public CustomAuthenticateAttribute() : base(typeof(ClaimRequirementFilter))
        {
        }
    }
}
