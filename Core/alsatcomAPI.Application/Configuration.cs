using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alsatcomAPI.Application
{
    public static class Configuration
    {
        public static string GetRole(string role)
        {
            ConfigurationManager configurationManager = new();
            configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../Presentation/alsatcomAPI.API"));
            configurationManager.AddJsonFile("appsettings.json");
            return configurationManager[$"Roles:{role}"];
        }
    }
}
