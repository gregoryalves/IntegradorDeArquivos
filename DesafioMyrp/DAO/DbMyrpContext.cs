using DesafioMyrp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DesafioMyrp.DAO
{
    public class DbMyrpContext : DbContext
    {
        public DbSet<Integracao> Integracoes { get; set; }        
    }
}