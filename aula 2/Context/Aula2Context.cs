using aula_2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace aula_2.Context
{
    public class Aula2Context : DbContext 
    {
        public Aula2Context(){}

        // Configurando o acesso ao banco
        public Aula2Context(DbContextOptions<Aula2Context> options):base(options)
        {

        }

        public virtual DbSet<UsuarioModel> tbl_usuario { get; set; } 

        protected override void OnConfiguring(DbContextOptionsBuilder OptionsBuilder)
        {
            if (!OptionsBuilder.IsConfigured)
            {
            OptionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS; Database=aula_api; Integrated Security=true");
            }
        }


    }
}