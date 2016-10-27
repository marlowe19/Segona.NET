using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace Segona.NET.Test
{
    public static class Settings
    {
        public static string ApiUrl => WebConfigurationManager.AppSettings["SegonaUrl"];
        public static string ApiKey => WebConfigurationManager.AppSettings["SegonaApiKey"];
    }
}
