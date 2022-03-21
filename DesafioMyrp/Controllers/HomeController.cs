using DesafioMyrp.DAO;
using DesafioMyrp.Helpers;
using DesafioMyrp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using System.Xml.Serialization;

namespace DesafioMyrp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Integrar(Usuario usuario)
        {
            InternalIntegrar(usuario);
            return View();
        }

        private void InternalIntegrar(Usuario usuario)
        {
            var dao = new IntegracoesDAO();
            var integracoes = dao.BuscarTodas();
            var mensagens = new List<UsuarioMensagem>();

            foreach (var integracao in integracoes)
            {
                var integrar = IntegracaoHelper.VerificarCondicaoParaIntegrar(integracao, usuario);                

                if (integrar)
                {
                    var usuarioInternal = new Usuario(usuario.Nome, usuario.Idade, usuario.Telefone, usuario.Email);

                    usuarioInternal.Nome = integracao.Nome ? usuarioInternal.Nome : string.Empty;
                    usuarioInternal.Idade = integracao.Idade ? usuarioInternal.Idade : null;
                    usuarioInternal.Telefone = integracao.Telefone ? usuarioInternal.Telefone : string.Empty;
                    usuarioInternal.Email = integracao.Email ? usuarioInternal.Email : string.Empty;

                    var assuntoEmail = integracao.Titulo;
                    var corpoEmail = IntegracaoHelper.RetornarCorpoEmail(usuarioInternal);
                    var diretorio = Path.GetTempPath();
                    var nomeArquivo = Guid.NewGuid().ToString() + $".{integracao.Formato}";
                    var arquivo = Path.Combine(diretorio, nomeArquivo);

                    System.IO.File.Create(arquivo).Dispose();

                    IntegracaoHelper.FormatarArquivo(usuarioInternal, integracao, arquivo);

                    if (integracao.Acao.Equals("email"))
                    {
                        if (!string.IsNullOrEmpty(usuarioInternal.Email))
                        {
                            var emailObject = new Email(usuarioInternal.Email, assuntoEmail, corpoEmail, arquivo);

                            string mensagem;
                            
                            if (emailObject.EnviarEmail(out mensagem))
                                mensagem = $"Integração id: {integracao.Id} - E-mail enviado com sucesso.";
                            else
                                mensagem = $"Integração id: {integracao.Id} - Erro ao tentar enviar o e-mail: {mensagem}";

                            mensagens.Add(new UsuarioMensagem(usuarioInternal.Nome, mensagem));
                        }
                    }

                    if (integracao.Acao.Equals("link"))
                    {
                        var url = integracao.Url;

                        string mensagem;
                        var statusCode = IntegracaoHelper.ConsumirLink(usuarioInternal, integracao, url, arquivo, out mensagem);

                        if (statusCode == HttpStatusCode.OK)
                            mensagem = $"Integração id: {integracao.Id} - Link consumido com sucesso. Status: {statusCode}";
                        else
                            mensagem = $"Integração id: {integracao.Id} - Erro ao consumir o link. Status: {statusCode} {mensagem}";

                        mensagens.Add(new UsuarioMensagem(usuarioInternal.Nome, mensagem));
                    }

                    System.IO.File.Delete(arquivo);
                }
            }

            ViewBag.Mensagens = mensagens;
        }            

    }

    public class UsuarioMensagem
    {
        public string Nome { get; set; }
        public string Mensagem { get; set; }

        public UsuarioMensagem(string nome, string mensagem)
        {
            Nome = nome;
            Mensagem = mensagem;
        }
    }
    
}