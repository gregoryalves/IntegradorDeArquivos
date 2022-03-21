using DesafioMyrp.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DesafioMyrpTests
{
    [TestClass]
    public class TestsBase
    {
        public Integracao _integracao;
        public Usuario _usuario;
        public string _url;

        [TestInitialize]
        public void SetUp()
        {
            _integracao = new Integracao();
            _usuario = new Usuario("Fulano", 31, "4766431646", "fualno@empresa.com");
            _integracao.Condicao = ">";
            _integracao.Valor = 18;
        }
    }
}
