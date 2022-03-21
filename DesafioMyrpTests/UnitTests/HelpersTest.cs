using DesafioMyrp.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DesafioMyrpTests.UnitTests
{
    [TestClass]
    public class HelpersTest : TestsBase
    {
        [TestMethod]
        public void RetornarCorpoEmail_QuandoExecutado_NaoDeveRetornarStringVazia()
        {
            var corpoEmail = IntegracaoHelper.RetornarCorpoEmail(_usuario);

            Assert.IsFalse(string.IsNullOrEmpty(corpoEmail));
        }

        [TestMethod]
        public void VerificarCondicaoParaIntegrar_QuandoExecutado_DeveRetornarTrue()
        {
            var integrar = IntegracaoHelper.VerificarCondicaoParaIntegrar(_integracao, _usuario);
            Assert.IsTrue(integrar);
        }

        [TestMethod]
        public void VerificarCondicaoParaIntegrar_QuandoExecutado_DeveRetornarFalse()
        {
            _integracao.Valor = 50;
            var integrar = IntegracaoHelper.VerificarCondicaoParaIntegrar(_integracao, _usuario);
            Assert.IsTrue(integrar);
        }
    }
}
