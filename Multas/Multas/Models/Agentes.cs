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


        //descrição dos atributos
        //anotação do atributo
        [Key]
        public int ID { get; set; }

        //campo obrigatório
        [Required (ErrorMessage ="O {0} é de preenchimento obrigatório!")]
        [RegularExpression("[A-ZÍÉÂÁ][a-záéíóúàèìòùâêîôûäëïöüãõç]+(( |'|-| dos | da | de | e | d'|)[A-ZÍÉ][a-záéíóúàèìòùâêîôûäëïöüãõç]+){1,3}", ErrorMessage ="O {0} apenas pode conter letras e espaços em branco. Cada palavra começa em Maiúscula seguida de minúsculas...")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "A {0} é de preenchimento obrigatório!")]
        [RegularExpression("[A-ZÍÉÂÁ]*[a-záéíóúàèìòùâêîôûäëïöüãõç]*")]
        public string Esquadra { get; set; }

        public string Fotografia { get; set; }

        //referencia às multas que um Agente 'emite' 

        public virtual ICollection<Multas> ListaDeMultas { get; set; }


    }
}