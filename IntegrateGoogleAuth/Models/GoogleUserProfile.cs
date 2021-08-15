namespace IntegrateGoogleAuth.Models
{
    public class GoogleUserProfile
    {
        private static readonly object Locker = new object();

        #region [Declaration]

        public string sub { get; set; }
        public string name { get; set; }
        public string given_name { get; set; }
        public string family_name { get; set; }
        public string link { get; set; }
        public string picture { get; set; }
        public string gender { get; set; }
        public string locale { get; set; }
        public string email { get; set; }
        public bool email_verified { get; set; }

        #endregion [Declaration]
        public string Sub
        {
            get => sub;
            set
            {
                lock (Locker)
                {
                    sub = value;
                }
            }
        }
        public string Name
        {
            get => name;
            set
            {
                lock (Locker)
                {
                    name = value;
                }
            }
        }
        public string GivenName
        {
            get => given_name;
            set
            {
                lock (Locker)
                {
                    given_name = value;
                }
            }
        }

        public string FamilyName
        {
            get => family_name;
            set
            {
                lock (Locker)
                {
                    family_name = value;
                }
            }
        }

        public string Link
        {
            get => link;
            set
            {
                lock (Locker)
                {
                    link = value;
                }
            }
        }

        public string Picture
        {
            get => picture;
            set
            {
                lock (Locker)
                {
                    picture = value;
                }
            }
        }

        public string Gender
        {
            get => gender;
            set
            {
                lock (Locker)
                {
                    gender = value;
                }
            }
        }

        public string Locale
        {
            get => locale;
            set
            {
                lock (Locker)
                {
                    locale = value;
                }
            }
        }

        public string Email
        {
            get => email;
            set
            {
                lock (Locker)
                {
                    email = value;
                }
            }
        }
        public bool EmailVerified
        {
            get => email_verified;
            set
            {
                lock (Locker)
                {
                    email_verified = value;
                }
            }
        }
    }
}
