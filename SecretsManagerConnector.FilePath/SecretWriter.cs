using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using UniversalSecretsManagerConnector.Helper;

namespace UniversalSecretsManagerConnector.SecretsManagerConnector.FilePath
{
    internal class SecretWriter
    {

        internal static void SetSecret(string filePathandName, string secretValue)
        {
            Utility.SaveEncrypted(filePathandName, secretValue);
        }

    }
}
