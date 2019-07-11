using System;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace NetCoreAPIAuthorizationFilter
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class ApiAuthorizationFilter : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            bool isAuthorized = false;

            var headers = context.HttpContext.Request.Headers;
            var auth = headers["Authorization"];

            if (!string.IsNullOrEmpty(auth))
            { 
                var authArr = auth.ToString().Split(" ");
                
                if (authArr.Length == 2) {
                    var schema = authArr[0];
                    var token = authArr[1];

                    if (schema == "NetCoreAuth" && token == "IAmAToken")
                    {
                        isAuthorized = true;
                    }
                }
            }

            if (!isAuthorized)
            {
                context.Result = new StatusCodeResult((int)System.Net.HttpStatusCode.Unauthorized);
                return;
            }
        }
    }
}