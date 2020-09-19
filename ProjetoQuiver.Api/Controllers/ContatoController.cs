using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoQuiver.Api.Data;
using ProjetoQuiver.Api.Models;

namespace ProjetoQuiver.Api.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Route("contatos")]
    [ApiController]
    public class ContatoController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        [AllowAnonymous]
        [ResponseCache(VaryByHeader = "User-Agent", Location = ResponseCacheLocation.Any, Duration = 30)]
        public async Task<ActionResult<List<Contato>>> Get([FromServices] DataContext context)
        {
            var contatos = await context.Contato
                .Include(x => x.Telefones)
                .AsNoTracking()
                .ToListAsync();

            return Ok(contatos);
        }

        [HttpGet]
        [Route("{id:int}")]
        [AllowAnonymous]
        [ResponseCache(VaryByHeader = "User-Agent", Location = ResponseCacheLocation.Any, Duration = 30)]
        public async Task<ActionResult<Contato>> GetById(int id, [FromServices] DataContext context)
        {
            try
            {
                var contato = await context
                    .Contato
                    .Include(x => x.Telefones)
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Id == id);

                if (contato == null)
                    return NotFound(new { menssagem = "Este contato não foi encontrado." });

                return Ok(contato);
            }
            catch (Exception e)
            {
                return BadRequest(new { menssagem = "Não foi possivel criar um Contato: " + e.Message });
            }
        }

        [HttpPost]
        [Route("")]
        [Authorize(Roles = "funcionario")]
        public async Task<ActionResult<Contato>> Post([FromBody] Contato model, [FromServices] DataContext context)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                context.Contato.Add(model);
                await context.SaveChangesAsync();

                return Ok(model);
            }
            catch (Exception e)
            {
                return BadRequest(new { menssagem = "Não foi possivel criar um Contato: " + e.Message });
            }
        }

        [HttpPut]
        [Route("{id:int}")]
        [Authorize(Roles = "funcionario")]
        public async Task<ActionResult<Contato>> Put(int id, [FromBody]Contato model, [FromServices] DataContext context)
        {
            if (id != model.Id)
                return NotFound(new { menssagem = "Contato não encontrado!"});
                
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                context.Entry<Contato>(model).State = EntityState.Modified;
                await context.SaveChangesAsync();
                return Ok(model);
            }
            catch (Exception e)
            {
                return BadRequest(new { menssagem = "Ocorreu um erro ao atualizar os dados: " + e.Message});
            }
        }

        [HttpDelete]
        [Route("{id:int}")]
        [Authorize(Roles = "gerente")]
        public async Task<ActionResult<Contato>> Delete(int id, [FromServices] DataContext context)
        {
            var contato = await context.Contato.Include(x => x.Telefones).FirstOrDefaultAsync(x => x.Id == id);
            if (contato == null)
                return NotFound(new { menssagem = "Contato não encontrado"});

            try
            {
                context.Contato.Remove(contato);
                await context.SaveChangesAsync();
                return Ok(new { menssagem = "Contato removido com sucesso."});
            }
            catch (Exception e)
            {
                return BadRequest(new { menssagem = "Ocorreu um erro ao deletar o contato: " + e.Message});
            }
        }
    }
}