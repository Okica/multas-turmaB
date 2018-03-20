using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Multas.Models
{
    public class Multas
    {
        [Key]
        public int ID { get; set; }//PK

        public string Infracao { get; set; }

        public string LocalMulta { get; set; }

        public decimal ValorMulta { get; set; }

        public DateTime DataDaMulta { get; set; }

        //***************************************************
        //representar as chaves forasteiras que relacionam esta classe 
        //com as outras classes
        //***************************************************

        //FK para a tabela dos condutores

        // ... Constraint NomeDoTermo
        // ForeignKey NomeDoAtributo references NomeDaTabela (NomeDoAtributoPK)

        //a FK esta ligada a um atributo chamado "Condutor"
        [ForeignKey("Condutor")]
        public int CondutorFK { get; set; }
        public virtual Condutores Condutor { get; set; }

        //FK para as Viaturas
        [ForeignKey("Viatura")]
        public int ViaturaFK { get; set; }
        public virtual Viaturas Viatura { get; set; }

        //FK para o Agente
        [ForeignKey("Agente")]
        public int AgenteFK { get; set; }
        public virtual Agentes Agente { get; set; }




    }
}