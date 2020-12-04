using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Security;

namespace CMSLIS.Common
{
    public class SaltedHash
    {
        static public bool ValidatePassword(string password, string saltedHash)
        {
            // Extract hash and salt string
            string saltString = saltedHash.Substring(saltedHash.Length - 24);
            string hash1 = saltedHash.Substring(0, saltedHash.Length - 24);

            // Append the salt string to the password
            string saltedPassword = password + saltString;

            // Hash the salted password
            string hash2 = FormsAuthentication.HashPasswordForStoringInConfigFile
                (saltedPassword, "SHA1");

            // Compare the hashes
            return (hash1.CompareTo(hash2) == 0);
        }




        static public string CreateSaltedPasswordHash(string password)
        {
            // Generate random salt string
            RNGCryptoServiceProvider csp = new RNGCryptoServiceProvider();
            byte[] saltBytes = new byte[16];
            csp.GetNonZeroBytes(saltBytes);
            string saltString = Convert.ToBase64String(saltBytes);

            // Append the salt string to the password
            string saltedPassword = password + saltString;

            // Hash the salted password
            string hash = FormsAuthentication.HashPasswordForStoringInConfigFile
                (saltedPassword, "SHA1");

            // Append the salt to the hash
            string saltedHash = hash + saltString;



            return saltedHash;
        }
        static public string EncodeMD5(string s)
        {
            MD5CryptoServiceProvider md5Hasher = new MD5CryptoServiceProvider();
            byte[] hashedDataBytes;
            UTF8Encoding encoder = new UTF8Encoding();
            hashedDataBytes = md5Hasher.ComputeHash(encoder.GetBytes(s));
            StringBuilder sb = new StringBuilder();
            foreach (byte b in hashedDataBytes)
            {
                sb.Append(b.ToString("x2").ToLower());
            }
            if (md5Hasher is IDisposable)
                ((IDisposable)md5Hasher).Dispose();

            return sb.ToString();
        }
        private static byte[] Unicode2Bytes(String strUnicode)
        {
            Encoding unicode = Encoding.UTF8;
            return unicode.GetBytes(strUnicode);
        }
        private static String Bytes2Unicode(byte[] unicodeBytes)
        {
            Decoder utf8Decoder = Encoding.UTF8.GetDecoder();
            int charCount = utf8Decoder.GetCharCount(unicodeBytes, 0, unicodeBytes.Length);
            Char[] chars = new Char[charCount];
            int charsDecodedCount = utf8Decoder.GetChars(unicodeBytes, 0, unicodeBytes.Length, chars, 0);
            String strUnicode = new String(chars);
            return strUnicode;
        }



        public static string ComputeSha256Hash(string rawData)
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }


        public static string GenerateSHA512String(string inputString)
        {
            SHA512 sha512 = SHA512Managed.Create();
            byte[] bytes = Encoding.UTF8.GetBytes(inputString);
            byte[] hash = sha512.ComputeHash(bytes);
            return GetStringFromHash(hash).ToLower();
        }

        private static string GetStringFromHash(byte[] hash)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                result.Append(hash[i].ToString("X2"));
            }
            return result.ToString();
        }


        public static string GetSHA512(string strPlain)
        {
            UnicodeEncoding UE = new UnicodeEncoding();
            byte[] HashValue, MessageBytes = UE.GetBytes(strPlain);
            SHA512Managed SHhash = new SHA512Managed();
            string strHex = "";

            HashValue = SHhash.ComputeHash(MessageBytes);
            foreach (byte b in HashValue)
            {
                strHex += String.Format("{0:x2}", b);
            }
            if (SHhash is IDisposable)
                ((IDisposable)SHhash).Dispose();
            return strHex;
        }


        public static string GetEncryption64(string strPlain)
        {
            try
            {
                //Security.Encryption64 sec = new Security.Encryption64();
                //return sec.EncryptToBase64String(strPlain, ConfigurationManager.AppSettings["key"]);
                return string.Empty;
            }
            catch
            {
                return string.Empty;
            }

        }



        public static string From64StringToUnicode(string s)
        {
            byte[] t = Convert.FromBase64String(s);
            return Bytes2Unicode(t);
        }
        public static string UnicodeTo64String(string s)
        {
            byte[] t = Unicode2Bytes(s);
            return Convert.ToBase64String(t);
        }


    }
}