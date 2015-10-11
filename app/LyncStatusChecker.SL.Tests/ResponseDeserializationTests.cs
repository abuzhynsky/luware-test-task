using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using LyncStatusChecker.SL.Model.Repository;
using LyncStatusChecker.SL.Model.Repository.Dto;
using LyncStatusChecker.SL.Model.Repository.RestClient;
using RestSharp;
using Xunit;

namespace LyncStatusChecker.SL.Tests
{
    public class ResponseDeserializationTests
    {
        private const string ServiceUrl = "http://starmind.luware.net:9310";
        private readonly IRestClient _client;

        public ResponseDeserializationTests()
        {
            _client = new RestClient(ServiceUrl);
        }

        [Theory]
        [MemberData(nameof(ExpectedResults))]
        public async Task ShouldDeserializeSuccessfully(PresenceResult expectedResult)
        {
            var request = PresenceRequestFactory.Create(expectedResult.SipUri);

            var response = await _client.GetResponseContentAsync<PresenceResponse>(request);

            Assert.NotNull(response);
            Assert.NotNull(response.PresenceResult);

            var presense = response.PresenceResult;

            presense.ShouldBeEquivalentTo(expectedResult);
        }

        public static IEnumerable<object[]> ExpectedResults
        {
            get
            {
                yield return new object[] 
                {
                    new PresenceResult
                    {
                        ActivityStatus = "Away",
                        DisplayName = "Michael Jakob",
                        Notes = string.Empty,
                        PictureUrl = string.Empty,
                        PresenceState = 15500,
                        SipUri = "sip:mjakob@luware.net"
                    }
                };

                yield return new object[] 
                {
                    new PresenceResult
                    {
                        ActivityStatus = "Unknown",
                        DisplayName = "Unknown",
                        Notes = string.Empty,
                        PictureUrl = null,
                        PresenceState = 0,
                        SipUri = "test"
                    }
                };
            }
        }
    }
}
