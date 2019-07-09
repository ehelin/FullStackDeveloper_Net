﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Text;

namespace WebApi
{
    public class ApiAuthenticationFilter
    {
        private readonly RequestDelegate _next;

        public ApiAuthenticationFilter(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            string auth = context.Request.Headers["Authorization"];

            if (!string.IsNullOrEmpty(auth))
            {
                var authArr = auth.ToString().Split(" ");

                if (authArr.Length == 2)
                {
                    var schema = authArr[0];
                    var token = authArr[1];

                    if (schema == "NetCoreAuth" && token == "IAmAToken")
                    {
                        //return;
                        await _next.Invoke(context);
                        return;
                    }
                }
            }

            context.Response.StatusCode = 401;
            return;
        }
    }
}
