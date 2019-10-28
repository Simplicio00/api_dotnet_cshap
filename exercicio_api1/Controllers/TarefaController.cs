using System.Collections.Generic;
using System.Linq;
using exercicio_api1.Context;
using exercicio_api1.Models;
using Microsoft.AspNetCore.Mvc;

namespace exercicio_api1.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class TarefaController : ControllerBase
    {

        TarefaContext context = new TarefaContext();

        [HttpGet]
        public IActionResult Listar(){
            List<TarefaModel> lista_de_tarefas = context.tarefa_tbl.ToList();
            return Ok(lista_de_tarefas);
        }

        [HttpPost]

        public IActionResult Cadastro(TarefaModel atarefa){
            context.tarefa_tbl.Add(atarefa);
            context.SaveChanges();
            return Ok();
        }


        [HttpDelete("{byid}")]

        public IActionResult Deletar(int byid){
            TarefaModel tarefaRetornada = context.tarefa_tbl.FirstOrDefault(x => x.id_tarefa == byid);
        
        if (tarefaRetornada == null)
        {
            return NotFound();
        }
        context.tarefa_tbl.Remove(tarefaRetornada);
        context.SaveChanges();
        return Ok();
        }

        [HttpPut]

        public IActionResult Atualizacao(TarefaModel modificacao){
            TarefaModel tarefaRetornada1 = context.tarefa_tbl.FirstOrDefault(x => x.id_tarefa == modificacao.id_tarefa);
            if (tarefaRetornada1 == null)
            {
                return NotFound();
            }


            tarefaRetornada1.nome_tarefa = modificacao.nome_tarefa;
            tarefaRetornada1.descricao_tarefa = modificacao.descricao_tarefa;
            tarefaRetornada1.data_tarefa = modificacao.data_tarefa;

            context.tarefa_tbl.Update(tarefaRetornada1);
            context.SaveChanges();

            return Ok();

        }



        
    }
}