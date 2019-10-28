using System.Collections.Generic;
using System.Linq;
using aula1.Models;
using Microsoft.AspNetCore.Mvc;

namespace aula1.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]// [ApiController]define a rota de acesso para os métodos deste controller
    [Produces("application/json")] // Tipo de dado a ser transmitido
    public class UsuarioController : ControllerBase
    {

        // actionresult retorna um resultado (interface) 
        
        List<UsuarioModel> listaDeUsuarios = new List<UsuarioModel>();
        [HttpGet("listar")]

        public IActionResult  Usuarios()
        { 
            UsuarioModel usuario1  = new UsuarioModel();
            // primeiro usuário
            usuario1.usuarioId = 1;
            usuario1.usuarioNome = "jose";
            usuario1.usuarioEmail = "jose@kiei";
            usuario1.usuarioSenha = "sss";
        
            // segundo usuário

            UsuarioModel usuario2  = new UsuarioModel();
            usuario2.usuarioId = 2;
            usuario2.usuarioNome = "Joao";
            usuario2.usuarioEmail = "joao@gmail.com";
            usuario2.usuarioSenha = "12345";
            
            // lista de usuarios
            
            listaDeUsuarios.Add(usuario1);
            listaDeUsuarios.Add(usuario2);

            return Ok(listaDeUsuarios);
        }

        
        [HttpGet("listar/{id}")]
        public IActionResult BuscarPorId(int id){
        Usuarios();
        return Ok(listaDeUsuarios.FirstOrDefault(u => u.usuarioId == id));
        }    
        

        [HttpPost("cadastro")]
        public IActionResult Cadastrar(UsuarioModel usuario)
        {
            Usuarios();
            listaDeUsuarios.Add(usuario);

            return Ok(listaDeUsuarios);
        }
        
        
        }
}