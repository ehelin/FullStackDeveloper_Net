using Microsoft.Extensions.Configuration;
using System;

namespace FullStackDeveloper
{
    public class Utilities
    {
        public static string GetConfigValue(string key, IConfiguration config)
        {
            var section = config.GetSection(key);

            if (section == null)
            {
                throw new Exception("Config item " + key + " is null");
            }

            return section.Value;
        }
    }
}
