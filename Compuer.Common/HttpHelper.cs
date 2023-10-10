using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compuer.Common
{
    public static class HttpHelper
    {
        public static string WebPost(string url, string baseUrl, string dataJson)
        {
            try
            {
                //"/api/Home/GetList"
                var options = new RestClientOptions(url)
                {
                    MaxTimeout = -1,
                };
                var client = new RestClient(options);
                var request = new RestRequest(baseUrl, Method.Post);
                request.AddHeader("Content-Type", "application/json");

                request.AddStringBody(dataJson, DataFormat.Json);
                var response = client.ExecuteAsync(request).Result;
                return response.Content;
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }
    }
}
