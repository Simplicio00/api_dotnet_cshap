using System.Collections.Generic;
using System.Threading.Tasks;
using gufosapi.Models;
using Microsoft.AspNetCore.Mvc;

namespace gufosapi.Interfaces
{
    public interface ILocalizacaoRepositorio
    {
         Task<Localizacao> Modificar(Localizacao localizacaoAlterada);

         Task<Localizacao> Apagar(Localizacao localizacaoApagar);
         
         Task<List<Localizacao>> Listar();

         Task<Localizacao> ListarPorId(int idL);

         Task<Localizacao> Cadastro(Localizacao localizacaoCadastro);
    }
}