using DesafioMyrp.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace DesafioMyrpTests
{
    [TestClass]
    public class EmailTest
    {
        private Email _email;
        private string _destinatario;
        private string _titulo;
        private string _corpo;
        private string _anexo;

        [TestInitialize]
        public void SetUp()
        {
            _destinatario = "myrpgregory@gmail.com";
            _titulo = "Título";
            _corpo = "Cormpo";            
        }

        [TestMethod]
        public void EnviarEmail_QuandoExecutado_DeveRetornarTrue()
        {
            string mensagem;
            _anexo = Path.GetTempFileName();
            _email = new Email(_destinatario, _titulo, _corpo, _anexo);
            var enviouEmail = _email.EnviarEmail(out mensagem);
            System.IO.File.Delete(_anexo);

            Assert.IsTrue(enviouEmail);
        }

        [TestMethod]
        public void EnviarEmail_QuandoExecutado_DeveRetornarFalse()
        {
            _destinatario = string.Empty;

            string mensagem;
            _anexo = Path.GetTempFileName();
            _email = new Email(_destinatario, _titulo, _corpo, _anexo);
            var enviouEmail = _email.EnviarEmail(out mensagem);
            System.IO.File.Delete(_anexo);

            Assert.IsFalse(enviouEmail);
        }
    }
}
