using System;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace ClassicNetWebApi
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
    public class MyAuthorizationFilter : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            var auth = actionContext.Request.Headers.Authorization;

            if (auth == null || string.IsNullOrEmpty(auth.Scheme) || auth.Scheme != "IAmAToken")
            {
                actionContext.Response = new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized);
            }

            base.OnAuthorization(actionContext);
        }
    }
}