using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Multas.Models
{
    public class MultasDb : DbContext
    {
        //construtor que indica qual a base de dados a utilizar
        public MultasDb() : base("name=MultasDBConnectionString") { }



        //descrever os nomes da tabelas na base de dados
        //        nome do atributo //   da classe
        public virtual DbSet<Multas> Multas { get; set; } // tbl Multas
        public virtual DbSet<Condutores> Condutores { get; set; }// tbl Condutor
        public virtual DbSet<Agentes> Agentes { get; set; } // tbl Agentes
        public virtual DbSet<Viaturas> Viaturas { get; set; } //tbl Viaturas


    }
}