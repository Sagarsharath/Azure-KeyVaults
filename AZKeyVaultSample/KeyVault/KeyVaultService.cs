using System;
using System.Threading.Tasks;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;

namespace AZKeyVaultSample.KeyVault
{
    public class KeyVaultService : IKeyVaultAbstract
    {
        private string _keyVaultUri;
        private SecretClient _secretClient;

        public KeyVaultService(string KeyVaultName) {
            _keyVaultUri = $"https://{KeyVaultName}.vault.azure.net/";
            _secretClient = new SecretClient(new Uri(_keyVaultUri), new DefaultAzureCredential());
        }

        public async Task<Azure.Response<KeyVaultSecret>> AddSecret(string secretName, string secretValue)
        {
            try
            {
                return await _secretClient.SetSecretAsync(secretName, secretValue);
            }catch{ throw;}
            
        }

        public async Task<Azure.Response<KeyVaultSecret>> GetSecret(string secretName)
        {
            try
            {
                return await _secretClient.GetSecretAsync(secretName);
            }catch { throw; }
            
        }

        public async Task<Azure.Response<DeletedSecret>> DeleteSecret(string secretName)
        {
            try
            {
                DeleteSecretOperation operation = await _secretClient.StartDeleteSecretAsync(secretName);
                return await operation.WaitForCompletionAsync();
            } catch { throw; }
            
        }
    }
}
