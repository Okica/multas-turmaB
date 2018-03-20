using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Multas.Models
{
    public class Viaturas
    {
        //construtor
        public Viaturas()
        {
            //instanciar a lista de multas
            ListaDeMultas = new HashSet<Multas>();
        }


        [Key]
        public int ID { get; set; } //PK

        //Dados de uma viatura

        public string Matricula { get; set; }

        public string Modelo { get; set; }

        public string Cor { get; set; }

        //Dados do dono de uma viatura

        public string NomeDono { get; set; }

        public string MoradaDono { get; set; }

        public string CodPostalDono { get; set; }

        //referencia às multas que um condutor 'emite' numa Viatura

        public virtual ICollection <Multas> ListaDeMultas { get; set; }


    }
}