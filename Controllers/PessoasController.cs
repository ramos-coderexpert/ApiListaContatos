using APIListaContatos.Models;
using APIListaContatos.Services;
using Microsoft.AspNetCore.Mvc;

namespace APIListaContatos.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PessoasController : ControllerBase
    {
        private readonly IPessoaService _pessoaService;

        public PessoasController(IPessoaService pessoaService)
        {
            _pessoaService = pessoaService;
        }


        [HttpGet]
        public async Task<ActionResult<IAsyncEnumerable<Pessoa>>> GetPessoas()
        {
            try
            {
                var pessoas = await _pessoaService.GetPessoasContatos();
                return Ok(pessoas);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Houve um problema com a solicitação");
            }

        }

        [HttpGet("{id:int}", Name = "ObterPessoa")]
        public async Task<ActionResult<Pessoa>> GetPessoaById(int id)
        {
            try
            {
                var pessoa = await _pessoaService.GetPessoa(id);

                if (pessoa is null)
                    return NotFound($"Pessoa com id: {id} não encontrada");

                return Ok(pessoa);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Houve um problema com a solicitação");
            }
        }

        [HttpPost]
        public async Task<ActionResult> Create(Pessoa pessoa)
        {
            try
            {
                if (pessoa is null)
                    return BadRequest("Dados inválidos");

                await _pessoaService.CreatePessoa(pessoa);

                return new CreatedAtRouteResult("ObterPessoa", new { id = pessoa.PessoaId }, pessoa);
            }
            catch
            {
                return BadRequest("Solicitação inválida");
            }

        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Pessoa>> Edit(int id, Pessoa pessoa)
        {
            try
            {
                if (id != pessoa.PessoaId)
                    return BadRequest("Dados inválidos");

                await _pessoaService.UpdatePessoa(pessoa);

                return Ok($"Pessoa com id: {id} foi atualizado com sucesso");
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
                var pessoa = await _pessoaService.GetPessoa(id);

                if (pessoa is null)
                    return NotFound($"Pessoa com id: {id} não encontrada");

                await _pessoaService.DeletePessoa(pessoa);

                return Ok($"Pessoa com id: {id} foi excluido com sucesso");
            }
            catch
            {
                return BadRequest("Solicitação inválida");
            }
        }
    }
}
