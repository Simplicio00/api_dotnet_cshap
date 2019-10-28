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
    public class UsuarioController : ControllerBase
    {
      gufuuus_bdContext context = new gufuuus_bdContext();
      
        // Listar todos os usuarios
        
        [HttpGet]
        public async Task<ActionResult<List<Usuario>>> Get(){
            List<Usuario> listaDeUsuario = await context.Usuario.Include(a => a.TipoUsuario).ToListAsync();
            if (listaDeUsuario == null)
            {
                return NotFound();
            }
            return listaDeUsuario;
        }



         // Cadastrar usuario
        [HttpPost]

        public async Task<ActionResult<Usuario>> Post(Usuario usuario){
            try
            {
                await context.Usuario.AddAsync(usuario);
                await context.SaveChangesAsync();   
            }
            catch (System.Exception)
            {
                throw;
            }
            return usuario;
        }


        // buscar usuario por id
        [HttpGet("{idp}")]

        public async Task<ActionResult<Usuario>> Get(int idp){
            Usuario usuarioRetornado = await context.Usuario.FindAsync(idp);
            if (usuarioRetornado == null){
                return NotFound();
            }
            return usuarioRetornado;    
            }

       
        // Deletar usuario
        [HttpDelete("{idp}")]
        public async Task<ActionResult<Usuario>> Delete(int idp){
            Usuario usuarioRetornado = await context.Usuario.FindAsync(idp);
        if (usuarioRetornado == null)
        {
            return NotFound();
        }
        context.Usuario.Remove(usuarioRetornado);
        await context.SaveChangesAsync();
        return usuarioRetornado;
        }

        // modificar usuario
        [HttpPut("{idp}")]

        public async Task<ActionResult<Usuario>> Put(int idp, Usuario usuario){
            if(idp != usuario.UsuarioId){
                return BadRequest();
            }

            context.Entry(usuario).State = EntityState.Modified;

            try
            {
               await context.SaveChangesAsync();

            }
            catch (DbUpdateConcurrencyException)
            {
                var usuarioValido = context.Usuario.FirstOrDefaultAsync();
                if(usuarioValido == null){
                return NotFound();
                }else{
                    throw;
                }
            }
            return usuario;
        }

       






        }

    }
