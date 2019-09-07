﻿using IdentityServer3.Core.Models;
using System.Collections.Generic;

namespace ClassicNetWeb.IdentityServer
{
    public static class Clients
    {
        public static IEnumerable<Client> Get()
        {
            return new[]
            {
            new Client
            {
                Enabled = true,
                ClientName = "MVC Client",
                ClientId = "mvc",
                Flow = Flows.Implicit,

                RedirectUris = new List<string>
                {
                    "https://localhost:44319/"
                },

                AllowAccessToAllScopes = true
            }
        };
        }
    }
}