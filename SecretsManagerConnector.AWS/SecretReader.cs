using Amazon.SecretsManager;
using Amazon.SecretsManager.Model;
using System;
using System.Threading.Tasks;


namespace UniversalSecretsManagerConnector.SecretsManagerConnector.AWS
{
    internal class SecretReader
    {
        internal static async Task<string> GetSecretAsync(string secretName)
        {
            var client = new AmazonSecretsManagerClient();

            var request = new GetSecretValueRequest
            {
                SecretId = secretName
            };


            var response = await client.GetSecretValueAsync(request);
            return response.SecretString;

           
        }
    }

}
