using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversalSecretsManagerConnector.Helper;

namespace UniversalSecretsManagerConnector.SecretsManagerConnector.HashiCorp
{
    internal class SecretWriter
    {
        internal static async Task SetSecretAsync(string vaultAddress, string vaultToken, string secretName, string secretValue)
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri(vaultAddress);
            client.DefaultRequestHeaders.Add("X-Vault-Token", vaultToken);

            secretName = Utility.RemoveSpecialCharacters(secretName);
            string secretPath = "secret/data/allapps/" + secretName;
            var secretData = new
            {
                data = new
                {
                    secretName = secretValue
                }
            };

            var content = new StringContent(System.Text.Json.JsonSerializer.Serialize(secretData), Encoding.UTF8, "application/json");
            var putResponse = await client.PostAsync($"/v1/{secretPath}", content);
            Console.WriteLine($"PUT Status: {putResponse.StatusCode}");


        }
    
    }
}
