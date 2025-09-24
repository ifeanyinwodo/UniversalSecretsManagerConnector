using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversalSecretsManagerConnector
{
    
public class ManagerConnector
    {
        public static async Task<string> GetSecretFromAWS(string secretName)
        {
            return await UniversalSecretsManagerConnector.SecretsManagerConnector.AWS.SecretReader.GetSecretAsync(secretName);
        }

        public static async Task SetSecretInAWS(string secretName, string secretValue)
        {
            await UniversalSecretsManagerConnector.SecretsManagerConnector.AWS.SecretWriter.StoreSecretAsync(secretName, secretValue);
        }

        public static async Task<string> GetSecretFromHashiCorp(string vaultAddress, string vaultToken, string secretName)
        {
            return await UniversalSecretsManagerConnector.SecretsManagerConnector.HashiCorp.SecretReader.GetSecretAsync(vaultAddress, vaultToken, secretName);
        }

        public static async Task SetSecretInHashiCorp(string vaultAddress, string vaultToken, string secretName, string secretValue)
        {
            await UniversalSecretsManagerConnector.SecretsManagerConnector.HashiCorp.SecretWriter.SetSecretAsync(vaultAddress, vaultToken, secretName, secretValue);
        }

        public static async Task SetSecretInAzureUsingManagedIdentity(string vualtUrl, string secretName, string secretValue)
        {
            await UniversalSecretsManagerConnector.SecretsManagerConnector.Azure.SecretWriter.SetSecretUsingManagedIdentityAsync(vualtUrl, secretName, secretValue);
        }

        public static async Task SetSecretInAzureUsingServicePrincipalWithClientSecret(string tenantId, string clientId, string clientSecret, string vualtUrl, string secretName, string secretValue)
        {
            await UniversalSecretsManagerConnector.SecretsManagerConnector.Azure.SecretWriter.SetSecretUsingServicePrincipalWithClientSecretAsync(tenantId, clientId, clientSecret, vualtUrl, secretName, secretValue);
        }

        public static async Task SetSecretInAzureUsingServicePrincipalWithCertificate(string pathToCertpfx, string certPassword, string tenantId, string clientId, string clientSecret, string vualtUrl, string secretName, string secretValue)
        {
            await UniversalSecretsManagerConnector.SecretsManagerConnector.Azure.SecretWriter.SetSecretUsingServicePrincipalWithCertificateAsync(pathToCertpfx, certPassword, tenantId, clientId, clientSecret, vualtUrl, secretName, secretValue);
        }

        public static async Task<string> GetSecretFromAzureUsingManagedIdentity(string vualtUrl, string secretName)
        {
            return await UniversalSecretsManagerConnector.SecretsManagerConnector.Azure.SecretReader.GetSecretUsingManagedIdentityAsync(vualtUrl, secretName);
        }

        public static async Task<string> GetSecretFromAzureUsingServicePrincipalWithClientSecret(string tenantId, string clientId, string clientSecret, string vualtUrl, string secretName)
        {
            return await UniversalSecretsManagerConnector.SecretsManagerConnector.Azure.SecretReader.GetSecretUsingServicePrincipalWithClientSecretAsync(tenantId, clientId, clientSecret, vualtUrl, secretName);
        }

        public static async Task<string> GetSecretFromAzureUsingServicePrincipalWithCertificate(string pathToCertpfx, string certPassword, string tenantId, string clientId, string clientSecret, string vualtUrl, string secretName)
        {
            return await UniversalSecretsManagerConnector.SecretsManagerConnector.Azure.SecretReader.GetSecretUsingServicePrincipalWithCertificateAsync(pathToCertpfx, certPassword, tenantId, clientId, clientSecret, vualtUrl, secretName);
        }

        public static string GetSecretFromFile(string filePathandName)
        {
            return UniversalSecretsManagerConnector.SecretsManagerConnector.FilePath.SecretReader.GetSecret(filePathandName);
        }

        public static void SetSecretInFile(string filePathandName, string secretValue)
        {
            UniversalSecretsManagerConnector.SecretsManagerConnector.FilePath.SecretWriter.SetSecret(filePathandName, secretValue);
        }



        public static string? GetSecretFromEnvironmentVariable(string variableName)
        {
            return UniversalSecretsManagerConnector.SecretsManagerConnector.Environment.SecretReader.GetSecret(variableName);
        }



    }
}
