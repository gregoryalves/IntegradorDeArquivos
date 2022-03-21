using DesafioMyrp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DesafioMyrp.DAO
{
    public class IntegracoesDAO
    {
        public void Adicionar(Integracao integracao)
        {
            using (var context = new DbMyrpContext())
            {
                context.Integracoes.Add(integracao);
                context.SaveChanges();
            }
        }

        public IList<Integracao> BuscarTodas()
        {
            using (var context = new DbMyrpContext())
            {
                return context.Integracoes.ToList();
            }
        }

        public Integracao BuscarPorId(int id)
        {
            using (var context = new DbMyrpContext())
            {
                return context.Integracoes.Where(x => x.Id == id).FirstOrDefault();
            }
        }        

        public void Atualizar(Integracao integracao)
        {
            using (var context = new DbMyrpContext())
            {
                context.Entry(integracao).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void Excluir(int id)
        {
            var integracao = BuscarPorId(id);

            if (integracao != null)
            {
                using (var context = new DbMyrpContext())
                {
                    context.Entry(integracao).State = System.Data.Entity.EntityState.Deleted;
                    context.SaveChanges();
                }
            }
        }
    }
}