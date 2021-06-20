using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestUngDung.Common
{
    public class Encryptor
    {
        public static string EncryptorMD5(string toEncrypt)
        {
            System.Text.UTF8Encoding ue = new System.Text.UTF8Encoding();
            byte[] bytes = ue.GetBytes(toEncrypt);
            System.Security.Cryptography.MD5CryptoServiceProvider md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] hashBytes = md5.ComputeHash(bytes);
            string hashStr = "";
            foreach (var i in hashBytes)
            {
                hashStr += Convert.ToString(i, 16).PadLeft(2, '0');
            }
            return hashStr.PadLeft(32, '0');
        }
    }
}