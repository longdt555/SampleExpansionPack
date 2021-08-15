using System;

namespace IntegrateGoogleAuth.Models
{
    public class GoogleAccessToken
    {
        private static readonly object Locker = new object();

        #region [Declaration]
        public string access_token { get; set; }
        public string token_type { get; set; }
        public int expires_in { get; set; }
        public string id_token { get; set; }
        public string scope { get; set; }
        public string refresh_token { get; set; }
        public DateTime CreatedTime { get; set; }

        #endregion [Declaration]


        public string AccessToken
        {
            get => access_token;
            set
            {
                lock (Locker)
                {
                    access_token = value;
                }
            }
        }
        public string TokenType
        {
            get => token_type;
            set
            {
                lock (Locker)
                {
                    token_type = value;
                }
            }
        }
        public int ExpiresIn
        {
            get => expires_in;
            set
            {
                lock (Locker)
                {
                    expires_in = value;
                }
            }
        }
        public string Scope
        {
            get => scope;
            set
            {
                lock (Locker)
                {
                    scope = value;
                }
            }
        }
        public string IdToken
        {
            get => id_token;
            set
            {
                lock (Locker)
                {
                    id_token = value;
                }
            }
        }
        public string RefreshToken
        {
            get => refresh_token;
            set
            {
                lock (Locker)
                {
                    refresh_token = value;
                }
            }
        }
    }
}
