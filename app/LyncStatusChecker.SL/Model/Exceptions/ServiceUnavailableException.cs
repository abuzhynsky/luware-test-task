using System;

namespace LyncStatusChecker.SL.Model.Exceptions
{
    public class ServiceUnavailableException : Exception
    {
        public ServiceUnavailableException(Uri uri) : base($"Unable to get data from service: {uri}")
        {
        }
    }
}