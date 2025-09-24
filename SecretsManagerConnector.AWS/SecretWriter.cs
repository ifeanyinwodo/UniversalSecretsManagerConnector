using Amazon.SecretsManager;
using Amazon.SecretsManager.Model;
using System;
using System.Threading.Tasks;


namespace UniversalSecretsManagerConnector.SecretsManagerConnector.AWS
{
    internal class SecretWriter
    {
        internal static async Task StoreSecretAsync(string secretName, string secretValue)
        {
            var client = new AmazonSecretsManagerClient();

            var request = new CreateSecretRequest
            {
                Name = secretName,
                SecretString = secretValue
            };

            var response = await client.CreateSecretAsync(request);
            Console.WriteLine($"Secret stored: {response.ARN}");

        
        }
    }

}
