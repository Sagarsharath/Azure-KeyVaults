using AZKeyVaultSample.KeyVault;
using Azure.Security.KeyVault.Secrets;
using Azure;
using Moq;
using Xunit.Sdk;
using Castle.Components.DictionaryAdapter.Xml;

namespace AZKeyvaultTests
{
    public class V1KeyValutTest
    {
        private Mock<IKeyVaultAbstract> _service;

        public V1KeyValutTest()
        {
            _service = new Mock<IKeyVaultAbstract>();
        }

        [Fact]
        public void AddSecret_Success()
        {
            KeyVaultSecret keyVaultSecret = SecretModelFactory.KeyVaultSecret(new SecretProperties("secret1"), "secret1Value");
            Response<KeyVaultSecret> response = Response.FromValue(keyVaultSecret, Mock.Of<Response>());
            var handler = new KeyVaultHandler(_service.Object);
            _service.Setup(s => s.AddSecret("secret1", "secret1Value").Result).Returns(response);
            var result = handler.AddSecret("secret1", "secret1Value");
            Assert.True(result.Result);
        }

        [Fact]
        public void AddSecret_Error()
        {
            var ex = new Exception("invalid keyvault");
            var handler = new KeyVaultHandler(_service.Object);
            _service.Setup(s => s.AddSecret("secret1", "secret1Value").Result).Throws(ex);
            Assert.IsType<Exception>(ex);
        }
    }
}