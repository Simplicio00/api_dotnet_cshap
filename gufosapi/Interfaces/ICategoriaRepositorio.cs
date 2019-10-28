using System.Collections.Generic;
using System.Threading.Tasks;
using gufosapi.Models;
using Microsoft.AspNetCore.Mvc;

namespace gufosapi.Interfaces
{
    public interface ICategoriaRepositorio
    {
        Task<List<Categoria>> Get();

        Task<Categoria> Get(int id);

        Task<Categoria> Post(Categoria categoria);

        Task<Categoria> Alterar(Categoria categoria);

        Task<Categoria> Delete(Categoria categoriaRetornada);
         
    }
}