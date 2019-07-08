using System;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace WebApi 
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class ApiAuthenticationFilter : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            bool isAuthenticated = false;

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
                        isAuthenticated = true;
                    }
                }
            }

            if (!isAuthenticated)
            {
                context.Result = new StatusCodeResult((int)System.Net.HttpStatusCode.Unauthorized);
                return;
            }
        }
    }
}