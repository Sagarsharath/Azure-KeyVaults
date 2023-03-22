using System;
using System.Collections.Generic;
using System.Text;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using System.Threading.Tasks;

namespace AZKeyVaultSample.KeyVault
{
    public class KeyVaultHandler
    {
        public IKeyVaultAbstract _keyVaultService = null;

        public KeyVaultHandler(IKeyVaultAbstract keyVaultInstance)
        {
            _keyVaultService = keyVaultInstance;
        }

        public async Task<bool> AddSecret(string secretName, string secretValue)
        {
            try
            {
                var response = await _keyVaultService.AddSecret(secretName, secretValue);
                if (response != null && response.Value != null)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message); throw ex;
            }        
        }

        public async Task<string> GetSecret(string secretName)
        {
            try
            {
               var response = await _keyVaultService.GetSecret(secretName);
               return response.Value.Value;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }

        public async Task<bool> RemoveSecret(string secretName)
        {
            try
            {
                var response = await _keyVaultService.DeleteSecret(secretName);
                if (response.Value?.RecoveryId !=null)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }

        }
    }
}
