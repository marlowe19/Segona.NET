using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Segona.Net.Application.Attributes;

namespace Segona.Net.Application
{
    public class RequestSettingsFluent
    {
        private RequestSettings settings = new RequestSettings();
     
        public RequestSettingsFluent SearchSegonaFor(string searchKeyword)
        {
            settings.QueryString = searchKeyword;

            return this;
        }

        public RequestSettingsFluent LimitResultsTo(string limit)
        {
            settings.Limit = limit;

            return this;
        }

        public void ApiKey(string limit)
        {
            settings.Limit = limit;
        }



    }
}