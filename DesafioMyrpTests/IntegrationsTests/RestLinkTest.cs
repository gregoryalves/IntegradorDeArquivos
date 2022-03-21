using DesafioMyrp.Helpers;
using DesafioMyrp.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Net;
using System.Xml.Serialization;

namespace DesafioMyrpTests
{
    [TestClass]
    public class RestLinkTest : TestsBase
    {
        [TestMethod]
        public void ConsumirLinkPost_QuandoExecutado_DeveRetornarStatusOk()
        {
            _integracao.Formato = "xml";
            _integracao.MetodoRequisicao = "POST";
            _url = "http://httpbin.org/post";

            var diretorio = Path.GetTempPath();
            var nomeArquivo = Guid.NewGuid().ToString() + $".{_integracao.Formato}";
            var arquivo = Path.Combine(diretorio, nomeArquivo);

            File.Create(arquivo).Dispose();

            var xml = new XmlSerializer(_usuario.GetType());
            var stream = new FileStream(arquivo, FileMode.Open);

            xml.Serialize(stream, _usuario);
            stream.Dispose();

            string mensagem;
            var statusCode = IntegracaoHelper.ConsumirLink(_usuario, _integracao, _url, arquivo, out mensagem);

            File.Delete(arquivo);

            Assert.IsTrue(statusCode == HttpStatusCode.OK);
        }               

        [TestMethod]
        public void ConsumirLinkGetJson_QuandoExecutado_DeveRetornarStatusOk()
        {
            _integracao.Formato = "json";
            _integracao.MetodoRequisicao = "GET";
            _url = "http://httpbin.org/get";

            var diretorio = Path.GetTempPath();
            var nomeArquivo = Guid.NewGuid().ToString() + $".{_integracao.Formato}";
            var arquivo = Path.Combine(diretorio, nomeArquivo);

            File.Create(arquivo).Dispose();

            string mensagem;
            var statusCode = IntegracaoHelper.ConsumirLink(_usuario, _integracao, _url, arquivo, out mensagem);

            File.Delete(arquivo);

            Assert.IsTrue(statusCode == HttpStatusCode.OK);
        }        

        [TestMethod]
        public void ConsumirLinkJson_QuandoExecutado_DeveRetornarStatusErro()
        {
            _url = string.Empty;
            _integracao.Formato = "json";

            var diretorio = Path.GetTempPath();
            var nomeArquivo = Guid.NewGuid().ToString() + $".{_integracao.Formato}";
            var arquivo = Path.Combine(diretorio, nomeArquivo);

            File.Create(arquivo).Dispose();

            string mensagem;
            var statusCode = IntegracaoHelper.ConsumirLink(_usuario, _integracao, _url, arquivo, out mensagem);

            File.Delete(arquivo);

            Assert.IsFalse(statusCode == HttpStatusCode.OK);
        }
    }
}
