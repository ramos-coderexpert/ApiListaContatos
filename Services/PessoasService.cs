using APIListaContatos.Context;
using APIListaContatos.Models;
using Microsoft.EntityFrameworkCore;

namespace APIListaContatos.Services
{
    public class PessoasService : IPessoaService
    {
        private readonly AppDbContext _context;

        public PessoasService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Pessoa>> GetPessoas()
        {
            return await _context.Pessoas.ToListAsync();
        }

        public async Task<IEnumerable<Pessoa>> GetPessoasContatos()
        {
            return await _context.Pessoas.Include(p => p.Contatos).ToListAsync();
        }

        public async Task<Pessoa> GetPessoa(int id)
        {
            var pessoa = await _context.Pessoas.FindAsync(id);
            return pessoa;
        }

        public async Task CreatePessoa(Pessoa pessoa)
        {
            _context.Pessoas.Add(pessoa);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePessoa(Pessoa pessoa)
        {
            _context.Entry(pessoa).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeletePessoa(Pessoa pessoa)
        {
            _context.Pessoas.Remove(pessoa);
            await _context.SaveChangesAsync();
        }
    }
}
