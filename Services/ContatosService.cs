using APIListaContatos.Context;
using APIListaContatos.Models;
using Microsoft.EntityFrameworkCore;

namespace APIListaContatos.Services
{
    public class ContatosService : IContatoService
    {
        private readonly AppDbContext _context;

        public ContatosService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Contato>> GetContatos(int pessoaId)
        {
            return await _context.Contatos.Where(c => c.PessoaId == pessoaId).ToListAsync();
        }

        public async Task<Contato> GetContato(int id)
        {
            var contato = await _context.Contatos.FindAsync(id);
            return contato;
        }

        public async Task CreateContato(Contato contato)
        {
            _context.Contatos.Add(contato);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateContato(Contato contato)
        {
            _context.Entry(contato).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteContato(Contato contato)
        {
            _context.Contatos.Remove(contato);
            await _context.SaveChangesAsync();
        }
    }
}
