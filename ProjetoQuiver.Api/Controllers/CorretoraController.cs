using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoQuiver.Api.Data;
using ProjetoQuiver.Api.Models;
using ProjetoQuiver.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoQuiver.Api.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Route("corretoras")]
    [ApiController]
    public class CorretoraController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        [AllowAnonymous]
        [ResponseCache(VaryByHeader = "User-Agent", Location = ResponseCacheLocation.Any, Duration = 30)]
        public async Task<ActionResult<List<Corretora>>> Get([FromServices] DataContext context)
        {
            var model = await context
                .Corretora
                .Include(x => x.Contatos).ThenInclude(x => x.Telefones)
                .AsNoTracking()
                .ToListAsync();
            return model;
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
                    .Corretora
                    .Include(x => x.Contatos).ThenInclude(x => x.Telefones)
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Id == id);

                if (contato == null)
                    return NotFound(new { menssagem = "Esta corretora não foi encontrado." });

                return Ok(contato);
            }
            catch (Exception e)
            {
                return BadRequest(new { menssagem = "Não foi possivel criar uma corretora: " + e.Message });
            }
        }

        [HttpPost]
        [Route("")]
        [AllowAnonymous]
        public async Task<ActionResult<Corretora>> Post([FromServices] DataContext context,
            [FromBody] Corretora model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                model.Role = "funcionario";
                context.Corretora.Add(model);
                await context.SaveChangesAsync();

                model.Password = "";
                return model;
            }
            catch (Exception e)
            {
                return BadRequest(new { message = "Não foi possível criar o usuário: " + e.Message });

            }
        }

        [HttpPut]
        [Route("{id:int}")]
        [Authorize(Roles = "gerente")]
        public async Task<ActionResult<Corretora>> Put([FromServices] DataContext context, int id, [FromBody] Corretora model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != model.Id)
                return NotFound(new { message = "Usuário não encontrada" });

            try
            {
                context.Entry(model).State = EntityState.Modified;
                await context.SaveChangesAsync();
                return model;
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Não foi possível criar o usuário" });

            }
        }

        [HttpDelete]
        [Route("{id:int}")]
        [Authorize(Roles = "gerente")]
        public async Task<ActionResult<Contato>> Delete(int id, [FromServices] DataContext context)
        {
            var corretora = await context
                .Corretora
                .Include(x => x.Contatos).ThenInclude(x => x.Telefones)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (corretora == null)
                return NotFound(new { menssagem = "Corretora não encontrado" });

            try
            {
                context.Corretora.Remove(corretora);
                await context.SaveChangesAsync();
                return Ok(new { menssagem = "Corretora removido com sucesso." });
            }
            catch (Exception e)
            {
                return BadRequest(new { menssagem = "Ocorreu um erro ao deletar o corretora: " + e.Message });
            }
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Authenticate([FromServices] DataContext context, [FromBody] Corretora model)
        {
            var user = await context.Corretora
                .AsNoTracking()
                .Where(x => x.Nome == model.Nome && x.Password == model.Password)
                .FirstOrDefaultAsync();

            if (user == null)
                return NotFound(new { message = "Usuário ou senha inválidos" });

            var token = TokenService.GenerateToken(user);

            user.Password = "";
            return new
            {
                user = user,
                token = token
            };
        }
    }
}
