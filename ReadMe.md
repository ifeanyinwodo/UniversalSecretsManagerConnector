# UniversalSecretsManagerConnector

UniversalSecretsManagerConnector is a .NET 8 library that provides a unified interface for reading and writing secrets from multiple secret management systems: AWS Secrets Manager, Azure Key Vault, HashiCorp Vault, environment variables, and file-based storage.

## Overview

- Unified, minimal API surface for common secret operations (read/write).
- Provider-specific implementations are placed under `SecretsManagerConnector.*` namespaces.
- Small helper utilities are provided in `Helper/Utility.cs` to normalize inputs and parse provider responses.

## Requirements

- .NET 8 SDK
- Provider-specific credentials and configuration (see provider sections below).
- Important: If you plan to use the HashiCorp Vault implementation included in this repository, the Vault KV secrets engine MUST be mounted as kv-v2 under the mount path `secret` (this is the path hard-coded by the library). The code expects to call endpoints like `/v1/secret/data/allapps/{secretName}`.

  Example (Vault CLI):

  ```bash
  # enable kv-v2 at path "secret" (run on the Vault server or where VAULT_ADDR/VAULT_TOKEN are configured)
  vault secrets enable -path=secret kv-v2

  # write a secret that will be visible to this library at secret/allapps/mysecret
  vault kv put secret/allapps/mysecret value="my-value"
  ```

  Note: If you mount kv-v2 at a different path, you'll need to change the library's hard-coded path (see `SecretsManagerConnector.HashiCorp.SecretReader`) or adapt your Vault configuration.

## Quick start

1. Ensure you have the .NET 8 SDK installed.
2. Add this project to your solution or reference its NuGet package .
3. Use the `ManagerConnector` static helper to call provider-specific methods.

### Build

From the repository root:

```powershell
dotnet build
```

### Simple usage example

Create a small console app and add a project reference to this connector project, or reference the package.

Example C# usage (Console App - async Main):

```csharp
using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        // HashiCorp Vault example
        string vaultAddr = "https://127.0.0.1:8200";
        string vaultToken = "s.xxxxxxxxxxxxxxxxx";
        string secretName = "mysecret";

        // Read
        string secretValue = await UniversalSecretsManagerConnector.ManagerConnector.GetSecretFromHashiCorp(vaultAddr, vaultToken, secretName);
        Console.WriteLine($"Secret: {secretValue}");

        // Write
        await UniversalSecretsManagerConnector.ManagerConnector.SetSecretInHashiCorp(vaultAddr, vaultToken, secretName, "new-value");
    }
}
```

Example for AWS Secrets Manager:

```csharp
string secret = await UniversalSecretsManagerConnector.ManagerConnector.GetSecretFromAWS("my-aws-secret-name");
await UniversalSecretsManagerConnector.ManagerConnector.SetSecretInAWS("my-aws-secret-name", "my-new-value");
```

Example for Azure Key Vault (managed identity):

```csharp
await UniversalSecretsManagerConnector.ManagerConnector.SetSecretInAzureUsingManagedIdentity("https://myvault.vault.azure.net/", "secret-name", "value");
string val = await UniversalSecretsManagerConnector.ManagerConnector.GetSecretFromAzureUsingManagedIdentity("https://myvault.vault.azure.net/", "secret-name");
```

Example for environment variables and file-based secrets (synchronous helpers):

```csharp
// Environment
var env = UniversalSecretsManagerConnector.ManagerConnector.GetSecretFromEnvironmentVariable("MY_ENV_VAR");
UniversalSecretsManagerConnector.ManagerConnector.SetSecretInEnvironmentVariable("MY_ENV_VAR", "value");

// File
var fileSecret = UniversalSecretsManagerConnector.ManagerConnector.GetSecretFromFile("C:\\path\\to\\secret.txt");
UniversalSecretsManagerConnector.ManagerConnector.SetSecretInFile("C:\\path\\to\\secret.txt", "value");
```

## Project / Solution structure

Top-level files

- `UniversalSecretsManagerConnector.sln` — Visual Studio solution file.
- `UniversalSecretsManagerConnector.csproj` — library project file.
- `ManagerConnector.cs` — static convenience wrapper around provider readers/writers (examples above).
- `ReadMe.md` — this file.
- `LICENSE` — Apache-2.0.

Folders and purpose

- `SecretsManagerConnector.AWS/` — AWS Secrets Manager reader/writer implementations.
- `SecretsManagerConnector.Azure/` — Azure Key Vault reader/writer implementations.
- `SecretsManagerConnector.HashiCorp/` — HashiCorp Vault reader/writer (expects kv-v2 mounted at `secret`).
- `SecretsManagerConnector.Environment/` — read/write helpers for environment variables.
- `SecretsManagerConnector.FilePath/` — read/write helpers for file-based secrets.
- `Helper/` — shared utilities (e.g. input normalization and response parsing).
- `bin/`, `obj/` — build artifacts and packaged output (including a sample nupkg in `bin/Debug`).

## Notes on HashiCorp Vault behavior

- The HashiCorp reader currently builds the secret path using `secret/data/allapps/{secretName}` and then parses the returned JSON to extract name/value pairs (see `Helper/Utility.cs` for the parsing logic).
- Because the path is hard-coded to the `secret` mount and `allapps` prefix, either ensure your Vault secrets follow that path or modify the code to suit your naming/mount layout.

## Extending the library

To add support for another provider, follow the established pattern:

1. Add a new folder `SecretsManagerConnector.YourProvider`.
2. Implement `SecretReader` and `SecretWriter` classes with async methods that mirror the existing provider signatures.
3. Use `Helper/Utility.cs` for any shared parsing/normalization.
4. Update `ManagerConnector.cs` if you want convenience wrapper methods for the new provider.

## License

This project is licensed under the [Apache-2.0 License](LICENSE).

---

## Author

**Ifeanyi Nwodo**

---

## Contributing

Contributions, issues, and feature requests are welcome! Please open an issue or submit a pull request.

---

## Disclaimer

This library is provided as-is. Always review and test cryptographic code for your specific use case and security requirements.

---
