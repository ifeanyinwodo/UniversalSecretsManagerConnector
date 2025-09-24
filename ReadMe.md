# UniversalSecretsManagerConnector

UniversalSecretsManagerConnector is a .NET 8 library designed to provide a unified interface for reading and writing secrets across multiple secret management providers. It supports AWS Secrets Manager, Azure Key Vault, HashiCorp Vault, environment variables, and file-based secret storage.

## Features

- **Unified API** for secret management across multiple providers.
- **Read and write** secrets from:
  - AWS Secrets Manager
  - Azure Key Vault
  - HashiCorp Vault
  - Environment variables
  - File-based storage
- **Extensible architecture** for adding new secret providers.
- **Helper utilities** for common secret management tasks.

## Supported Providers

- **AWS**: `SecretsManagerConnector.AWS`
- **Azure**: `SecretsManagerConnector.Azure`
- **HashiCorp Vault**: `SecretsManagerConnector.HashiCorp`
- **Environment Variables**: `SecretsManagerConnector.Environment`
- **File Path**: `SecretsManagerConnector.FilePath`

## Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)

### Installation

Add the project reference to your solution or include the source code in your project.

### Usage Example


### Provider-Specific Usage

Each provider has its own reader and writer classes. For example:


## Project Structure

- `SecretsManagerConnector.cs`: Main connector class.
- `SecretsManagerConnector.Models/Models.cs`: Data models for secrets.
- `SecretsManagerConnector.AWS/SecretReader.cs`, `SecretWriter.cs`: AWS integration.
- `SecretsManagerConnector.Azure/SecretReader.cs`, `SecretWriter.cs`: Azure integration.
- `SecretsManagerConnector.HashiCorp/SecretReader.cs`, `SecretWriter.cs`: HashiCorp Vault integration.
- `SecretsManagerConnector.Environment/SecretReader.cs`: Environment variable integration.
- `SecretsManagerConnector.FilePath/SecretReader.cs`, `SecretWriter.cs`: File-based secret management.
- `Helper/Utility.cs`: Utility functions.

## Extending

To add a new provider, implement `SecretReader` and `SecretWriter` classes following the existing pattern and register them with the main connector.

## License

This project is licensed under the MIT License.

## Contributing

Contributions are welcome! Please submit issues or pull requests via GitHub.

