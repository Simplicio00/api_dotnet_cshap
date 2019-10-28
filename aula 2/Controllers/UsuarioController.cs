using System.Collections.Generic;
using System.Linq;
using aula_2.Models;
using aula_2.Context;
using Microsoft.AspNetCore.Mvc;

namespace aula_2.Controllers
{

    [ApiController]
    [Route("v1/[controller]")]
    [Produces("application/json")]
    public class UsuarioController : ControllerBase
    {
        Aula2Context context = new Aula2Context();

        [HttpGet]
        public IActionResult Listar(){

        List<UsuarioModel> listaDeUsuarios = context.tbl_usuario.ToList();
        return Ok(listaDeUsuarios);
        }

       

           
           
        /// <param name="usuario"></param>
       

        [HttpPost]
        public IActionResult Cadastrar(UsuarioModel usuario){
        context.tbl_usuario.Add(usuario);
        context.SaveChanges();
        return Ok();

        }

         /// <summary>
        /// efetua a busca de um usuário atravez do ID
        /// </summary>

         /// <param name="id">Recebe o id como parâmetro</param>

        /// <returns>Retorna o usuário com id correspondente</returns>


        [HttpGet("{id}")]

        public IActionResult BuscarPorId(int id){
            UsuarioModel usuarioRetornado = context.tbl_usuario.FirstOrDefault(x => x.usuario_id == id);
            return Ok(usuarioRetornado);
        }


        [HttpPut]
        public IActionResult Atualizar(UsuarioModel usuario){
         UsuarioModel usuarioretornadoAntigo = context.tbl_usuario.FirstOrDefault(x => x.usuario_id == usuario.usuario_id);
         if (usuarioretornadoAntigo == null){
             return NotFound();
         }

        
         usuarioretornadoAntigo.usuario_nome = usuario.usuario_nome;
         usuarioretornadoAntigo.usuario_email = usuario.usuario_email;
         usuarioretornadoAntigo.usuario_senha = usuario.usuario_senha;

        context.tbl_usuario.Update(usuarioretornadoAntigo);
        context.SaveChanges();

        return Ok();
    
        }
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id){
            UsuarioModel usuarioRetornado = context.tbl_usuario.FirstOrDefault(x => x.usuario_id == id);
            if(usuarioRetornado == null){
                return NotFound();
            }
            context.tbl_usuario.Remove(usuarioRetornado);

            context.SaveChanges();
            return Ok();

        }

    }
}