using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using gufosapi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace gufosapi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class LoginController : ControllerBase
    {
    
        //Chamamos nosso contexto do banco 
        gufuuus_bdContext _context = new gufuuus_bdContext();


        // Define uma variável para percorrer nossos métodos com as configurações do appSettings.json
        private IConfiguration _config;

        // definimos um método construtor para validar informações do appsettingws.js

        public LoginController (IConfiguration config){
            _config = config;
        }


        [AllowAnonymous]
        [HttpPost]
        public IActionResult login(Usuario login){
            //Cria uma variavel do tipo iaction result que por padrão não é autorizado
            IActionResult resposta = Unauthorized();

            //Valida se o usuario passado no post existe no banco de dados.
            var usuario = autenticarUsuario(login);


            //Verifica se o usuario é diferente de nulo
            if (usuario != null){
                //Cria a variavel que armazena o valor de nosso tokem
                var tokenLinha = gerarJsonWebToken(usuario);
                //Define que a resposta será 200 ok e retornará um objeto chamado token com o token
                resposta = Ok(new {token = tokenLinha});
            }
            //Retorna a resposta
            return resposta;
        }



        /// <summary>
        /// método privado que valida se um usuário existe em nosso banco de dados
        /// </summary>
        /// <param name="login">Objeto do tipo usuario</param>
        /// <returns>Objeto do tipo usuario</returns>
        private Usuario autenticarUsuario(Usuario login){

            //Declara uma variavel que busca em nosso banco de dados um usuario que tenha o email e a senha presente no banco de dados
            var usuario = _context.Usuario.FirstOrDefault(user => user.Email == login.Email && user.Senha == login.Senha);


            //Verifica se a resposta do banco de dados é diferente de null
            if (usuario != null)
            {
                //Retorna usuário
                return login;
            }

            //Retora usuário
            return usuario;
        }

        private string gerarJsonWebToken(Usuario infoUsuario){
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            //Definimos nossas claims (dados da sessão) para poderem ser capturadas 
            //A qualquer momento enquanto o token for ativo
            var claims = new[]{
                new Claim(JwtRegisteredClaimNames.NameId, infoUsuario.Nome),
                new Claim(JwtRegisteredClaimNames.Email, infoUsuario.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"], _config["Jwt:Issuer"], claims, expires: DateTime.Now.AddMinutes(120), signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    

    }
}