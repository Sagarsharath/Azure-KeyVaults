using System;
using System.Threading.Tasks;
using AZKeyVaultSample.KeyVault;

namespace AZKeyVaultSample
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            IKeyVaultAbstract keyVaultInstance = new KeyVaultService("v1Credentials");
            KeyVaultHandler keyVaultHandler = new KeyVaultHandler(keyVaultInstance);

            keyVaultHandler.AddSecret("sec1", "secasak");
            //keyVaultHandler.GetSecret("sec1");
            //keyVaultHandler.RemoveSecret("sec1");
            //keyVaultHandler.GetSecret("sec1");
            Console.ReadLine();
        }
    }
}
