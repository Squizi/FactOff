using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;

namespace FactOff.Attributes
{
    public class FactOffAuthorizeAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (string.IsNullOrWhiteSpace(context.HttpContext.Session.GetString("logeduser")))
            {
                context.Result = new RedirectToRouteResult(
                    new RouteValueDictionary
                    {
                        { "Controller", "Account" },
                        { "Action", "SignIn" }
                    }
                );
            }
            base.OnActionExecuting(context);
        }
    }
}
