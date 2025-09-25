using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversalSecretsManagerConnector.SecretsManagerConnector.Environment
{
    internal class SecretWriter
    {
        internal static void SetSecret(string environmentVariableName, string environmentVariableValue)
        {
            string? userValue = System.Environment.GetEnvironmentVariable(environmentVariableName, EnvironmentVariableTarget.User);
            string? systemValue = System.Environment.GetEnvironmentVariable(environmentVariableName, EnvironmentVariableTarget.Machine);

            if (userValue != null)
            {
                System.Environment.SetEnvironmentVariable(environmentVariableName, environmentVariableValue, EnvironmentVariableTarget.User);
            }
            else if (systemValue != null)
            {
                System.Environment.SetEnvironmentVariable(environmentVariableName, environmentVariableValue, EnvironmentVariableTarget.Machine);
            }
            else
            {
                System.Environment.SetEnvironmentVariable(environmentVariableName, environmentVariableValue, EnvironmentVariableTarget.User);
            }
        }

}
}
