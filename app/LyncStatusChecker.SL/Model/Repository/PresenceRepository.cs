using System;
using System.Threading.Tasks;
using LyncStatusChecker.SL.Model.Exceptions;
using LyncStatusChecker.SL.Model.Repository.Dto;
using LyncStatusChecker.SL.Model.Repository.RestClient;
using RestSharp;

namespace LyncStatusChecker.SL.Model.Repository
{
    public class PresenceRepository : IPresenceRepository
    {
        private readonly IRestClient _restClient;

        public PresenceRepository(IRestClient restClient)
        {
            if (restClient == null)
            {
                throw new ArgumentNullException(nameof(restClient));
            }

            _restClient = restClient;
        }

        public async Task<PresenceResult> Get(string sipUri)
        {
            var request = PresenceRequestFactory.Create(sipUri);

            var result = await _restClient.GetResponseContentAsync<PresenceResponse>(request);

            if (result == null)
            {
                throw new ServiceUnavailableException(_restClient.BaseUrl);
            }

            return result.PresenceResult;
        }
    }
}