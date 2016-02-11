using System;
using System.IO;
using System.Net;
using System.Text;

namespace Romit
{
    internal static class Requestor
    {
        public static string GetString(string url, RomitRequestOptions requestOptions)
        {
            var wr = GetWebRequest(url, "GET", requestOptions);

            return ExecuteWebRequest(wr);
        }

        public static string PostString(string url, RomitRequestOptions requestOptions)
        {
            var wr = GetWebRequest(url, "POST", requestOptions);

            return ExecuteWebRequest(wr);
        }

        public static string Delete(string url, RomitRequestOptions requestOptions)
        {
            var wr = GetWebRequest(url, "DELETE", requestOptions);

            return ExecuteWebRequest(wr);
        }

        public static string PostStringBearer(string url, RomitRequestOptions requestOptions)
        {
            var wr = GetWebRequest(url, "POST", requestOptions, true);

            return ExecuteWebRequest(wr);
        }

        internal static WebRequest GetWebRequest(string url, string method, RomitRequestOptions requestOptions, bool useBearer = false)
        {
            requestOptions.ApiKey = requestOptions.ApiKey ?? RomitConfiguration.GetApiKey();

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = method;

            request.Headers.Add("Content-Type", "application/json");
            if (!useBearer)
                request.Headers.Add("Authorization", GetAuthorizationHeaderValue(requestOptions.ApiKey));
            else
                request.Headers.Add("Authorization", GetAuthorizationHeaderValueBearer(requestOptions.ApiKey));
            return request;
        }

        private static string GetAuthorizationHeaderValue(string apiKey)
        {
            var token = Convert.ToBase64String(Encoding.UTF8.GetBytes(string.Format("{0}:", apiKey)));
            return string.Format("Basic {0}", token);
        }

        private static string GetAuthorizationHeaderValueBearer(string apiKey)
        {
            return string.Format("Bearer {0}", apiKey);
        }

        private static string ExecuteWebRequest(WebRequest webRequest)
        {
            try
            {
                using (var response = webRequest.GetResponse())
                {
                    return ReadStream(response.GetResponseStream());
                }
            }
            catch (WebException webException)
            {
                if (webException.Response != null)
                {
                    var statusCode = ((HttpWebResponse)webException.Response).StatusCode;

                    var romitError = new RomitError();

                    if (webRequest.RequestUri.ToString().Contains("oauth"))
                        romitError = Mapper<RomitError>.MapFromJson(ReadStream(webException.Response.GetResponseStream()));
                    else
                        romitError = Mapper<RomitError>.MapFromJson(ReadStream(webException.Response.GetResponseStream()), "error");

                    throw new RomitException(statusCode, romitError, romitError.Message);
                }

                throw;
            }
        }

        private static string ReadStream(Stream stream)
        {
            using (var reader = new StreamReader(stream, Encoding.UTF8))
            {
                return reader.ReadToEnd();
            }
        }

    }
}
