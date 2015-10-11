using System;

namespace LyncStatusChecker.SL.Model.Exceptions
{
    public class UserNotFoundException : Exception
    {
        public UserNotFoundException(string sipUri): base($"User with {sipUri} wasn't found")
        {
        }
    }
}