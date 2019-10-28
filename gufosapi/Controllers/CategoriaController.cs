using System.Collections.Generic;
using System.Threading.Tasks;
using gufosapi.Models;
using gufosapi.Repositorio;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace gufosapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class CategoriaController : ControllerBase
    {
      CategoriaRepositorio repositorio = new CategoriaRepositorio();





        // Listagem de categorias


         [HttpGet]
        public async Task<ActionResult<List<Categoria>>> Get()
        {
            List<Categoria> listaDeCategoria = await repositorio.Get();   
            if(listaDeCategoria == null)
            {
                return NotFound();
            }
            return listaDeCategoria;
        }

        [HttpGet("{id}")]
       public async Task<ActionResult<Categoria>> Get(int id){
           Categoria categoriaRetornada = await context.Categoria.FindAsync(id);
           if(categoriaRetornada == null)
           {
               return NotFound();
           }
           return categoriaRetornada;
       }






      

        [HttpPut("{id}")]
       public async Task<ActionResult<Categoria>> Put(int id, Categoria categoria)
       {
         if(id != categoria.CategoriaId)
         {
             return BadRequest();
         }
        try
        {
          await repositorio.Alterar(categoria); 
        }
        catch(DbUpdateConcurrencyException){
            var categoriaValida = repositorio.Get(id);
            if (categoriaValida == null){
                return NotFound();
            }else{
                throw;
            }
        }
        return categoria;
       }




       
       [HttpPost]
       public async Task<ActionResult<Categoria>> Post(Categoria categoria)
       {
           try
           {
             await context.Categoria.AddAsync(categoria);
             await context.SaveChangesAsync();
           }
           catch (System.Exception)
           {
               throw;
           }
           return categoria;
       }










       [HttpDelete]

       public async Task<ActionResult<Categoria>> Delete(int id){
           Categoria categoriaRetornada = await repositorio.Get(id);
       }


        }

    }
