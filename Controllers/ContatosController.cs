﻿using APIListaContatos.Models;
using APIListaContatos.Services;
using Microsoft.AspNetCore.Mvc;

namespace APIListaContatos.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ContatosController : ControllerBase
    {
        private readonly IContatoService _contatoService;

        public ContatosController(IContatoService contatoService)
        {
            _contatoService = contatoService;
        }


        [HttpGet("{pessoaId:int}")]
        public async Task<ActionResult<IAsyncEnumerable<Contato>>> GetContatos(int pessoaId)
        {
            try
            {
                var contatos = await _contatoService.GetContatos(pessoaId);
                return Ok(contatos);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Houve um problema com a solicitação");
            }
        }

        [HttpPost]
        public async Task<ActionResult> Create(Contato contato)
        {
            try
            {
                if (contato is null)
                    return BadRequest("Dados inválidos");

                await _contatoService.CreateContato(contato);

                return Ok();
            }
            catch
            {
                return BadRequest("Solicitação inválida");
            }

        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Contato>> Edit(int id, Contato contato)
        {
            try
            {
                if (id != contato.ContatoId)
                    return BadRequest("Dados inválidos");

                await _contatoService.UpdateContato(contato);

                return Ok($"Contato com id: {id} foi atualizado com sucesso");
            }
            catch
            {
                return BadRequest("Solicitação inválida");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var contato = await _contatoService.GetContato(id);

                if (contato is null)
                    return NotFound($"Contato com id: {id} não encontrado");

                await _contatoService.DeleteContato(contato);

                return Ok($"Contato com id: {id} foi excluido com sucesso");
            }
            catch
            {
                return BadRequest("Solicitação inválida");
            }
        }
    }
}
