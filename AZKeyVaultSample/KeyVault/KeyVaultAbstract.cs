using System;
using System.Collections.Generic;
using System.Text;
using Azure.Security.KeyVault.Secrets;
using System.Threading.Tasks;

namespace AZKeyVaultSample.KeyVault
{
    public interface IKeyVaultAbstract
    {
        Task<Azure.Response<KeyVaultSecret>> AddSecret(string secretName, string secretValue);
        Task<Azure.Response<KeyVaultSecret>> GetSecret(string secretName);
        Task<Azure.Response<DeletedSecret>> DeleteSecret(string secretName);

    }
}
