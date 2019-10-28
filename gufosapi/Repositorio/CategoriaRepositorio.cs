using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gufosapi.Interfaces;
using gufosapi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace gufosapi.Repositorio
{
    public class CategoriaRepositorio : ICategoriaRepositorio
    {
        gufuuus_bdContext context = new gufuuus_bdContext();





        public async Task<List<Categoria>> Get()
        {
           List<Categoria> listaDeCategoria = await context.Categoria.ToListAsync();

           return listaDeCategoria;
        }





        public async Task<Categoria> Delete(Categoria categoriaRetornada){
            context.Categoria.Remove(categoriaRetornada);
            await context.SaveChangesAsync();
            return categoriaRetornada;
        }



        public async Task<List<Categoria>> Get(int id){
            List<Categoria>listaDeCategoria = await context.Categoria.ToListAsync();
            return listaDeCategoria;
        }


       public Task<Categoria> Post(Categoria categoria)
        {
            throw new System.NotImplementedException();
        }


        public async Task<Categoria> Alterar(Categoria categoria){
            context.Entry(categoria).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return categoria;
        }
    }
}