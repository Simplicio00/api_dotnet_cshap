using System.Collections.Generic;
using System.Threading.Tasks;
using gufosapi.Models;
using gufosapi.Repositorio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace gufosapi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class LocalizacaoController : ControllerBase
    {
        LocalizacaoRepositorio repositorio = new LocalizacaoRepositorio();




        // Retorna a lista de localização 

        [HttpGet]
        public async Task<ActionResult<List<Localizacao>>> Listar(){
             List<Localizacao> listaDeLocalizacao = await repositorio.Listar();   
            if(listaDeLocalizacao == null){
            return NotFound();
            }            
            return listaDeLocalizacao;
            }









        // Faz uma pesquisa por id e retorna a localizacao desejada

       [HttpGet("{id}")]
       public async Task<ActionResult<Localizacao>> ListarPorId(int idL){
           Localizacao localizacaoRetornada = await repositorio.ListarPorId(idL);
           if(localizacaoRetornada == null){
               return NotFound();
           }
           return localizacaoRetornada;
       }









        // Faz o cadastro da localização 

       [HttpPost]
       public async Task<ActionResult<Localizacao>> Cadastro(Localizacao localizacaoCadastro){
           try
           {
               Localizacao Cadastro = await repositorio.Cadastro(localizacaoCadastro);
           }
              catch (System.Exception)
           {
               throw;
           }
             return localizacaoCadastro;
       }







       

        // Faz a modificação da localização

       [HttpPut("{idL}")]
       public async Task<ActionResult<Localizacao>> Modificar(int idL, Localizacao localizacaoAlterada){
         if(idL != localizacaoAlterada.LocalizacaoId){
             return BadRequest();
         }
         
         try{
          return await repositorio.Modificar(localizacaoAlterada); 
        }
        catch(DbUpdateConcurrencyException){
            var localizacaoValida = await repositorio.ListarPorId(idL);
            if (localizacaoValida == null){
                return NotFound();
            }else{
                throw;
            }
        }
       }






        // Apaga a localização da tabela    

       [HttpDelete("{id}")]
       public async Task<ActionResult<Localizacao>> Apagar(int id){
           Localizacao localizacaoApagar = await repositorio.ListarPorId(id);
           if(localizacaoApagar == null){
               return NotFound();
           }
           await repositorio.Apagar(localizacaoApagar);
           return localizacaoApagar;
       }
    }
}