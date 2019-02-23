using System;
using System.Security.Cryptography;
using System.Text;

namespace Library.Classes
{
    public class Password
    {
        public string Pass { get; set; }


        public Password()
        {
        }
        public Password(string pass)
        {
            this.Pass = pass;
        }


        public override string ToString()
        {
            return ToSha256Hash(this.Pass);
        }

        public static string ToSha256Hash(string s)
        {
            if (String.IsNullOrEmpty(s)) return "";

            byte[] hash;
            // SHA256 returns a 32 byte hash.. 
            using (var sha = SHA256.Create())
            {
                hash = sha.ComputeHash(Encoding.UTF8.GetBytes(s));
            }

            var result = new StringBuilder(64);
            foreach (byte b in hash)
            {
                result.Append(b.ToString("x2"));
            }

            return result.ToString();
        }


        #region Antigos
        /// <summary>
        /// Deprecated, please use ".ToString();" method;
        /// </summary>
        public string retorno
        {
            get { return ToSha256Hash(this.Pass); }
        }

        /// <summary>
        /// Do not use it
        /// </summary>
        /// <param name="originalPassword"></param>
        /// <returns></returns>
        public string EncodePassword(string originalPassword)
        {
            //Declarations
            Byte[] originalBytes;
            Byte[] encodedBytes;
            MD5 md5 = null;

            try
            {
                //Instantiate MD5CryptoServiceProvider, get bytes for original password and compute hash (encoded password)
                md5 = new MD5CryptoServiceProvider();
                originalBytes = ASCIIEncoding.Default.GetBytes(originalPassword);
                encodedBytes = md5.ComputeHash(originalBytes);

                //Convert encoded bytes back to a 'readable' string
                return BitConverter.ToString(encodedBytes);
            }
            catch (Exception ex)
            {
                Library.Classes.Logger.Error(ex); ;
            }
            finally
            {
                md5.Dispose();
            }
            return "";
        }
        #endregion
    }
}
