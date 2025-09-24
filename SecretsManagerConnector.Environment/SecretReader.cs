using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversalSecretsManagerConnector.SecretsManagerConnector.Environment
{
    internal class SecretReader
    {
        internal static string? GetSecret(string environmentVariableName)
        {
            return System.Environment.GetEnvironmentVariable(environmentVariableName);
        }
    }
}
