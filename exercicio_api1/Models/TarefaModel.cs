using System;
using System.ComponentModel.DataAnnotations;

namespace exercicio_api1.Models
{
    public class TarefaModel
    {
        [Key]
        public int id_tarefa { get; set; }

        public string nome_tarefa { get; set; }
        
        public string descricao_tarefa { get; set; }
    
        public DateTime data_tarefa { get; set; }
    
    }
}