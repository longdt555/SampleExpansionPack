namespace IntegrateGoogleAuth.Utils
{
    public static class GoogleAuth
    {
        private static readonly object Locker = new object();

        #region [Declaration]
        private static string _clientId { get; set; }
        private static string _clientSecret { get; set; }
        private static string _redirectUrl { get; set; }

        #endregion [Declaration]


        public static string ClientId
        {
            get => _clientId;
            set
            {
                lock (Locker)
                {
                    _clientId = value;
                }
            }
        }

        public static string ClientSecret
        {
            get => _clientSecret;
            set
            {
                lock (Locker)
                {
                    _clientSecret = value;
                }
            }
        }

        public static string RedirectUrl
        {
            get => _redirectUrl;
            set
            {
                lock (Locker)
                {
                    _redirectUrl = value;
                }
            }
        }
    }
}
