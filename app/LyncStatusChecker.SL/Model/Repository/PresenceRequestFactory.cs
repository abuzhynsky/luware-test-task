using RestSharp;

namespace LyncStatusChecker.SL.Model.Repository
{
    public static class PresenceRequestFactory
    {
        public static RestRequest Create(string sipUri)
        {
            var request = new RestRequest("WIS_HttpBinding/GetPresence", Method.GET);
            request.AddParameter("contactName", sipUri, ParameterType.GetOrPost);

            return request;
        }
    }
}