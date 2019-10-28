using exercicio_api1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace exercicio_api1.Context
{
    public class TarefaContext : DbContext
    {
        public TarefaContext()
        {
        }
        public TarefaContext(DbContextOptions<TarefaContext> options):base(options){
        }

        public virtual DbSet<TarefaModel> tarefa_tbl { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder OptionsBuilder){
            if(!OptionsBuilder.IsConfigured){
                OptionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS; Database=registro; Integrated Security=true");
            }
        }

        





    }
}