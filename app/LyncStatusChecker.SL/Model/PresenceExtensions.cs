using LyncStatusChecker.SL.Model.Repository.Dto;

namespace LyncStatusChecker.SL.Model
{
    public static class PresenceExtensions
    {
        private const string Unknown = "Unknown";

        public static Presence ToPresence(this PresenceResult presenceResult)
        {
            return new Presence(presenceResult.SipUri, presenceResult.DisplayName, presenceResult.PresenceState);
        }

        public static bool IsUnknown(this PresenceResult presenceResult)
        {
            return presenceResult.DisplayName == Unknown && presenceResult.ActivityStatus == Unknown;
        }
    }
}