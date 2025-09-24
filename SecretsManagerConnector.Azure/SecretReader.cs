using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using System.Security.Cryptography.X509Certificates;
using System.Runtime.ConstrainedExecution;


namespace UniversalSecretsManagerConnector.SecretsManagerConnector.Azure
{
    internal class SecretReader
    {
        
        internal static async Task<string> GetSecretUsingManagedIdentityAsync(string vualtUrl, string secretName)
        {
            var credential = new DefaultAzureCredential();
            var client = new SecretClient(new Uri(vualtUrl), credential);
            var secret = await client.GetSecretAsync(secretName);
            var keyValueSecret= secret.Value;
            return keyValueSecret.Value;

           
        }


        internal static async Task<string> GetSecretUsingServicePrincipalWithClientSecretAsync(string tenantId, string clientId, string clientSecret, string vualtUrl, string secretName)
        {
            var credential = new ClientSecretCredential(tenantId,clientId, clientSecret);
            var client = new SecretClient(new Uri(vualtUrl), credential);
            var secret = await client.GetSecretAsync(secretName);
            var keyValueSecret = secret.Value;
            return keyValueSecret.Value;
        }

        internal static async Task<string> GetSecretUsingServicePrincipalWithCertificateAsync(string pathToCertpfx, string certPassword, string tenantId, string clientId, string clientSecret, string vualtUrl, string secretName)
        {
            var cert = new X509Certificate2(pathToCertpfx, certPassword);
            var credential = new ClientCertificateCredential(tenantId, clientId,cert);
            var client = new SecretClient(new Uri(vualtUrl), credential);
            var secret = await client.GetSecretAsync(secretName);
            var keyValueSecret = secret.Value;
            return keyValueSecret.Value;


        }


    }

}
