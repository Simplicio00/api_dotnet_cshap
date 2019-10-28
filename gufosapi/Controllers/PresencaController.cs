using System.Collections.Generic;
using System.Threading.Tasks;
using gufosapi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace gufosapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class PresencaController : ControllerBase
    {
      gufuuus_bdContext context = new gufuuus_bdContext();
      
        // Listar todas as Presenças
        [HttpGet]

        public async Task<ActionResult<List<Presenca>>> Get(){
            List<Presenca> listaDePresenca = await context.Presenca.Include(z => z.Evento).Include(t => t.Evento).ToListAsync();
            if (listaDePresenca == null){
                return NotFound();
            }
            return listaDePresenca;
        }

     

         // Cadastrar Presença
        [HttpPost]

        public async Task<ActionResult<Presenca>> Post(Presenca presenca){
            try
            {
                await context.Presenca.AddAsync(presenca);
                await context.SaveChangesAsync();   
            }
            catch (System.Exception)
            {
                throw;
            }
            return presenca;
        }


        // buscar localização por id
        [HttpGet("{idp}")]

        public async Task<ActionResult<Presenca>> Get(int idp){
            Presenca presencaRetornada = await context.Presenca.FindAsync(idp);
            if (presencaRetornada == null){
                return NotFound();
            }
            return presencaRetornada;    
            }

       
        // Deletar localização
        [HttpDelete("{idp}")]
        public async Task<ActionResult<Presenca>> Delete(int idp){
            Presenca presencaRetornada = await context.Presenca.FindAsync(idp);
        if (presencaRetornada == null)
        {
            return NotFound();
        }
        context.Presenca.Remove(presencaRetornada);
        await context.SaveChangesAsync();
        return presencaRetornada;
        }

        // modificar Presenca
        [HttpPut("{idp}")]

        public async Task<ActionResult<Presenca>> Put(int idp, Presenca presenca){
            if(idp != presenca.PresencaId){
                return BadRequest();
            }

            context.Entry(presenca).State = EntityState.Modified;

            try
            {
               await context.SaveChangesAsync();

            }
            catch (DbUpdateConcurrencyException)
            {
                var presencaValida = context.Presenca.FirstOrDefaultAsync();
                if(presencaValida == null){
                return NotFound();
                }else{
                    throw;
                }
            }
            return presenca;
        }

       






        }

    }
