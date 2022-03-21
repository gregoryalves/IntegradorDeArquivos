using DesafioMyrp.DAO;
using DesafioMyrp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DesafioMyrp.Controllers
{
    public class IntegracaoController : Controller
    {
        public ActionResult Index()
        {
            IntegracoesDAO dao = new IntegracoesDAO();
            IList<Integracao> integracoes = dao.BuscarTodas();
            ViewBag.Integracoes = integracoes;
            return View();
        }

        [HttpPost]
        public ActionResult Salvar(Integracao integracao)
        {
            var dao = new IntegracoesDAO();

            if (integracao.Id > 0)
                dao.Atualizar(integracao);
            else
                dao.Adicionar(integracao);

            return RedirectToAction("Index", "Integracao");
        }

        [HttpPost]
        public ActionResult Excluir(Integracao integracao)
        {
            var dao = new IntegracoesDAO();
            dao.Excluir(integracao.Id);

            return RedirectToAction("Index", "Integracao");
        }
    }
}