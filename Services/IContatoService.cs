using APIListaContatos.Models;

namespace APIListaContatos.Services
{
    public interface IContatoService
    {
        Task<IEnumerable<Contato>> GetContatos(int pessoaId);
        Task<Contato> GetContato(int id);
        Task CreateContato(Contato contato);
        Task UpdateContato(Contato contato);
        Task DeleteContato(Contato contato);
    }
}
