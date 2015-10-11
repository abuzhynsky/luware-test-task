using System;

namespace LyncStatusChecker.SL.Model.Exceptions
{
    public class UserNotFoundException : Exception
    {
        public UserNotFoundException(string sipUri): base($"User with sip uri {sipUri} wasn't found")
        {
        }
    }
}