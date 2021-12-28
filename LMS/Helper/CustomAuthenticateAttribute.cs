using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LMS.Helper
{
    [AllowAnonymous]
    public class CustomAuthenticateAttribute : TypeFilterAttribute
    {
        public CustomAuthenticateAttribute() : base(typeof(ClaimRequirementFilter))
        {
        }
    }
}
