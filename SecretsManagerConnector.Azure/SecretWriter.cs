using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace UniversalSecretsManagerConnector.SecretsManagerConnector.Azure
{
    internal class SecretWriter
    {

        internal static async Task SetSecretUsingManagedIdentityAsync(string vualtUrl, string secretName, string secretValue)
        {
            var credential = new DefaultAzureCredential();
            var client = new SecretClient(new Uri(vualtUrl), credential);
            await client.SetSecretAsync(secretName, secretValue);


        }


        internal static async Task SetSecretUsingServicePrincipalWithClientSecretAsync(string tenantId, string clientId, string clientSecret, string vualtUrl, string secretName, string secretValue)
        {
            var credential = new ClientSecretCredential(tenantId, clientId, clientSecret);
            var client = new SecretClient(new Uri(vualtUrl), credential);
            await client.SetSecretAsync(secretName, secretValue);
        }

        internal static async Task SetSecretUsingServicePrincipalWithCertificateAsync(string pathToCertpfx, string certPassword, string tenantId, string clientId, string clientSecret, string vualtUrl, string secretName, string secretValue)
        {
            var cert = new X509Certificate2(pathToCertpfx, certPassword);
            var credential = new ClientCertificateCredential(tenantId, clientId, cert);
            var client = new SecretClient(new Uri(vualtUrl), credential);
            await client.SetSecretAsync(secretName, secretValue);


        }

    }
}
