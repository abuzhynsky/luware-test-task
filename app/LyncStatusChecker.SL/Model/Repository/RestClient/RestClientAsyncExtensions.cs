using System;
using System.Threading;
using System.Threading.Tasks;
using RestSharp;

namespace LyncStatusChecker.SL.Model.Repository.RestClient
{
    //code from RestSharp project 
    //Added because Silverlight version of RestSharp lacks GetTaskAsync method

    public static class RestClientAsyncExtensions
    {
        public static Task<T> GetAsync<T>(this IRestClient client, RestRequest request)
        {
            return client.ExecuteGetTaskAsync<T>(request).ContinueWith(x => x.Result.Data);
        }

        private static Task<IRestResponse<T>> ExecuteGetTaskAsync<T>(this IRestClient client, IRestRequest request)
        {
            return client.ExecuteGetTaskAsync<T>(request, CancellationToken.None);
        }

        private static Task<IRestResponse<T>> ExecuteGetTaskAsync<T>(this IRestClient client, IRestRequest request, CancellationToken token)
        {
            if (request == null)
            {
                throw new ArgumentNullException("request");
            }

            request.Method = Method.GET;
            return client.ExecuteTaskAsync<T>(request, token);
        }

        private static Task<IRestResponse<T>> ExecuteTaskAsync<T>(this IRestClient client, IRestRequest request, CancellationToken token)
        {
            if (request == null)
            {
                throw new ArgumentNullException("request");
            }

            var taskCompletionSource = new TaskCompletionSource<IRestResponse<T>>();
            try
            {
                var async = client.ExecuteAsync<T>(request, (response, _) =>
                {
                    if (token.IsCancellationRequested)
                    {
                        taskCompletionSource.TrySetCanceled();
                    }
                    else
                    {
                        taskCompletionSource.TrySetResult(response);
                    }
                });

                var registration = token.Register(() =>
                {
                    async.Abort();
                    taskCompletionSource.TrySetCanceled();
                });

                taskCompletionSource.Task.ContinueWith(t => registration.Dispose(), token);
            }
            catch (Exception ex)
            {
                taskCompletionSource.TrySetException(ex);
            }

            return taskCompletionSource.Task;
        }
    }
}