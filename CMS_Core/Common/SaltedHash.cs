using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Security;


namespace CMS_Core.Common
{
    public class SaltedHash
    {

        private const string initVector = "mahoahaichieuMedocom";
        // This constant is used to determine the keysize of the encryption algorithm
        private const int keysize = 256;

        public static string EncryptString(string plainText, string passPhrase)
        {
            byte[] initVectorBytes = Encoding.UTF8.GetBytes(initVector);
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            PasswordDeriveBytes password = new PasswordDeriveBytes(passPhrase, null);
            byte[] keyBytes = password.GetBytes(keysize / 8);
            RijndaelManaged symmetricKey = new RijndaelManaged();
            symmetricKey.Mode = CipherMode.CBC;
            ICryptoTransform encryptor = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes);
            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);
            cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
            cryptoStream.FlushFinalBlock();
            byte[] cipherTextBytes = memoryStream.ToArray();
            memoryStream.Close();
            cryptoStream.Close();
            return Convert.ToBase64String(cipherTextBytes);
        }
        //Decrypt
        public static string DecryptString(string cipherText, string passPhrase)
        {
            byte[] initVectorBytes = Encoding.UTF8.GetBytes(initVector);
            byte[] cipherTextBytes = Convert.FromBase64String(cipherText);
            PasswordDeriveBytes password = new PasswordDeriveBytes(passPhrase, null);
            byte[] keyBytes = password.GetBytes(keysize / 8);
            RijndaelManaged symmetricKey = new RijndaelManaged();
            symmetricKey.Mode = CipherMode.CBC;
            ICryptoTransform decryptor = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes);
            MemoryStream memoryStream = new MemoryStream(cipherTextBytes);
            CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
            byte[] plainTextBytes = new byte[cipherTextBytes.Length];
            int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
            memoryStream.Close();
            cryptoStream.Close();
            return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
        }

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


        //public static string GetEncryption64(string strPlain)
        //{
        //    try
        //    {
        //        Security.Encryption64 sec = new Security.Encryption64();
        //        return sec.EncryptToBase64String(strPlain, ConfigurationManager.AppSettings["key"]);
        //    }
        //    catch
        //    {
        //        return string.Empty;
        //    }

        //}



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
