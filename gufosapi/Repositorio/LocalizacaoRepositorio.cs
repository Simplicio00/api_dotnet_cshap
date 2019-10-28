using System.Collections.Generic;
using System.Threading.Tasks;
using gufosapi.Interfaces;
using gufosapi.Models;
using Microsoft.EntityFrameworkCore;

namespace gufosapi.Repositorio
{
    public class LocalizacaoRepositorio : ILocalizacaoRepositorio
    {
        gufuuus_bdContext bancoDeDados = new gufuuus_bdContext();
        
        
        
        // Modifica a localizacao
        
        public async Task<Localizacao> Modificar(Localizacao localizacaoAlterada)
        {
            bancoDeDados.Entry(localizacaoAlterada).State = EntityState.Modified;
            await bancoDeDados.SaveChangesAsync();
            return localizacaoAlterada;
        }




        // Apaga a localizacao

        public async Task<Localizacao> Apagar(Localizacao localizacaoApagar)
        {
            bancoDeDados.Localizacao.Remove(localizacaoApagar);
            await bancoDeDados.SaveChangesAsync();
           return localizacaoApagar;
        } 



        //  Lista a localizacao

        public async Task<List<Localizacao>> Listar()
        {
           List<Localizacao> localizacaoLista = await bancoDeDados.Localizacao.ToListAsync();
           return localizacaoLista;
        }




        // Lista pelo seu id
        public async Task<Localizacao> ListarPorId(int idL)
        {
            
        return await bancoDeDados.Localizacao.FindAsync(idL);
        }





        // Cadastra a localizacao

        public async Task<Localizacao> Cadastro(Localizacao localizacaoCadastro)
        {
            await bancoDeDados.Localizacao.AddAsync(localizacaoCadastro);
            await bancoDeDados.SaveChangesAsync();  
            return localizacaoCadastro; 
        }


    }
}