namespace LyncStatusChecker.SL.Model.Repository.Dto
{
    public class PresenceResult
    {
        public string ActivityStatus { get; set; }

        public string DisplayName { get; set; }

        public string Notes { get; set; }

        public string PictureUrl { get; set; }

        public int PresenceState { get; set; }

        public string SipUri { get; set; }
    }
}