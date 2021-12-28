using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Admin.UI.Helpers
{

    /// <summary>
    /// This is singleton class which is used to perform the password encryption and decryption.
    /// </summary>
    public sealed class PasswordEncryptor
    {
        /// <summary>
        ///     Create Singleton class
        /// </summary>
        private static volatile PasswordEncryptor passwordEncrypter;

        /// <summary>
        /// Make the constructor private so that we can not able to create the instance out side the class.
        /// </summary>
        private PasswordEncryptor()
        {
        }

        /// <summary>
        /// Create the instance of the class inside the class.
        /// </summary>
        public static PasswordEncryptor Instance
        {
            get
            {
                if (passwordEncrypter != null)
                {
                    return passwordEncrypter;
                }

                lock (typeof(PasswordEncryptor))
                {
                    if (passwordEncrypter == null)
                    {
                        passwordEncrypter = new PasswordEncryptor();
                    }
                }

                return passwordEncrypter;
            }
        }

        /// <summary>
        /// Method to perform the password encryption
        /// </summary>
        /// <param name="textToEncode"></param>
        /// <param name="encryptionKey"></param>
        /// <returns></returns>
        public string Encrypt(string textToEncode, string encryptionKey)
        {
            byte[] clearBytes = Encoding.Unicode.GetBytes(textToEncode);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(encryptionKey, new byte[]
                {
                            0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76
                });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    textToEncode = Convert.ToBase64String(ms.ToArray());
                }
            }
            return textToEncode;
        }

        /// <summary>
        /// Method to perform the password decryption
        /// </summary>
        /// <param name="textToDecode"></param>
        /// <param name="encryptionKey"></param>
        /// <returns></returns>
        public string Decrypt(string textToDecode, string encryptionKey)
        {
            if (!string.IsNullOrEmpty(textToDecode))
            {
                textToDecode = textToDecode?.Replace(" ", "+");
                byte[] cipherBytes = Convert.FromBase64String(textToDecode);
                using (Aes encryptor = Aes.Create())
                {
                    Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(encryptionKey, new byte[] {
                                0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76
                     });
                    encryptor.Key = pdb.GetBytes(32);
                    encryptor.IV = pdb.GetBytes(16);
                    using (MemoryStream ms = new MemoryStream())
                    {
                        using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                        {
                            cs.Write(cipherBytes, 0, cipherBytes.Length);
                            cs.Close();
                        }
                        textToDecode = Encoding.Unicode.GetString(ms.ToArray());
                    }
                }
            }
            return textToDecode;
        }
    }
}
