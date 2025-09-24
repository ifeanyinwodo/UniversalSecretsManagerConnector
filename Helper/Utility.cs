using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace UniversalSecretsManagerConnector.Helper
{
    
    internal static class Utility
    {
        private static readonly string Key = "Your32CharEncryptionKey123456789012"; // Must be 32 chars for AES-256
        private static readonly string IV = "Your16CharInitVect"; // Must be 16 chars

        internal static void SaveEncrypted(string filePath, string plainText)
        {
            using Aes aes = Aes.Create();
            aes.Key = Encoding.UTF8.GetBytes(Key);
            aes.IV = Encoding.UTF8.GetBytes(IV);

            using var encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
            using var ms = new MemoryStream();
            using var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write);
            using var sw = new StreamWriter(cs);
            sw.Write(plainText);

            File.WriteAllBytes(filePath, ms.ToArray());
        }

        internal static string LoadEncrypted(string filePath)
        {
            byte[] encryptedData = File.ReadAllBytes(filePath);

            using Aes aes = Aes.Create();
            aes.Key = Encoding.UTF8.GetBytes(Key);
            aes.IV = Encoding.UTF8.GetBytes(IV);

            using var decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
            using var ms = new MemoryStream(encryptedData);
            using var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read);
            using var sr = new StreamReader(cs);
            return sr.ReadToEnd();
        }


        internal static string RemoveSpecialCharacters(string str)
        {
            // This pattern keeps only letters and numbers; removes everything else (including spaces)
            return Regex.Replace(str, "[^a-zA-Z0-9]", "");
        }

        internal static string GetSecretHashiCorpNameValue(string json)
        {
            JsonDocument doc = JsonDocument.Parse(json);
            string secretValue = string.Empty; // Initialize with a non-null default value
            var root = doc.RootElement;

            // Navigate to: data → data → secretName
            if (root.TryGetProperty("data", out JsonElement outerData) &&
                outerData.TryGetProperty("data", out JsonElement innerData) &&
                innerData.TryGetProperty("secretName", out JsonElement secretNameElement))
            {
                secretValue = secretNameElement.GetString() ?? string.Empty; // Ensure non-null value
            }

            return secretValue;
        }



    }

}
