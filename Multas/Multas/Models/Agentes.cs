using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Multas.Models
{
    public class Agentes
    {

        //construtor
        public Agentes()
        {
            ListaDeMultas = new HashSet<Multas>();
        }
        //anotação do atributo
        [Key]

        //descrição dos atributos
        public int ID { get; set; }

        public string Nome { get; set; }

        public string Esquadra { get; set; }

        public string Fotografia { get; set; }

        //referencia às multas que um Agente 'emite' 

        public virtual ICollection<Multas> ListaDeMultas { get; set; }


    }
}