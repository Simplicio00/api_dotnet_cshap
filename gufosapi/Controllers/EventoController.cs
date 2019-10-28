using System.Collections.Generic;
using System.Threading.Tasks;
using gufosapi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace gufosapi.Controllers {
    [Route ("api/[controller]")]
    [ApiController]
    [Produces ("application/json")]
    public class EventoController : ControllerBase {
        gufuuus_bdContext context = new gufuuus_bdContext ();



        // Listar todas os eventos
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<List<Evento>>> Get () {
            List<Evento> listaDeEvento = await context.Evento.Include (c => c.Categoria).Include (l => l.Localizacao).ToListAsync ();
            if (listaDeEvento == null) {
                return NotFound ();
            }

            foreach (var item in listaDeEvento) {
                item.Categoria.Evento = null;
                item.Localizacao.Evento = null;
            }

            return listaDeEvento;

        }

        // Cadastrar evento
        [HttpPost]

        public async Task<ActionResult<Evento>> Post (Evento evento) {
            try {
                await context.Evento.AddAsync (evento);
                await context.SaveChangesAsync ();
            } catch (System.Exception) {
                throw;
            }
            return evento;
        }

        // buscar evento por id
        [HttpGet ("{ide}")]

        public async Task<ActionResult<Evento>> Get (int ide) {
            Evento eventoRetornado = await context.Evento.FindAsync (ide);
            if (eventoRetornado == null) {
                return NotFound ();
            }
            return eventoRetornado;
        }

        // Deletar evento
        [HttpDelete ("{ide}")]
        public async Task<ActionResult<Evento>> Delete (int ide) {
            Evento eventoRetornado = await context.Evento.FindAsync (ide);
            if (eventoRetornado == null) {
                return NotFound ();
            }
            context.Evento.Remove (eventoRetornado);
            await context.SaveChangesAsync ();
            return eventoRetornado;
        }

        // modificar evento
        [HttpPut ("{idl}")]

        public async Task<ActionResult<Evento>> Put (int ide, Evento evento) {
            if (ide != evento.EventoId) {
                return BadRequest ();
            }

            context.Entry (evento).State = EntityState.Modified;

            try {
                await context.SaveChangesAsync ();

            } catch (DbUpdateConcurrencyException) {
                var localizacaoValida = context.Evento.FindAsync (ide);
                if (localizacaoValida == null) {
                    return NotFound ();
                } else {
                    throw;
                }
            }
            return evento;
        }

    }

}