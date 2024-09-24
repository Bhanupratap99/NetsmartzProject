using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Data.Common
{
    public class EncryptionService
    {
        private IConfiguration _configuration;

        public EncryptionService(IConfiguration config)
        {
            _configuration = config;
        }

        public static string EncryptionKey = "PJC7LnliwcxXw4PO8Ep3sX9NIL9T5CZ=";
        public static string EncryptionVector = "s97IEtMpelScHqu=";

        public static string EncryptData(string plainText, byte[] key, byte[] iv)
        {
            try
            {
                using (Aes aesAlg = Aes.Create())
                {
                    aesAlg.Key = key;
                    aesAlg.IV = iv;

                    ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                    using (MemoryStream msEncrypt = new MemoryStream())
                    {
                        using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                        {
                            using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                            {
                                swEncrypt.Write(plainText);
                            }
                            byte[] encryptedBytes = msEncrypt.ToArray();
                            return Convert.ToBase64String(encryptedBytes);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Log exception here
                Console.WriteLine($"Error encrypting data: {ex.Message}");
                throw new InvalidOperationException("Error encrypting data.", ex);
            }
        }

        public static string DecryptData(string ciphertext, byte[] key, byte[] iv)
        {
            try
            {
                using (Aes aesAlg = Aes.Create())
                {
                    aesAlg.Key = key;
                    aesAlg.IV = iv;

                    ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                    using (MemoryStream msDecrypt = new MemoryStream(Convert.FromBase64String(ciphertext)))
                    {
                        using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                        {
                            using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                            {
                                return srDecrypt.ReadToEnd();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Log exception here
                Console.WriteLine($"Error decrypting data: {ex.Message}");
                throw new InvalidOperationException("Error decrypting data.", ex);
            }
        }

        public static string Encrypt(string plaintext)
        {
            if (string.IsNullOrEmpty(plaintext))
            {
                return "";
            }
            var randomKey = generateRandomString(31);
            var randomIV = generateRandomString(15);
            byte[] key = Encoding.ASCII.GetBytes(randomKey);
            byte[] iv = Encoding.ASCII.GetBytes(randomIV);
            var result = EncryptData(plaintext, key, iv);
            return randomKey + '$' + result + '$' + randomIV;
        }

        public static string Decrypt(string ciphertext)
        {
            try
            {
                string[] splitString = ciphertext.Split('$');
                if (splitString.Length != 3)
                {
                    throw new ArgumentException("Invalid ciphertext format.");
                }

                byte[] key = Encoding.Default.GetBytes(splitString[0]);
                byte[] iv = Encoding.Default.GetBytes(splitString[2]);
                var result = DecryptData(splitString[1], key, iv);
                return result;
            }
            catch (Exception ex)
            {
                // Log exception here
                Console.WriteLine($"Error decrypting ciphertext: {ciphertext}, Exception: {ex.Message}");
                throw new InvalidOperationException("Error decrypting data.", ex);
            }
        }

        public static string generateRandomString(int num)
        {
            var characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz=";
            Random random = new Random();
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < num; i++)
            {
                int randomIndex = random.Next(characters.Length);
                result.Append(characters[randomIndex]);
            }

            return result.ToString() + "=";
        }
    }
}
