using System;
using LyncStatusChecker.SL.Model.Enum;

namespace LyncStatusChecker.SL.Model
{
    public class Presence
    {
        public Presence(string sipUri, string displayName, int state)
        {
            if (string.IsNullOrEmpty(sipUri))
            {
                throw new ArgumentNullException(nameof(sipUri));
            }

            if (string.IsNullOrEmpty(displayName))
            {
                throw new ArgumentNullException(nameof(displayName));
            }

            SipUri = sipUri;
            DisplayName = displayName;

            State = state.ToLyncStatus();
        }

        public string SipUri { get; }
        
        public string DisplayName { get; }

        public LyncStatus State { get; }
    }
}