using DesafioMyrp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace DesafioMyrp.Helpers
{
    public static class IntegracaoHelper
    {
        public static HttpStatusCode ConsumirLink(Usuario usuario, Integracao integracao, string url, string arquivo, out string mensagem)
        {                        
            try
            {
                var webRequest = WebRequest.Create($"{url}");
                webRequest.Method = integracao.MetodoRequisicao;

                string dados = string.Empty;

                if (integracao.Formato.Equals("json"))
                {
                    webRequest.ContentType = "application/json";

                    if (integracao.MetodoRequisicao.Equals("POST"))
                    {
                        dados = JsonConvert.SerializeObject(usuario);
                        var byteArray = Encoding.UTF8.GetBytes(dados);
                        webRequest.ContentLength = byteArray.Length;
                        var dataStream = webRequest.GetRequestStream();
                        dataStream.Write(byteArray, 0, byteArray.Length);
                        dataStream.Close();
                    }                    
                }

                if (integracao.Formato.Equals("xml"))
                {
                    webRequest.ContentType = "application/xml";

                    if (integracao.MetodoRequisicao.Equals("POST"))
                    {
                        var xmlSerializer = new XmlSerializer(usuario.GetType());
                        var fileStream = new FileStream(arquivo, FileMode.Open);
                        var xml = XElement.Load(fileStream);

                        xmlSerializer.Serialize(fileStream, usuario);
                        fileStream.Dispose();

                        var data = Encoding.Default.GetBytes(xml.Value);

                        webRequest.ContentLength = data.Length;

                        var stream = webRequest.GetRequestStream();
                        stream.Write(data, 0, data.Length);
                        stream.Flush();
                        stream.Close();
                    }
                }

                if (integracao.Formato.Equals("csv"))
                {
                    webRequest.ContentType = "text/csv";
                }
                                
                var httpResponse = (HttpWebResponse)webRequest.GetResponse();

                mensagem = string.Empty;
                return httpResponse.StatusCode;
            }
            catch (Exception e)
            {
                mensagem = e.Message;
                return HttpStatusCode.InternalServerError;
            }
        }

        public static void FormatarArquivo(Usuario usuario, Integracao integracao, string arquivo)
        {
            if (integracao.Formato.Equals("json"))
            {
                var json = JsonConvert.SerializeObject(usuario);
                File.WriteAllText(arquivo, json);
            }

            if (integracao.Formato.Equals("csv"))
            {
                var conteudo = new StringBuilder();
                conteudo.AppendLine("Nome, Idade, Telefone, Email");
                conteudo.AppendLine($"{usuario.Nome},{usuario.Idade},{usuario.Telefone},{usuario.Email}");

                File.WriteAllText(arquivo, conteudo.ToString());
            }

            if (integracao.Formato.Equals("xml"))
            {
                var xml = new XmlSerializer(usuario.GetType());
                var stream = new FileStream(arquivo, FileMode.Open);
                xml.Serialize(stream, usuario);
                stream.Dispose();
            }
        }

        public static bool VerificarCondicaoParaIntegrar(Integracao integracao, Usuario usuario)
        {
            if (!string.IsNullOrEmpty(integracao.Campo) && !string.IsNullOrEmpty(integracao.Condicao) && integracao.Valor != null)
            {
                if (integracao.Campo.Equals("idade"))
                {
                    if (integracao.Condicao.Equals(">"))
                        return usuario.Idade > integracao.Valor;

                    if (integracao.Condicao.Equals(">="))
                        return usuario.Idade >= integracao.Valor;

                    if (integracao.Condicao.Equals("<"))
                        return usuario.Idade < integracao.Valor;

                    if (integracao.Condicao.Equals("<="))
                        return usuario.Idade <= integracao.Valor;

                    if (integracao.Condicao.Equals("="))
                        return usuario.Idade == integracao.Valor;
                }
            }

            return true;
        }

        public static string RetornarCorpoEmail(Usuario usuario)
        {
            var result = new StringBuilder();

            if (!string.IsNullOrEmpty(usuario.Nome))
                result.AppendLine($"Nome: {usuario.Nome}");

            if (usuario.Idade != null)
                result.AppendLine($"Idade: {usuario.Idade}");

            if (!string.IsNullOrEmpty(usuario.Telefone))
                result.AppendLine($"Telefone: {usuario.Telefone}");

            if (!string.IsNullOrEmpty(usuario.Email))
                result.AppendLine($"E-mail: {usuario.Email}");

            return result.ToString();
        }
    }
}