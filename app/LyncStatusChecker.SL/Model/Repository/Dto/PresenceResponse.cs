using RestSharp.Deserializers;

namespace LyncStatusChecker.SL.Model.Repository.Dto
{
    public class PresenceResponse
    {
        [DeserializeAs(Name = "GetEndpointPresenceResult")]
        public PresenceResult PresenceResult { get; set; }
    }
}