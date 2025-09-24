using Amazon.SecretsManager.Model;
using Amazon.SecretsManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversalSecretsManagerConnector.Helper;

namespace UniversalSecretsManagerConnector.SecretsManagerConnector.HashiCorp
{
    internal class SecretReader
    {
       
        internal static async Task<string> GetSecretAsync(string vaultAddress, string vaultToken, string secretName)
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri(vaultAddress);
            client.DefaultRequestHeaders.Add("X-Vault-Token", vaultToken);

            secretName = Utility.RemoveSpecialCharacters(secretName);
            string secretPath = "secret/data/allapps/" + secretName;

            var getResponse = await client.GetAsync($"/v1/{secretPath}");
            var responseBody = await getResponse.Content.ReadAsStringAsync();
           
            return Utility.GetSecretHashiCorpNameValue(responseBody);
        }
    }
}
