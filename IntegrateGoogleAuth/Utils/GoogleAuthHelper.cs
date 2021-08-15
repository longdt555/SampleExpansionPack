using System;
using System.IO;
using System.Net;
using System.Text;
using IntegrateGoogleAuth.Models;
using Newtonsoft.Json;

namespace IntegrateGoogleAuth.Utils
{
    public static class GoogleAuthHelper
    {
        public static readonly string BaseTokenUri = "https://accounts.google.com/o/oauth2/token";
        public static readonly string BaseUserInfoUri = "https://www.googleapis.com/oauth2/v3/userinfo";
        public static Uri GetAuthenticationUri(string clientId, string redirectUri)
        {
            const string scopes = "https://www.googleapis.com/auth/userinfo.email https://www.googleapis.com/auth/userinfo.profile";

            if (string.IsNullOrEmpty(redirectUri))
            {
                redirectUri = "urn:ietf:wg:oauth:2.0:oob";
            }
            var oauth =
                $"https://accounts.google.com/o/oauth2/auth?client_id={clientId}&redirect_uri={redirectUri}&scope={scopes}&response_type=code";
            return new Uri(oauth);
        }

        public static GoogleAccessToken GetGoogleAccess(string code)
        {
            var queryString = $@"grant_type=authorization_code&code={code}&client_id={GoogleAuth.ClientId}&client_secret={GoogleAuth.ClientSecret}&redirect_uri={GoogleAuth.RedirectUrl}";
            var bytes = Encoding.ASCII.GetBytes(queryString);

            var request = (HttpWebRequest)WebRequest.Create(BaseTokenUri);
            request.ContentType = "application/x-www-form-urlencoded";
            request.Method = "POST";
            request.ContentLength = bytes.Length;

            try
            {
                using (var stream = request.GetRequestStream())
                {
                    stream.Write(bytes, 0, bytes.Length);
                }

                var response = (HttpWebResponse)request.GetResponse();
                var responseString = new StreamReader(response.GetResponseStream()!).ReadToEnd();

                return ExchangeGoogleAccessToken(responseString);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static GoogleUserProfile GetUserProfile(string accessToken)
        {
            var queryString = $@"access_token={accessToken}";
            var bytes = Encoding.ASCII.GetBytes(queryString);

            var request = (HttpWebRequest)WebRequest.Create(BaseUserInfoUri);
            request.ContentType = "application/x-www-form-urlencoded";
            request.Method = "POST";
            request.ContentLength = bytes.Length;

            try
            {
                using (var stream = request.GetRequestStream())
                {
                    stream.Write(bytes, 0, bytes.Length);
                }

                var response = (HttpWebResponse)request.GetResponse();
                var responseString = new StreamReader(response.GetResponseStream()!).ReadToEnd();

                return ExchangeGoogleUserProfile(responseString);
            }
            catch (Exception)
            {
                return null;
            }
        }

        #region [Private functions helper]

        private static GoogleAccessToken ExchangeGoogleAccessToken(string response)
        {
            var result = JsonConvert.DeserializeObject<GoogleAccessToken>(response);
            result.CreatedTime = DateTime.Now;   // DateTime.Now.Add(new TimeSpan(-2, 0, 0)); //For testing force refresh.
            return result;
        }

        private static GoogleUserProfile ExchangeGoogleUserProfile(string response)
        {
            return JsonConvert.DeserializeObject<GoogleUserProfile>(response);
        }

        #endregion [Private functions helper]
    }
}
