﻿using Microsoft.AspNetCore.Authentication;
using System;

namespace NetCoreAPIAuthenticationMiddleWareV2
{
    public static class CustomAuthExtensions
    {
        public static AuthenticationBuilder AddCustomAuth(this AuthenticationBuilder builder, Action<CustomAuthOptions> configureOptions)
        {
            return builder.AddScheme<CustomAuthOptions, CustomAuthHandler>("Custom Scheme", "Custom Auth", configureOptions);
        }
    }
}
