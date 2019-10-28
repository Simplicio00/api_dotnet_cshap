using System.ComponentModel.DataAnnotations;

namespace aula_2.Models
{
    public class UsuarioModel
    {   
        [Key]
        public int usuario_id { get; set; }
        public string usuario_nome { get; set; }
    
        public string usuario_email { get; set; }
    
        public string usuario_senha { get; set; }
    }
}