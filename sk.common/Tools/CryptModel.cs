using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace sk.common.Tools
{
    public class CryptModel
    {
        public static byte[] EncryptRijndaelManaged(string input, byte[] key, byte[] IV)
        {
            byte[] encrypted;
            using (var rm = Aes.Create()) // new RijndaelManaged())
            {
                rm.Key = key;
                rm.IV = IV;
                ICryptoTransform encryptor = rm.CreateEncryptor(rm.Key, rm.IV);

                var ms = new MemoryStream();         
                using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                {
                    using (var swEncrypt = new StreamWriter(cs))
                    {
                        swEncrypt.Write(input);
                    }
                    encrypted = ms.ToArray();
                }
                
            }

            return encrypted;
        }

        public static string DecryptRijndaelManaged(byte[] input, byte[] key, byte[] IV)
        {
            string decrypted;
            using (var rm = Aes.Create()) //new RijndaelManaged())
            {
                rm.Key = key;
                rm.IV = IV;
                ICryptoTransform decryptor = rm.CreateDecryptor(rm.Key, rm.IV);

                var ms = new MemoryStream(input);
                var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read);

                using (var swDecrypt = new StreamReader(cs))
                {
                    decrypted = swDecrypt.ReadToEnd();
                }                                
            }

            return decrypted;
        }

        private const string initVector = "tu89geji340t89u2";
        // This constant is used to determine the keysize of the encryption algorithm.
        private const int keysize = 256;

        public static string Encrypt(string plainText, string passPhrase)
        {
            if (string.IsNullOrEmpty(plainText))
            {
                return string.Empty;
            }

            byte[] initVectorBytes = Encoding.UTF8.GetBytes(initVector);
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            Rfc2898DeriveBytes password = new Rfc2898DeriveBytes(passPhrase, null);  //PasswordDeriveBytes password = new PasswordDeriveBytes(passPhrase, null);
            byte[] keyBytes = password.GetBytes(keysize / 8);
            var symmetricKey = Aes.Create();// new RijndaelManaged();
            symmetricKey.Mode = CipherMode.CBC;
            ICryptoTransform encryptor = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes);
            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);
            cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
            cryptoStream.FlushFinalBlock();
            byte[] cipherTextBytes = memoryStream.ToArray();

            cryptoStream.Dispose(); //cryptoStream.Close();

            return Convert.ToBase64String(cipherTextBytes);
        }

        public static string Decrypt(string cipherText, string passPhrase)
        {
            if (string.IsNullOrEmpty(cipherText))
            {
                return string.Empty;
            }

            byte[] initVectorBytes = Encoding.ASCII.GetBytes(initVector);
            byte[] cipherTextBytes = Convert.FromBase64String(cipherText);
            Rfc2898DeriveBytes password = new Rfc2898DeriveBytes(passPhrase, null); //PasswordDeriveBytes password = new PasswordDeriveBytes(passPhrase, null);
            byte[] keyBytes = password.GetBytes(keysize / 8);
            var symmetricKey = Aes.Create();// new RijndaelManaged();
            symmetricKey.Mode = CipherMode.CBC;
            ICryptoTransform decryptor = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes);
            MemoryStream memoryStream = new MemoryStream(cipherTextBytes);
            CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
            byte[] plainTextBytes = new byte[cipherTextBytes.Length];
            int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);

            cryptoStream.Dispose();//.Close();
            return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
        }

    }
}
