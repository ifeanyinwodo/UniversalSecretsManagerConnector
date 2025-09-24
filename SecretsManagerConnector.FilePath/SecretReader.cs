using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversalSecretsManagerConnector.Helper;

namespace UniversalSecretsManagerConnector.SecretsManagerConnector.FilePath
{
    internal class SecretReader
    {
        internal static string GetSecret(string filePathandName)
        {
            return Utility.LoadEncrypted(filePathandName);
        }
    }
}
