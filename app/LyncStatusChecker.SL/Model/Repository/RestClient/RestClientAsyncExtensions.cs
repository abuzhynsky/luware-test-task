using System.Diagnostics;
using System.Threading.Tasks;
using RestSharp;

namespace LyncStatusChecker.SL.Model.Repository.RestClient
{
    public static class RestClientAsyncExtensions
    {
        public static Task<T> GetResponseContentAsync<T>(this IRestClient client, RestRequest request) where T : new()
        {
            var taskCompletionSource = new TaskCompletionSource<T>();

            client.GetAsync<T>(request, (response, handle) =>
            {
                taskCompletionSource.SetResult(response.Data);

                if (response.ErrorException != null)
                {
                    Debug.WriteLine($"Exception during web service call: {response.ErrorException}");
                }
            });

            return taskCompletionSource.Task;
        }
    }
}