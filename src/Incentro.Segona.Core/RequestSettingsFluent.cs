namespace Incentro.Segona.Core
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