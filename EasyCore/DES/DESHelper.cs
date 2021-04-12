using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace EasyCore.DES
{
    public class DESHelper
    {
        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="encryptedString"></param>
        /// <param name="keyString"></param>
        /// <returns></returns>
        public static string Decrypt(string encryptedString, string keyString)
        {
            keyString = keyString.Substring(0, 8);
            byte[] btKey = Encoding.UTF8.GetBytes(keyString);
            byte[] btIv = Encoding.UTF8.GetBytes("12345678");
            var des = new DESCryptoServiceProvider();
            des.Mode = CipherMode.CBC;//这里指定加密模式为CBC
            des.Padding = PaddingMode.PKCS7;

            des.Key = btKey;
            des.IV = btIv;

            using (var ms = new MemoryStream())
            {
                try
                {
                    byte[] inData = Convert.FromBase64String(encryptedString);
                    using (var cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(inData, 0, inData.Length);
                        cs.FlushFinalBlock();
                    }

                    return Encoding.UTF8.GetString(ms.ToArray());
                }
                catch (Exception ex)
                {
                    //return "-1";
                    throw ex;
                }
            }
        }

        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="sourceString"></param>
        /// <param name="keyString"></param>
        /// <returns></returns>
        public static string Encrypt(string sourceString, string keyString)
        {
            keyString = keyString.Substring(0, 8);
            byte[] btIv = Encoding.UTF8.GetBytes("12345678");
            byte[] btKey = Encoding.UTF8.GetBytes(keyString);
            try
            {
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                using (MemoryStream ms = new MemoryStream())
                {
                    byte[] inData = Encoding.UTF8.GetBytes(sourceString);

                    using (CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(btKey, btIv), CryptoStreamMode.Write))
                    {
                        cs.Write(inData, 0, inData.Length);
                        cs.FlushFinalBlock();
                    }

                    return Convert.ToBase64String(ms.ToArray());
                }
            }
            catch (Exception ex)
            {
                //return "-1";
                throw ex;
            }
        }
    }
}